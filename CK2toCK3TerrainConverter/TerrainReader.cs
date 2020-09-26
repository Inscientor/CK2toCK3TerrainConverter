using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CK2toCK3TerrainConverter
{
    class TerrainReader
    {
        public string CK2TerrainTextPath { get; set; }
        public string CK2TerrainImagePath { get; set; }
        public string ProvinceDefinitionPath { get; set; }
        public string ProvinceMapPath { get; set; }
        internal List<CK3Province> Provinces { get; set; }

        public IEnumerable<CK3Province> Read()
        {
            var erBox = new MessageListBox();
            if (string.IsNullOrEmpty(CK2TerrainTextPath))
                erBox.Message.Add("CK2の地形情報テキストのパスが未入力です。");
            if (string.IsNullOrEmpty(CK2TerrainImagePath))
                erBox.Message.Add("CK2の地形マップ画像のパスが未入力です。");
            if (string.IsNullOrEmpty(ProvinceDefinitionPath))
                erBox.Message.Add("CK3のプロヴィンス定義CSVファイルのパスが未入力です。");
            if (string.IsNullOrEmpty(ProvinceMapPath))
                erBox.Message.Add("CK3のプロヴィンス割りマップ画像のパスが未入力です。");

            if (erBox.Message.Count > 0)
            {
                erBox.Header = "未入力項目が合ったため処理を中止しました。";
                erBox.Bullet = "・";
                erBox.Title = "エラー";
                erBox.Show(System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                return null;
            }

            // CK2の地形情報テキストを読み込み
            var ck2TerrainInfo = ReadCK2TerrainList(CK2TerrainTextPath);

            // CK3のプロヴィンス定義を読み込んでプロヴィンスの内部表現を作成
            // 721番までしか使用されていないので、余裕を持ってのみ取得
            var provinces = ReadCK3Provinces(ProvinceDefinitionPath).Take(730);

            // マップ画像からプロヴィンスの区分けとCK2地形情報の読み込み
            using (var provinceBitmap = new Bitmap(ProvinceMapPath))
            using (var terrainBitmap = new Bitmap(CK2TerrainImagePath))
            using (var provinceImage = new Pixelmap.Pixelmap(provinceBitmap))
            using (var terrainImage = new Pixelmap.Pixelmap(terrainBitmap))
            {
                provinces = ReadProvincePixel(provinceImage, terrainImage, provinces);
            }

            //読み込んだCK2地形情報からCK3地形情報を決定する
            DecideTerrain(provinces, ck2TerrainInfo);

            return provinces.Where(p => p.InsideTerrainPixels.Any());
        }

        private IEnumerable<CK2Terrain> ReadCK2TerrainList(string path) => CK2Terrain.MakeTerrains(path);

        /// <summary>
        /// プロヴィンス定義CSV情報を読んでプロヴィンス情報の内部表現を作成する
        /// </summary>
        /// <param name="path">プロヴィンス定義CSVのパス</param>
        /// <returns></returns>
        private IEnumerable<CK3Province> ReadCK3Provinces(string path)
        {
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // 空行は飛ばす
                    // でないと情報が空のインスタンスが戻ってしまう
                    if (string.IsNullOrEmpty(line))
                        continue;

                    // データ形式
                    // ID;R;G;B;不明;不明
                    var param = line.Split(';');
                    yield return new CK3Province
                    {
                        ID = int.Parse(param[0]),
                        Color = Color.FromArgb(byte.Parse(param[1]), byte.Parse(param[2]), byte.Parse(param[3]))
                    };
                }
            }
        }

        /// <summary>
        /// プロヴィンス分けマップ画像と地形マップ画像はピクセル単位で対応している必要がある
        /// </summary>
        /// <param name="prvMap">プロヴィンス分け指定画像</param>
        /// <param name="terMap">地形マップ画像</param>
        /// <param name="provinces">プロヴィンス情報 出力を兼ねる</param>
        private IEnumerable<CK3Province> ReadProvincePixel(Pixelmap.Pixelmap prvMap, Pixelmap.Pixelmap terMap, IEnumerable<CK3Province> provinces)
        {
            // 色からプロヴィンス情報にアクセスする用の連想配列
            Dictionary<int, CK3Province> prvDic = provinces.ToDictionary(p => p.Color.ToArgb());

            for (int i = 0; i < prvMap.Count; i++)
            {
                // 白か黒なら非プロビなので飛ばす
                if (prvMap[i].ToColor().ToArgb().Equals(Color.White.ToArgb()) || prvMap[i].ToColor().ToArgb().Equals(Color.Black.ToArgb()))
                    continue;

                if (!prvDic.ContainsKey(prvMap[i].ToColor().ToArgb()))
                    continue;

                prvDic[prvMap[i].ToColor().ToArgb()].InsideTerrainPixels.Add(terMap[i]);
            }

            return prvDic.Select(d => d.Value);
        }

        /// <summary>
        /// プロヴィンスの地形を決定する
        /// </summary>
        /// <param name="provinces">プロヴィンス情報</param>
        /// <param name="terrains">CK2の地形情報</param>
        private void DecideTerrain(IEnumerable<CK3Province> provinces, IEnumerable<CK2Terrain> terrains)
        {
            foreach (var prv in provinces)
            {
                if (prv.InsideTerrainPixels.Count < 1)
                    continue;

                // 色からTerrainを検索できる辞書
                Dictionary<int, CK2Terrain> terrainOf = terrains.ToDictionary(t => t.Color.ToArgb());

                // 内部ピクセルの分布から地形情報を一つに絞る
                // 最多ピクセル色の地形情報で決定する
                var countDic = new Dictionary<int, int>();
                foreach (var p in prv.InsideTerrainPixels)
                {
                    if (countDic.ContainsKey(p.ToColor().ToArgb()))
                        countDic[p.ToColor().ToArgb()]++;
                    else
                        countDic.Add(p.ToColor().ToArgb(), 1);
                }
                
                var maxColor = countDic.OrderBy(p => terrainOf[p.Key].Ratio * p.Value).Last().Key;
                prv.CK2Terrain = terrains.FirstOrDefault(t => t.Color.ToArgb() == maxColor);

                prv.CK3TerrainName = prv.CK2Terrain.ToCK3Terrain();
            }
        }
    }
}

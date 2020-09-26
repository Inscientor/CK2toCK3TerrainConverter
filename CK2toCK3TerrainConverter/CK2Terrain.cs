using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CK2toCK3TerrainConverter
{
    class CK2Terrain
    {
        public Color Color { get; private set; }
        public string Name { get; private set; }
        public double Ratio { get; private set; }

        public CK2Terrain()
        {
        }

        public CK2Terrain(Color color, string name, double ratio)
        {
            Color = color;
            Name = name;
            Ratio = ratio <= 0 ? double.MinValue : ratio;
        }

        public override string ToString()
        {
            return $"{Name} : {Color}";
        }

        #region 変換方法の指定部分
        internal string ToCK3Terrain()
        {
            return Name;
        }

        public static IEnumerable<CK2Terrain> MakeTerrains(string textPath)
        {
            return MakeTerrainsByCSV(textPath);
        }


        public static IEnumerable<CK2Terrain> MakeTerrainsByCSV(string textPath)
        {
            using (var reader = new StreamReader(textPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    yield return new CK2Terrain(Color.FromArgb(byte.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2])), data[3],double.Parse(data[4]));
                }
            }
        }


        public static IEnumerable<CK2Terrain> MakeTerrainsByText(string textPath)
        {
            using (var reader = new StreamReader(textPath))
            {
                int nestLevel = 0;
                var scopeName = new Stack<string>();
                string line;
                var terra = new CK2Terrain();

                while ((line = reader.ReadLine()) != null)
                {
                    // "#"で始まっていればコメント行なので読み飛ばす
                    if (line.StartsWith("#"))
                        continue;

                    string idName = "";

                    // "="が含まれていれば識別子の宣言
                    if (line.Contains("="))
                    {
                        idName = line.Replace('\t', ' ');
                        idName = idName.Remove(idName.IndexOf("=")).Trim();

                        switch (idName)
                        {
                            case "terrain":
                                // 地形の数が書かれている
                                // 不要
                                break;
                            case "categories":
                                // 地形情報のスコープの開始
                                break;
                            default:
                                if (nestLevel > 0 && scopeName.Peek() == "categories")
                                {
                                    // 地形情報の識別名
                                    terra.Name = idName;
                                }
                                else if (idName == "color")
                                {
                                    // 色情報行
                                    string numStart = line.Remove(0, line.IndexOf("{") + 1);
                                    var colorValue = numStart.Remove(numStart.IndexOf("}")).Trim().Split(' ').Select(num => byte.Parse(num)).ToArray();
                                    terra.Color = Color.FromArgb(colorValue[0], colorValue[1], colorValue[2]);
                                }

                                break;
                        }
                    }

                    if (line.Contains("{"))
                    {
                        nestLevel++;
                        scopeName.Push(idName);
                    }

                    if (line.Contains("}"))
                    {
                        nestLevel--;
                        scopeName.Pop();

                        if (nestLevel == 0)
                            // categories を抜けたら後は不要なので抜ける
                            break;

                        if (scopeName.Peek() == "categories")
                        {
                            yield return terra;
                            terra = new CK2Terrain();
                        }
                    }
                }
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK2toCK3TerrainConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            var terr = new TerrainReader();
            terr.CK2TerrainImagePath = textBoxTerrainImage.Text;
            terr.CK2TerrainTextPath = textBoxTerrainText.Text;
            terr.ProvinceMapPath = textBoxProvinceMap.Text;
            terr.ProvinceDefinitionPath = textBoxProvinceDefinition.Text;

            var prvs = terr.Read();
            if (prvs is null)
                return;

            string outText = prvs.Select(p => $"{p.PrintTerrain()}").Aggregate("default=plains", (sum, elm) => $"{sum}{Environment.NewLine}{elm}");
            textBoxLog.Text = outText;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "00_province_terrain.txt";
            sfd.Filter = "TXTファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    writer.Write(outText);
                }
            }
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            // DataFormats.FileDropを与えて、GetDataPresent()メソッドを呼び出す。
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            (sender as TextBox).Text = files[0];
        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SavedTerrainImagePath = textBoxTerrainImage.Text;
            Properties.Settings.Default.SavedTerrainTextPath = textBoxTerrainText.Text;
            Properties.Settings.Default.SavedProvinceMapPath = textBoxProvinceMap.Text;
            Properties.Settings.Default.SavedProvinceDefinitionPath = textBoxProvinceDefinition.Text;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxTerrainImage.Text = Properties.Settings.Default.SavedTerrainImagePath;
            textBoxTerrainText.Text = Properties.Settings.Default.SavedTerrainTextPath;
            textBoxProvinceMap.Text = Properties.Settings.Default.SavedProvinceMapPath;
            textBoxProvinceDefinition.Text = Properties.Settings.Default.SavedProvinceDefinitionPath;
        }
    }
}

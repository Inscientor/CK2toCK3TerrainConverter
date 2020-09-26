using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK2toCK3TerrainConverter
{
    public class MessageListBox
    {
        private string bullet;

        public string Title { get; set; }
        public string Header { get; set; }
        public List<string> Message { get; } = new List<string>();
        public string Footer { get; set; }

        public string Bullet { get => bullet.Trim(); set => bullet = value.Trim()+" "; }

        public void Show(MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            string errMsg = "";
            if (!string.IsNullOrEmpty(Header))
                errMsg += $"{Header}{Environment.NewLine}";
            errMsg += Message.Aggregate((sum, elm) => $"{sum}{Environment.NewLine}{bullet}{elm}");
            if (!string.IsNullOrEmpty(Footer))
                errMsg += $"{Environment.NewLine}{Footer}";

            MessageBox.Show(errMsg, Title, buttons, icon);
        }
    }
}

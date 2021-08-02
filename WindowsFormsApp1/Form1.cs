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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private RichTextBox GetCurrentTextBox()
        {
            RichTextBox rtb = null;
            TabPage tp = tabControl1.SelectedTab;
            if (tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox;
            }
            return rtb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveDialog();
        }

        void saveDialog()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                GetCurrentTextBox().SaveFile(saveFile.FileName, RichTextBoxStreamType.UnicodePlainText);
                tabControl1.SelectedTab.ToolTipText = saveFile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.ToolTipText != null && tabControl1.SelectedTab.ToolTipText != "")
            {
                GetCurrentTextBox().SaveFile(tabControl1.SelectedTab.ToolTipText, RichTextBoxStreamType.UnicodePlainText);
                return;
            }
            saveDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabPage tP = new TabPage("TabPage" + tabControl1.TabPages.Count);
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            tP.Controls.Add(rtb);
            tabControl1.Controls.Add(tP);
        }
    }
}

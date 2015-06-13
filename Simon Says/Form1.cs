using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Diagnostics;


namespace Simon_Says
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //downloads url you put in text box

            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData(textBox1.Text);

            string webData = System.Text.Encoding.UTF8.GetString(raw);


            //finds the links of the images

            var items = new List<string>();
            foreach (Match match in Regex.Matches(webData, "File: <a href=\"//(.*?)\" target=\"_blank\">"))
                items.Add(match.Groups[1].Value);
            string output = String.Join(" ", items);

            WebClient downloadImg = new WebClient();

       
            string[] b = items.ToArray();

            

            string http = "http://";

            string jpg = ".jpg";

            Random rnd = new Random();

            int c = items.Count;

            string location = textBox2.Text;

            progressBar1.Maximum = c;

            for (int i = 0; i < c; i++)
            {
                int name = rnd.Next(2343224, 934534534);
                downloadImg.DownloadFile(http + items[i], location + "/" + name + jpg);
                progressBar1.Value = progressBar1.Value + 1;
            }

                

            Process.Start(@location);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
            }

            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

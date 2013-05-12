using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private HtmlElement flashdoc;
        public const String GAMEHOST = "http://app100645087.qzone.qzoneapp.com/?qz_height=1400&openid=C57315B1BE0C744F34E740A0A836E376&openkey=CD6A6C57748AB3EE211857C09C9FB34D&pf=qzone&pfkey=7db8d5d3290298f74a569660b734ceef&qz_ver=6&appcanvas=1&params=&via=QZ.MYAPP";
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScrollBarsEnabled = false;
            webBrowser1.Visible = false;
        }

        private void start_Click(object sender, EventArgs e)
        {
            count = 0;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(PrintDocument);
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(onProgress);
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(onNavigated);
            webBrowser1.Navigate(GAMEHOST);
        }
        private int count = 0;
        private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            urltxt.AppendText(e.Url.ToString()+"\n");
            count++;
            if (count >= 5) initbroswer();
        }

        private void onNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            urltxt.AppendText(e.Url.ToString() + "\n");
        }

        private void onProgress(object sender, WebBrowserProgressChangedEventArgs e)
        {
            
        }

        private void initbroswer()
        {
            HtmlElementCollection collection = webBrowser1.Document.Body.Children;
            flashdoc = collection[2];
            flashdoc.Children[0].Style = "display:none";
            flashdoc.Children[1].Style = "display:none";
            webBrowser1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "显示导航")
            {
                flashdoc.Children[1].Style = "display:block";
                button1.Text = "隐藏导航";
            }  
            else
            {
                flashdoc.Children[1].Style = "display:none";
                button1.Text = "显示导航";
            }

        }
    }
}

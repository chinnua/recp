using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rep
{
    public partial class View : Form
    {
        private string pdfFileToRender = string.Empty;
        public View(string pdfPath)
        {
            InitializeComponent();
            pdfFileToRender = pdfPath;
        }

        private void View_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigated += WebBrowser1_Navigated;
            webBrowser1.Navigate(pdfFileToRender);

        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            printDialog1.ShowDialog();
        }
    }
}

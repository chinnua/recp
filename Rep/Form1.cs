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

namespace Rep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            

            var fileHtml = File.ReadAllText(Path.Combine(Application.StartupPath, "Template", "Template.html"));
            var filePath = "D:\\Test.pdf";

            fileHtml = fileHtml.Replace("{{amount}}", "1000.00");
            fileHtml = fileHtml.Replace("{{amountinwords}}", Helpers.CurrencyToWords.ConvertToWords("1000.00"));
            fileHtml = fileHtml.Replace("{{name}}", "ABCDEFGH");
            fileHtml = fileHtml.Replace("{{point}}", "Chennai");

            var fileBytes = PdfSharpConvert(fileHtml);
            File.WriteAllBytes(filePath, fileBytes);
            using (View viewForm = new View(filePath))
            {
                viewForm.ShowDialog();
            }

        }

        public static Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
    }
}

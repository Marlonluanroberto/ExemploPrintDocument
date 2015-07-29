using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploPrintDocument
{
    class Program
    {
        private static Font fonte;

        static void Main(string[] args)
        {
            PrintDocument documento = new PrintDocument();
            documento.BeginPrint += documento_BeginPrint;
            documento.EndPrint += documento_EndPrint;
            documento.PrintPage += documento_PrintPage;

            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = documento;
            dialog.ShowDialog();
        }

        static void documento_BeginPrint(object sender, PrintEventArgs e)
        {
            fonte = new Font("Comic Sans", 12);
        }

        static void documento_EndPrint(object sender, PrintEventArgs e)
        {
            fonte.Dispose();
        }

        private static void documento_PrintPage(object sender, PrintPageEventArgs e)
        {
            string titulo = "Relatório do João";

            SizeF tamanho = e.Graphics.MeasureString(titulo, fonte);

            float posicao = (e.MarginBounds.Width / 2) - (tamanho.Width / 2);

            e.Graphics.DrawString(titulo, fonte, new SolidBrush(Color.Black), e.MarginBounds.Left + posicao, e.MarginBounds.Top);
        }
    }
}

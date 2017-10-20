using FilmRanking.BusinessLogic.Providers.Contracts;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;

namespace FilmRanking.BusinessLogic.Providers.Parsers
{
    public class PDFWriter : IWriter
    {
        public void Write(string text)
        {
            iText.IO.Log.NoOpLoggerFactory iTextLoggerFactory = new iText.IO.Log.NoOpLoggerFactory();
            iText.IO.Log.LoggerFactory.BindFactory(iTextLoggerFactory);

            using (PdfWriter writer = new PdfWriter("../../../TextFiles/PDFReport.pdf")) //zachukah go mnogo brutalno tova neshto
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf);
                    doc.Add(new Paragraph(text));
                }
            }
        }
    }
}

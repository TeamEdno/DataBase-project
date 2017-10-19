using FilmRanking.BusinessLogic.Providers.Contracts;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;

namespace FilmRanking.BusinessLogic.Providers.Parsers
{
    public class PDFWriter : IWriter
    {
        public PDFWriter(string address)
        {
            this.Address = address;
        }

        public string Address { get; set; }

        public void Write(string text)
        {
            iText.IO.Log.NoOpLoggerFactory iTextLoggerFactory = new iText.IO.Log.NoOpLoggerFactory();
            iText.IO.Log.LoggerFactory.BindFactory(iTextLoggerFactory);

            using (PdfWriter writer = new PdfWriter(this.Address))
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

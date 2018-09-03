using System;
using System.IO;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using static System.Net.WebRequestMethods;

namespace Pdf2Text
{
	class Program
	{
        ///File = ( "C:\\Users\\egaerik\\Documents\\Macros\\TMO\\SM-377\\PDF Reader\\C02-5445312.pdf");


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main(string[] args)
		{



			DateTime start = DateTime.Now;
			if (args.Length < 2)
			{
				Console.WriteLine("Usage: PDF2TEXT <input filename (PDF)> <output filename (text)>");
                parseUsingPDFBox("C:\\Users\\egaerik\\Documents\\Macros\\TMO\\SM-377\\PDF Reader\\C02-5445312.pdf");
                return;
			}

			using (StreamWriter sw = new StreamWriter(args[1]))
			{
				sw.WriteLine(parseUsingPDFBox(args[0]));
			}

			Console.WriteLine("Done. Took " + (DateTime.Now - start));

            //			Console.ReadLine();

           


        }

		private static string parseUsingPDFBox(string input)
		{
		    PDDocument doc = null;

            try
            {
                doc = PDDocument.load(input);
                PDFTextStripper stripper = new PDFTextStripper();
                Console.WriteLine(stripper.getText(doc));
                return stripper.getText(doc);
            }
            finally
            {
                if (doc != null)
                {
                    doc.close();
                }
            }
		}

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

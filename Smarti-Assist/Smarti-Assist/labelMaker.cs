using iText.Barcodes;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Smarti_Assist.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/*Smart-i Assist -LabelMaker- Version 1.0.0.5
 * Created: 7/6/2020
 * Updated: 7/9/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@metadevdigital.com
 * 
 * Copyright Copyright MIT Liscenece  - Enjoy boys, keep updating without me. Fork to your hearts content
 */


namespace Smarti_Assist
{
    class labelMaker : IDisposable
    {
        private fileManipulator fm;
        public labelMaker() 
        {
            fm = new fileManipulator();
        }


        /// <summary>
        /// Creates a one page label the dimensions of the GX430t label maker on site. (3" x 3" labels)
        /// Takes in a document created by another function to be modular and callable by either a printing or saving action
        /// Handles different formatting options automatically depending on the options selected by the user.
        /// </summary>
        /// <param name="document">The base document that contains the data inside of the pdf</param>
        /// <param name="PDF">Object which contains the document and teaches it how to be one with the PDF</param>
        /// <param name="ark">Provided ark serial number for current iteration</param>
        /// <param name="inj">Provided smart injector serial number for current iteration</param>
        private void createLabel(Document document, PdfDocument PDF, string ark, string inj, bool multiple, int count, int max)
        {
            Style normal = new Style();
            Style header = new Style();
            Style subtext = new Style();
            Style subheadertext = new Style();

            PdfFont nfont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            PdfFont hFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            PdfFont sFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

            normal.SetFont(nfont).SetFontSize(11);
            header.SetFont(hFont).SetFontSize(16);
            subheadertext.SetFont(hFont).SetFontSize(13);
            subtext.SetFont(sFont).SetFontSize(7);

            document.SetMargins(10, 25, 10, 25);

            Table table = new Table(new float[7]).UseAllAvailableWidth();
            table.SetMarginTop(0);
            table.SetMarginBottom(0);

            // Header
            table.AddCell(new Cell(1, 7).Add(new Paragraph("HAT-PROC-0025").AddStyle(header)).SetTextAlignment(TextAlignment.CENTER));

            // Header Subtext
            table.AddCell(new Cell(1, 7).Add(new Paragraph("ARK-1123H with Smart Injector").AddStyle(subtext)).SetTextAlignment(TextAlignment.CENTER).SetPadding(5).SetMaxHeight(10).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(ColorConstants.BLACK, 1)));

            // PC Data Row
            table.AddCell(new Cell(2, 2).Add(new Paragraph("PC:").AddStyle(subheadertext)).SetBorder(Border.NO_BORDER).SetPaddingBottom(10));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Part:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph("HAPC0000088").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Serial:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingTop(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph(ark).AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingTop(0));

            // Injector Data Row
            table.AddCell(new Cell(2, 2).Add(new Paragraph("Injector:").AddStyle(subheadertext)).SetBorder(Border.NO_BORDER).SetPaddingBottom(10));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Part:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph("HAT-HYPR-0287").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Serial:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingTop(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph(inj).AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingTop(0));

            // Data Row
            if (Settings.Default.isChkQR.Equals(true))
            {
                table.AddCell(new Cell(4, 3).Add(new Image(new BarcodeQRCode(ark + " / " + inj).CreateFormXObject(PDF)).SetHeight(70).SetWidth(70)).SetBorder(Border.NO_BORDER).SetPadding(0));
            }
            else
            {
                table.AddCell(new Cell(4, 3).SetBorder(Border.NO_BORDER));
            }

            if (Settings.Default.isChkInj.Equals(true))
            {
                table.AddCell(new Cell(1, 1).Add(new Paragraph("P.O.").AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).Add(new Paragraph(Settings.Default.partorder).AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
            }
            else
            {
                table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).SetBorder(Border.NO_BORDER));
            }

            if (Settings.Default.isChkTech.Equals(true))
            {
                table.AddCell(new Cell(1, 1).Add(new Paragraph("Locale:").AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).Add(new Paragraph("U.S.A.").AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 4).Add(new Paragraph(Settings.Default.technician).AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
            }
            else
            {
                table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 4).SetBorder(Border.NO_BORDER));
            }

            if (Settings.Default.isChkDate.Equals(true))
            {
                table.AddCell(new Cell(1, 4).Add(new Paragraph(DateTime.UtcNow.ToString("MM-dd-yyyy")).AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER).SetPaddingBottom(0));
            }
            /*
             * Handles the case that in the extremely unlikely event that no additional data at all is included on the label,
             * sets the second to last cell to have a set height to allow the footer to still be in the correct position
             */
            else if (Settings.Default.isChkDate.Equals(false) && Settings.Default.isChkInj.Equals(false) && Settings.Default.isChkQR.Equals(false) && Settings.Default.isChkTech.Equals(false))
            {
                table.AddCell(new Cell(1, 4).SetHeight(50).SetBorder(Border.NO_BORDER));
            }
            else
            {
                table.AddCell(new Cell(1, 4).SetBorder(Border.NO_BORDER));
            }

            // Footer
            if(multiple)
            {
                table.AddCell(new Cell(1, 7).Add(new Paragraph("Acrelec America - https://acrelec.com/ - # " + count + " of " + max).AddStyle(subtext)).SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetBorderTop(new SolidBorder(ColorConstants.BLACK, 1)).SetPaddingTop(0));
            }
            else
            {
                table.AddCell(new Cell(1, 7).Add(new Paragraph("Acrelec America - https://acrelec.com/").AddStyle(subtext)).SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetBorderTop(new SolidBorder(ColorConstants.BLACK, 1)).SetPaddingTop(0));
            }
 

            document.Add(table);
        }

        public void printLabels(List<string> lstArkSerials, List<string> lstInjectorSerials)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    using (PdfWriter outWriter = new PdfWriter(stream))
                    {
                        bool multipleCopies = false;
                        PdfDocument outPDF = new PdfDocument(outWriter);

                        //Set to this size because an internet wizard said that it is 1 inch per 72 user units.
                        //I have no idea where this number comes from but it makes something printable for 3"x3"
                        iText.Kernel.Geom.Rectangle labelSize = new iText.Kernel.Geom.Rectangle(0, 0, 216, 216);
                        iText.Layout.Document outDocument = new iText.Layout.Document(outPDF, new PageSize(labelSize));

                        if(Settings.Default.copies>1)
                        {
                            multipleCopies = true;
                        }

                        for (int i = 0; i < lstArkSerials.Count(); i++)
                        {
                            for (int j = 1; j <= Settings.Default.copies; j++)
                            {
                                createLabel(outDocument, outPDF, lstArkSerials.ElementAt(i), lstInjectorSerials.ElementAt(i),multipleCopies,j, Settings.Default.copies);
                            }
                        }

                        outDocument.Close();
                        outPDF.Close();
                        outWriter.Close();

                        byte[] bytes = stream.ToArray();

                        using (var outStream = new MemoryStream(bytes))
                        {
                            using (var document = PdfiumViewer.PdfDocument.Load(outStream))
                            {
                                using (var printDocument = document.CreatePrintDocument())
                                {
                                    using (PrintDialog dialog = new PrintDialog())
                                    {
                                        printDocument.PrinterSettings.PrintFileName = "Smart-i-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".pdf";
                                        printDocument.DocumentName = "Smart-i-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".pdf";
                                        printDocument.PrinterSettings.PrintFileName = "file.pdf";
                                        printDocument.PrintController = new StandardPrintController();
                                        printDocument.PrinterSettings.MinimumPage = 1;
                                        printDocument.PrinterSettings.FromPage = 1;
                                        printDocument.PrinterSettings.ToPage = document.PageCount;
                                        printDocument.DefaultPageSettings.PaperSize = new PaperSize("3 x 3 inches", 300, 300);
                                        dialog.Document = printDocument;
                                        dialog.AllowPrintToFile = true;
                                        dialog.AllowSomePages = true;
                                        if (dialog.ShowDialog() == DialogResult.OK)
                                        {
                                            dialog.Document.Print();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Printer job was cancelled. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Prompts the user with a requested save location for the to-be-generated PDF
        /// Iterates through all elements inside of relevant lists to create the required number of labels inside 
        /// of the PDF document, separated by pages.
        /// </summary>
        /// <param name="lstArkSerials">List of strings, representative of the entered ARK serial numbers</param>
        /// <param name="lstInjectorSerials">List of strings, representative of the entered Injector serial numbers</param>
        public void saveLabels(List<string> lstArkSerials, List<string> lstInjectorSerials)
        {
            try
            {
                using (PdfWriter outWriter = new PdfWriter(fm.choseDirectory() + "/Smart-i-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".pdf"))
                {
                    bool multipleCopies = false;

                    PdfDocument outPDF = new PdfDocument(outWriter);

                    //Set to this size because an internet wizard said that it is 1 inch per 72 user units.
                    //I have no idea where this number comes from but it makes something printable for 3"x3"
                    iText.Kernel.Geom.Rectangle labelSize = new iText.Kernel.Geom.Rectangle(0, 0, 216, 216);
                    iText.Layout.Document outDocument = new iText.Layout.Document(outPDF, new PageSize(labelSize));

                    if (Settings.Default.copies > 1)
                    {
                        multipleCopies = true;
                    }

                    for (int i = 0; i < lstArkSerials.Count(); i++)
                    {
                        for (int j = 1; j <= Settings.Default.copies; j++)
                        {
                            createLabel(outDocument, outPDF, lstArkSerials.ElementAt(i), lstInjectorSerials.ElementAt(i), multipleCopies, j, Settings.Default.copies);
                        }
                    }

                    outDocument.Close();
                    outPDF.Close();
                    outWriter.Close();

                    MessageBox.Show("Your file was successfully exported in your chosen directory as 'Smart-i-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".pdf'", "Success!", MessageBoxButtons.OK);
                }
            }

            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Export was cancelled. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //IDispose Function
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
                ReleaseManagedResources();

            ReleaseUnmanagedResources();
        }

        private void ReleaseManagedResources()
        {
            if(fm != null)
            {
                fm.Dispose();
            }
        }

        private void ReleaseUnmanagedResources()
        {
            //There are none for this class
        }

        ~labelMaker()
        {
            Dispose(false);
        }
    }
}

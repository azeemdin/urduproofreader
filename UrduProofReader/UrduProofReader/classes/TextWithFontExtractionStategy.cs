using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace UrduProofReader.classes
{
    class TextWithFontExtractionStategy : iTextSharp.text.pdf.parser.ITextExtractionStrategy
    {
        private StringBuilder result = new StringBuilder();

        private Vector lastBaseLine;
        private string lastFont;
        private float lastFontSize;

        private enum TextRenderMode
        {
            FillText = 0,
            StrokeText = 1,
            FillThenStrokeText = 2,
            Invisible = 3,
            FillTextAndAddToPathForClipping = 4,
            StrokeTextAndAddToPathForClipping = 5,
            FillThenStrokeTextAndAddToPathForClipping = 6,
            AddTextToPaddForClipping = 7
        }

        public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
        {
            try
            {

                string curFont = renderInfo.GetFont().PostscriptFontName;

                //Check if faux bold is used
                if ((renderInfo.GetTextRenderMode() == (int)TextRenderMode.FillThenStrokeText))
                {
                    curFont += "-Bold";
                }

                //This code assumes that if the baseline changes then we're on a newline
                Vector curBaseline = renderInfo.GetBaseline().GetStartPoint();
                Vector topRight = renderInfo.GetAscentLine().GetEndPoint();
                Vector lastDescentLine = renderInfo.GetDescentLine().GetEndPoint();

                iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(curBaseline[Vector.I1], curBaseline[Vector.I2], topRight[Vector.I1], topRight[Vector.I2]);
                Single curFontSize = rect.Height;
                Gen.FontSize.Add(rect.Height.ToString());
                Gen.RectBottom.Add(rect.Bottom.ToString());

                //See if something has changed, either the baseline, the font or the font size
                if ((this.lastBaseLine == null) || (curBaseline[Vector.I2] != lastBaseLine[Vector.I2]) || (curFontSize != lastFontSize) || (curFont != lastFont))
                {
                    //if we've put down at least one span tag close it
                    if ((this.lastBaseLine != null))
                    {
                        this.result.AppendLine("<=!=>");
                    }

                    /* TO WORK HERE FOR NEW LINE  20-07-2015 */
                    float last = Gen.LastRectBottom - Gen.LastFontSize;
                    if (rect.Bottom < last)
                    {
                        if (Gen.IsLineFeed) this.result.AppendLine("۩");
                    }

                    this.result.AppendFormat("{0}<=;=>{1}<=;=>", curFont, "-");
                }

                //Append the current text
                string currText = renderInfo.GetText();
                if (currText == Gen.LastText && curFont == Gen.LastFont) Gen.LigatureRepeatCount++;
                else Gen.LigatureRepeatCount = 0;

                if (Gen.LigatureRepeatCount == 3)
                {
                    Gen.LigatureRepeatCount = 0;
                    Gen.LastText = String.Empty;
                    Gen.LastFont = String.Empty;
                    //currText += "ᢦ";
                    currText += "۞";
                }

                this.result.Append(currText);

                //Set currently used properties
                this.lastBaseLine = curBaseline;
                this.lastFontSize = curFontSize;
                this.lastFont = curFont;

                Gen.LastFont = curFont;
                Gen.LastText = currText;
                Gen.LastFontSize = curFontSize;
                Gen.LastRectBottom = rect.Bottom;

            }
            catch (Exception ex)
            {
            }
        }

        public string GetResultantText()
        {
            return result.ToString();
        }

        public void BeginTextBlock() { }
        public void EndTextBlock() { }
        public void RenderImage(ImageRenderInfo renderInfo) { }
    }
}

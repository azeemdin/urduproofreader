using System.Windows.Forms;
using System.Drawing;
using System;

namespace UrduProofReader.classes
{
    class GUIUtils
    {
        public static void HighlightText(ref RichTextBox myRtb, string word, Color color)
        {

            if (word == string.Empty)
                return;

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }

        private static bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;

            return true;
        }

        //Or any control
        public static void ToggleStatus(Control c, bool s)
        {
            if (ControlInvokeRequired(c, () => ToggleStatus(c, s))) return;
            c.Enabled = s;
        }

        //Or any control
        public static void UpdateText(Control c, string s)
        {
            if (ControlInvokeRequired(c, () => UpdateText(c, s))) return;
            c.Text = s;
        }

        public static void UpdateProgress(ProgressBar c, int s)
        {
            if (ControlInvokeRequired(c, () => UpdateProgress(c, s))) return;

            c.Increment(s);
        }

        public static void FinishProgress(ProgressBar c)
        {
            if (ControlInvokeRequired(c, () => FinishProgress(c))) return;

            c.Style = ProgressBarStyle.Continuous;
            c.MarqueeAnimationSpeed = 0;
        }
    }
}

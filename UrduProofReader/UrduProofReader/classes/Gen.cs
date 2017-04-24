using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrduProofReader.classes
{
    class Gen
    {
        public static int LigatureRepeatCount = 0;
        public static string LastFont = String.Empty;
        public static string LastText = String.Empty;

        public static float LastFontSize = 0;
        public static float LastRectBottom = 0;

        public static List<string> RectBottom = new List<string>();
        public static List<string> FontSize = new List<string>();
        public static string FirstBoldLigature = String.Empty;

        public static bool IsLineFeed = true;
    }
}

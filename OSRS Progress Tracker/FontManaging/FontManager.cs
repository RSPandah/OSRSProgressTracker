using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Progress_Tracker.FontManaging
{
    class FontManager
    {
        public static Font customFont;
        public static void setFont(float wantedSize)
        {
            PrivateFontCollection _fonts = new PrivateFontCollection();
            byte[] fontData = Resources.runescape_chat_font_regular;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            _fonts.AddMemoryFont(fontPtr, fontData.Length);
            Marshal.FreeCoTaskMem(fontPtr);
            customFont = new Font(_fonts.Families[0], wantedSize);
        }
    }
}

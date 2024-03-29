﻿using MColor = System.Windows.Media.Color;
using DColor = System.Drawing.Color;

namespace BionicleHeroesBingoGUI.Extensions
{
    internal static class ColorConverter
    {
        public static MColor ToMediaColor(this DColor color)
        {
            return MColor.FromArgb(color.A, color.R, color.G, color.B);
        }
        public static DColor ToDrawingColor(this MColor color)
        {
            return DColor.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}

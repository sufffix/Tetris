﻿using System;

namespace Tetris.Core
{
    public static class ExtensionMethods
    {
        public static int RoundUp(this int i, double roundBy)
        {
            return (int)(Math.Ceiling(i / roundBy) * roundBy);
        }
    }

    public static class Utility
    {
        // get centered X for item of frontWidth on background of backWidth
        public static int GetCenteredX(int backWidth, int frontWidth)
        {
            return (backWidth - frontWidth) / 2;
        }

        // convert milliseconds to mm:ss formatting
        public static string TimeToString(double time)
        {
            return TimeSpan.FromMilliseconds(time).ToString("mm':'ss");
        }
    }
}
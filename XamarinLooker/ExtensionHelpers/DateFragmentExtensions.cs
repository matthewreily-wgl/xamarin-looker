﻿using System;
using XamarinLooker.Model;

namespace XamarinLooker.ExtensionHelpers
{
    public static class DateFragmentExtensions
    {
        public static DateTime ToDateTime(this DateFragments fragments)
        {
            return DateTime.ParseExact($"{fragments.Year}-{fragments.Month}-{fragments.Date}", "yyyy-M-d", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
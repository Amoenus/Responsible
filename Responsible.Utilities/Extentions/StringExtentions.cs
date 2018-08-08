﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Responsible.Utilities.Extentions
{
    /// <summary>
    /// Extention Methods for a String
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// Compares two string case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="trim">Trim inputs for comparison, by default it is false</param>
        /// <returns></returns>
        public static bool IsSameAs(this string value, string other, bool trim = false)
        {
            if (value == null && other == null)
            {
                return true;
            }

            if (value == null)
            {
                return false;
            }

            if (other == null)
            {
                return false;
            }

            return trim
                ? string.Equals(value.Trim(), other.Trim(), StringComparison.CurrentCultureIgnoreCase)
                : string.Equals(value, other, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares two string case sensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsExactlySameAs(this string value, string other)
        {
            if (value == null && other == null)
            {
                return true;
            }

            if (value == null)
            {
                return false;
            }

            if (other == null)
            {
                return false;
            }

            return value.Equals(other);
        }

        /// <summary>
        /// Checks if IEnumerable of <see cref="string"/> contains the given item
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchText"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool ContainsText(this IEnumerable<string> value, string searchText, bool caseSensitive = false)
        {
            if (value == null)
            {
                return false;
            }

            return caseSensitive
                ? value.Any(s => s.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                : value.Any(s => s.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        /// <summary>
        /// Get a count of <see cref="string"/> in an IEnumerable
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchText"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static int ContainsTextCount(this IEnumerable<string> value, string searchText, bool caseSensitive = false)
        {
            if (value == null)
            {
                return 0;
            }

            return caseSensitive
                ? value.Count(s => s.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                : value.Count(s => s.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }
    }
}
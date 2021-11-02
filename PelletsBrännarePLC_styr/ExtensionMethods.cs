using System;
/*
#pragma warning disable 1685
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method |
    AttributeTargets.Class | AttributeTargets.Assembly)]
    public sealed class ExtensionAttribute : Attribute
    {
    }
}
*/
namespace System.Text
{
    public static class StringBuilderExtensions
    {
        public static bool TryGetSubstringBetween(this StringBuilder thisStringBuilder, string startString, string endString, out string subString)
        {
            subString = null;
            if (startString.Length == 0)
                throw new Exception("StringBuilder.TryGetSubstringBetween: startString Length cannot be zero!!!");
            else if (endString.Length == 0)
                throw new Exception("StringBuilder.TryGetSubstringBetween: endString Length cannot be zero!!!");


            int startIndex, endIndex;

            if (thisStringBuilder.Not_Contains(startString, out startIndex))
                return false;

            if (thisStringBuilder.Not_Contains(endString, startIndex+startString.Length, out endIndex))
                return false;

            startIndex += startString.Length;

            subString = thisStringBuilder.SubstringBetween_Inclusive(startIndex, endIndex-1);
            thisStringBuilder = thisStringBuilder.Remove(0, endIndex + endString.Length);
            return true;
        }

        public static bool TryGetSubstringTo(this StringBuilder thisStringBuilder, string endString, out string subString)
        {
            subString = null;
            
            if (endString.Length == 0)
                throw new Exception("StringBuilder.TryGetSubstringBetween: endString Length cannot be zero!!!");


            int indexOf;

            if (thisStringBuilder.Not_Contains(endString, out indexOf))
                return false;

            subString = thisStringBuilder.SubstringBetween_Inclusive(0, indexOf-1);
            thisStringBuilder = thisStringBuilder.Remove(0, indexOf + endString.Length);
            return true;
        }
        public static bool Not_Contains(this StringBuilder thisStringBuilder, string value, int startIndex, out int indexOf)
        {
            for (indexOf = startIndex; indexOf < thisStringBuilder.Length; indexOf++)
            {
                if (thisStringBuilder.StartsWith(value, indexOf))
                {
                    thisStringBuilder = null;
                    return false;
                }
            }
            thisStringBuilder = null;
            return true;
        }
        public static bool Not_Contains(this StringBuilder thisStringBuilder, string value, out int indexOf)
        {
            for (indexOf = 0; indexOf < thisStringBuilder.Length; indexOf++)
            {
                if (thisStringBuilder.StartsWith(value, indexOf))
                {
                    thisStringBuilder = null;
                    return false;
                }
            }
            thisStringBuilder = null;
            return true;
        }
        public static bool Contains(this StringBuilder thisStringBuilder, string value, int startIndex, out int indexOf)
        {
            for (indexOf = startIndex; indexOf < thisStringBuilder.Length; indexOf++)
            {
                if (thisStringBuilder.StartsWith(value, indexOf))
                {
                    thisStringBuilder = null;
                    return true;
                }
            }
            thisStringBuilder = null;
            return false;
        }
        public static bool Contains(this StringBuilder thisStringBuilder, string value, out int indexOf)
        {
            for (indexOf = 0; indexOf < thisStringBuilder.Length; indexOf++)
            {
                if (thisStringBuilder.StartsWith(value, indexOf))
                {
                    thisStringBuilder = null;
                    return true;
                }
            }
            thisStringBuilder = null;
            return false;
        }
        public static string SubstringBetween_Inclusive(this StringBuilder thisStringBuilder, int startIndex, int endIndex)
        {
            char[] subString = new char[endIndex - startIndex + 1];

            for (int i = 0; (startIndex <= endIndex); i++)
            {
                subString[i] = thisStringBuilder[startIndex++];
            }
            return new string(subString);
        }
        public static bool StartsWith(this StringBuilder thisStringBuilder, string value, int startIndex)
        {
            if (value.Length + startIndex > thisStringBuilder.Length)
                return false;

            int vi = 0;
            int value_Length = value.Length;
            int thisStringBuilder_Length = thisStringBuilder.Length;

            for (int i = startIndex; i < thisStringBuilder_Length; i++)
            {
                if (thisStringBuilder[i] != value[vi])
                {
                    thisStringBuilder = null;
                    return false;
                }
                if (++vi == value_Length)
                {
                    thisStringBuilder = null;
                    return true;
                }
            }
            thisStringBuilder = null;
            return false;
        }
        public static string ToAsciiHex(this byte thisByte)
        {
            return thisByte.ToString("x2").ToUpper();
        }

        /// <summary>
        /// Append the "individual bytes" converted to "individual chars", the null byte is allways converted to a "<0>"-string
        /// </summary>
        /// <param name="byteArray">the byte array to get data from</param>
        /// <param name="byteCount">
        ///     <para>Defines how many bytes to be used to create the string.</para>
        ///     <para>* If it's 0 or -1, nothing is appended.</para>
        ///     <para>* If it's bigger than byteArray.Length or -2, the byteArray.Length is used instead.</param>
        /// <param name="AppendNonVisibleCharsRaw">if set to TRUE this overrides both AppendNonVisibleCharsAsHex and Append_Cr_AndOr_Lf_AsHex</param>
        /// <param name="Append_Cr_AndOr_Lf_AsHex">if any occurence of 0x0A and 0x0B is found this overrides AppendNonVisibleCharsAsHex</param>
        /// <param name="AppendNonVisibleCharsAsHex"></param>
        /// <returns></returns>
        public static void AppendAsChars(this StringBuilder thisStringBuilder, byte[] byteArray, int byteCount, bool AppendNonVisibleCharsRaw, bool Append_Cr_AndOr_Lf_AsHex, bool AppendNonVisibleCharsAsHex)
        {
            if (byteCount == 0)
                return;
            else if (byteCount == -1)
                return;

            byte bTmp;

            if (byteCount > byteArray.Length)
                byteCount = byteArray.Length;
            else if (byteCount == -2)
                byteCount = byteArray.Length;

            for (int i = 0; i < byteCount; i++)
            {
                bTmp = byteArray[i];

                if (((bTmp >= 0x20) && (bTmp <= 0x7F)) || AppendNonVisibleCharsRaw) // display non ASCI chars in hex
                {
                    if (bTmp != 0)
                        thisStringBuilder.Append(Convert.ToChar(bTmp));
                    else
                        thisStringBuilder.Append("<0>"); // allways show null as hex (because null the termination char in a string) 
                }
                else
                {
                    if (AppendNonVisibleCharsAsHex)
                    {
                        if (bTmp == 0x0A || bTmp == 0x0D)
                        {
                            if (Append_Cr_AndOr_Lf_AsHex)
                                thisStringBuilder.Append("<" + bTmp.ToAsciiHex() + ">");
                            else
                                thisStringBuilder.Append(Convert.ToChar(bTmp));
                        }
                        else
                            thisStringBuilder.Append("<" + bTmp.ToAsciiHex() + ">");
                    }
                    else if (bTmp == 0x0A || bTmp == 0x0D)
                    {
                        if (Append_Cr_AndOr_Lf_AsHex)
                            thisStringBuilder.Append("<" + bTmp.ToAsciiHex() + ">");
                        else
                            thisStringBuilder.Append(Convert.ToChar(bTmp));
                    }
                }
            }
        }
    }
}
namespace Microsoft.Win32
{
    using System;
    public static class MicrosanExtensions
    {
        private static Action<string> RegistryIO_Error_Action = null;

        public static void SetErrorOccurred_Action(this RegistryKey thisRegistryKey, Action<string> method)
        {
            RegistryIO_Error_Action = method;
        }
        public static bool TryGetRegKeyNamesAndValues(this RegistryKey thisRegistryKey, out string[] names, out string[] values)
        {
            try
            {
                if (thisRegistryKey != null)
                {
                    names = thisRegistryKey.GetValueNames();
                    values = new string[names.Length];
                    for (int i = 0; i < names.Length; i++)
                    {
                        values[i] = (string)thisRegistryKey.GetValue(names[i]);
                    }
                    return true;
                }
                else
                {
                    names = null;
                    values = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (RegistryIO_Error_Action != null)
                    RegistryIO_Error_Action(ex.ToString());
                names = null;
                values = null;
                return false;
            }
        }
    }
}
namespace System
{
    using System.Text.RegularExpressions;
    using System.Text; // for string builder
    using System.Drawing;

    public enum QuotedStringType
    {
        None,
        SingleQuote,
        DoubleQuote
    }

    public static class MicrosanExtensions1
    {
        private static string[] NewLineTypes = null;
        public static char[] XML_VALUE_ENCLOSERS = new char[] { '\'', '\"' };

        public static int TotalTextLength(this string[] thisStringArray, bool includeCrLf)
        {
            int t = 0;
            for (int i = 0; i < thisStringArray.Length; i++)
                t += thisStringArray[i].Length;
            if (includeCrLf)
                t += (thisStringArray.Length * 2);
            return t;
        }

        #region // Xml Helper Extensions
        //********************************************************************************************************************************
        public static bool TryGetQuotedString(this string thisString, int startIndex, out char quote, out int leadingQuoteIndex, out int endingQuoteIndex, out string quotedString)
        {
            if (!thisString.TryGetIndexOfAny(MicrosanExtensions1.XML_VALUE_ENCLOSERS, startIndex, out leadingQuoteIndex, out quote))
            {
                endingQuoteIndex = -1;
                quotedString = null;
                return false;
            }
            if (!thisString.TryGetIndexOf(quote, leadingQuoteIndex + 1, out endingQuoteIndex))
            {
                quotedString = null;
                return false;
            }
            quotedString = thisString.SubstringBetween(leadingQuoteIndex + 1, endingQuoteIndex - 1);
            return true;
        }
        public static bool TryGetQuotedString(this string thisString, ref int currentIndex, out string quotedString, bool includeQuotes)
        {
            int leadingQuoteIndex = -1;
            int endingQuoteIndex = -1;
            char quote = ' ';
            if (!thisString.TryGetIndexOfAny(MicrosanExtensions1.XML_VALUE_ENCLOSERS, currentIndex, out leadingQuoteIndex, out quote))
            {
                endingQuoteIndex = -1;
                quotedString = null;
                return false;
            }
            if (!thisString.TryGetIndexOf(quote, leadingQuoteIndex + 1, out endingQuoteIndex))
            {
                quotedString = null;
                currentIndex = leadingQuoteIndex + 1;
                return false;
            }
            if (includeQuotes)
                quotedString = thisString.SubstringBetween(leadingQuoteIndex, endingQuoteIndex);
            else
                quotedString = thisString.SubstringBetween(leadingQuoteIndex + 1, endingQuoteIndex - 1);
            currentIndex = endingQuoteIndex + 1;
            return true;
        }
        public static bool TryGetLastMatchedQuoteIndex(this string thisString, int currentIndex, out int lastIndex)
        {
            int leadingQuoteIndex = -1;
            char quote = ' ';
            if (!thisString.TryGetIndexOfAny(MicrosanExtensions1.XML_VALUE_ENCLOSERS, currentIndex, out leadingQuoteIndex, out quote))
            {
                lastIndex = -1;
                return false;
            }
            if (!thisString.TryGetIndexOf(quote, leadingQuoteIndex + 1, out lastIndex))
            {
                return false;
            }
            return true;
        }
        //********************************************************************************************************************************
        #endregion // Xml Helper Extensions

        #region // Check related methods (Equals, Contains, StartsWith, ...)
        //********************************************************************************************************************************
        public static bool IsEqualAnyOf(this char thisChar, string characters)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (thisChar == characters[i])
                    return true;
            }
            return false;
        }
        public static bool IsQuote(this char thisChar)
        {
            return ((thisChar == '\'') || (thisChar == '\"'));
        }
        public static bool Equals(this string thisString, string value, bool IgnoreCase, bool trim)
        {
            return (thisString.Adjust(IgnoreCase, trim) == value.Adjust(IgnoreCase, trim));
        }
        public static bool Contains(this string thisString, string value, bool IgnoreCase, bool trim)
        {
            return thisString.Adjust(IgnoreCase, trim).Contains(value.Adjust(IgnoreCase, trim));
        }
        public static bool StartsWith(this string thisString, string value, int startIndex)
        {
            if (value.Length + startIndex > thisString.Length)
                return false;

            int vi = 0;
            int value_Length = value.Length;
            int thisString_Length = thisString.Length;

            for (int i = startIndex; i < thisString_Length; i++)
            {
                if (thisString[i] != value[vi])
                    return false;

                if (++vi == value.Length)
                    return true;
            }
            return false;
        }
        public static bool StartsWith(this string thisString, string value, bool IgnoreCase, bool trim)
        {
            return thisString.Adjust(IgnoreCase, trim).StartsWith(value.Adjust(IgnoreCase, trim));
        }
        public static bool NextCharEqualsTo(this string str, char comp, int strLength, int currentIndex)
        {
            currentIndex++;
            if (currentIndex != strLength) return false;
            if (str[currentIndex] == comp) return true;
            return false;
        }
        public static bool StartsWithAny(this string thisString, char[] values)
        {
            if (thisString.IsNullOrEmpty(false))
                return false;
            for (int i = 0; i < values.Length; i++)
            {
                if (thisString[0] == values[i])
                    return true;
            }
            return false;
        }
        public static bool StartsWithAny(this string thisString, string[] values)
        {
            if (thisString.IsNullOrEmpty(false))
                return false;
            bool currentEqual = true;
            for (int i = 0; i < values.Length; i++)
            {
                if (thisString.Length < values[i].Length)
                    continue;
                currentEqual = true;
                for (int i2 = 0; i2 < values[i].Length; i2++)
                {
                    if (thisString[i2] != values[i][i2])
                    {
                        currentEqual = false;
                        break;
                    }
                }
                if (currentEqual)
                    return true;
            }
            return false;
        }
        public static bool IsEmpty(this string thisString, bool trimWhiteSpace)
        {
            if (trimWhiteSpace)
                return thisString.ContainsWhiteSpaceOnly();
            else
                return (thisString.Length == 0);
        }
        public static bool IsNullOrEmpty(this object thisObject, bool trimWhiteSpace)
        {
            if (thisObject == null) return true;
            if (thisObject.GetType().ToString() == "System.DBNull") return true;

            return thisObject.ToString().IsEmpty(trimWhiteSpace);
        }
        public static bool IsNumber(this char thisChar)
        {
            return (thisChar >= '0' && thisChar <= '9');
        }
        public static bool IsDot(this char thisChar)
        {
            return (thisChar == '.');
        }
        public static bool Contains(this string[] thisStringArray, string value, bool IgnoreCase, bool trim)
        {
            for (int i= 0; i < thisStringArray.Length; i++)
            {
                if (thisStringArray[i].Equals(value, IgnoreCase, trim))
                    return true;
            }
            return false;
        }
        //********************************************************************************************************************************
        #endregion

        #region // (Try) Get Index related methods
        //********************************************************************************************************************************
        public static bool TryGetIndexOfAny(this string thisString, char[] values, int startIndex, out int indexOf, out char value)
        {
            for (int vi = 0; vi < values.Length; vi++)
            {
                indexOf = thisString.IndexOf(values[vi], startIndex);
                if (indexOf != -1)
                {
                    value = values[vi];
                    return true;
                }
            }
            value = '\0';
            indexOf = -1;
            return false;
        }
        public static bool TryGetIndexOf(this string thisString, char value, int startIndex, out int indexOf)
        {
            indexOf = thisString.IndexOf(value, startIndex);
            if (indexOf != -1)
                return true;
            return false;
        }
        public static bool TryGetIndexOf(this string thisString, char value, out int index)
        {
            index = thisString.IndexOf(value);
            return (index != -1);
        }
        public static bool TryGetIndexOf(this string thisString, string value, out int index)
        {
            index = thisString.IndexOf(value);
            return (index != -1);
        }
        public static bool TryGetIndexOfAsString(this object[] thisObjectArray, string value, bool IgnoreCase, bool trim, out int index)
        {
            for (index = 0; index < thisObjectArray.Length; index++)
            {
                if (thisObjectArray[index].ToString().Equals(value, IgnoreCase, trim))
                    return true;
            }
            index = -1;
            return false;
        }
        public static int GetIndexOfAsString(this object[] thisObjectArray, string value, bool IgnoreCase, bool trim)
        {
            for (int index = 0; index < thisObjectArray.Length; index++)
            {
                if (thisObjectArray[index].ToString().Equals(value, IgnoreCase, trim))
                    return index;
            }
            return -1;
        }
        public static bool TryGetIndexOfStartsWithAsString(this object[] thisObjectArray, string value, bool IgnoreCase, bool trim, out int index)
        {
            for (index = 0; index < thisObjectArray.Length; index++)
            {
                if (thisObjectArray[index].ToString().Equals(value, IgnoreCase, trim))
                    return true;
            }
            index = -1;
            return false;
        }
        public static bool TryGetIndexOfContainsAsString(this object[] thisObjectArray, string value, bool IgnoreCase, bool trim, out int index)
        {
            for (index = 0; index < thisObjectArray.Length; index++)
            {
                if (thisObjectArray[index].ToString().Contains(value, IgnoreCase, trim))
                    return true;
            }
            index = -1;
            return false;
        }
        public static bool TryGetIndexOfFirstData(this object[] thisObjectArray, out int index)
        {
            for (index = 0; index < thisObjectArray.Length; index++)
            {
                if (!thisObjectArray[index].IsNullOrEmpty(true))
                    return true;
            }
            index = -1;
            return false;
        }
        //********************************************************************************************************************************
        #endregion  // (Try) Get Index related methods

        #region // Modifying related methods
        //********************************************************************************************************************************
        public static string Adjust(this string thisString, bool toLower, bool trim)
        {
            if (toLower && !trim)
                return thisString.ToLower();
            if (!toLower && trim)
                return thisString.Trim();
            if (toLower && trim)
                return thisString.Trim().ToLower();
            return thisString;
        }
        public static string RemoveIgnoreCase(this string thisString, string value)
        {
            int indexOf;
            value = value.ToLower();
            while (true)
            {
                indexOf = thisString.ToLower().IndexOf(value);
                if (indexOf == -1)
                    return thisString;
                thisString = thisString.Remove(indexOf, value.Length);
            }

        }
        public static string ReplaceAnyKindOfLineBreak(this string value, string replacement)
        {
            return Regex.Replace(value, @"\r\n?|\n", replacement);
        }
        public static string RemoveAnyKindOfLineBreak(this string value)
        {
            return Regex.Replace(value, @"\r\n?|\n", String.Empty);
        }
        public static void AllToLower(this string[] thisStringArray)
        {
            for (int i = 0; i < thisStringArray.Length; i++)
            {
                thisStringArray[i] = thisStringArray[i].ToLower();
            }
        }
        //********************************************************************************************************************************
        #endregion // Modifying related methods

        #region // Split related methods
        //********************************************************************************************************************************
        /// <summary> This splits the string, by any kind of 'newline' and in the following order:
        /// <para> CR+LF (Windows)</para>
        /// <para> LF (Unix based systems)</para>
        /// <para> CR (Unix based systems)</para>
        /// <para> 'LF'='0x0A'='\n'</para>
        /// <para> 'CR'='0x0D'='\r'</para>
        /// </summary>
        /// <param name="removeEmptyEntries">The return value does not include array elements that contain an empty string.</param>
        /// <param name="trimCharacters"></param>
        /// <returns></returns>
        public static string[] SplitByNewLines(this string value, bool removeEmptyLines, bool removeWhiteSpaceLines)
        {
            if (NewLineTypes == null) NewLineTypes = new string[] { "\r\n", "\n", "\r" };

            if (!removeEmptyLines)
                return value.Split(NewLineTypes, StringSplitOptions.None);
            else if (removeEmptyLines && !removeWhiteSpaceLines)
                return value.Split(NewLineTypes, StringSplitOptions.RemoveEmptyEntries);
            // else if (removeEmptyEntries && removeWhiteSpaceLines)
            // then:

            System.Collections.Generic.List<string> vl = new System.Collections.Generic.List<string>(value.Split(NewLineTypes, StringSplitOptions.RemoveEmptyEntries));
            for (int i = (vl.Count - 1); i > 0; i--)
            {
                if (vl[i].IsNullOrEmpty(true)) vl.RemoveAt(i);
            }
            return vl.ToArray();
        }
        /// <summary> Trying: splitting string into two string by (first occurrence of 'CharValue'), not including the 'CharValue' in the resulting strings. </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TrySplit(this string thisString, char CharValue, out string firstString, out string secondString)
        {
            int indexOf = thisString.IndexOf(CharValue);

            if (indexOf == -1)
            {
                firstString = null;
                secondString = null;
                return false;
            }
            firstString = thisString.Substring(0, indexOf);
            secondString = thisString.Substring(indexOf + 1);
            return true;
        }
        /// <summary> Trying: splitting string into two string by (first occurrence of 'StringValue'), not including the 'StringValue' in the resulting strings. </summary>
        /// <param name="thisString"></param>
        /// <param name="StringValue"></param>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public static bool TrySplit(this string thisString, string StringValue, out string firstString, out string secondString)
        {
            int indexOf = thisString.IndexOf(StringValue);

            if (indexOf == -1)
            {
                firstString = null;
                secondString = null;
                return false;
            }
            firstString = thisString.Substring(0, indexOf);
            secondString = thisString.Substring(indexOf + StringValue.Length);
            return true;
        }
        //********************************************************************************************************************************
        #endregion // Split related methods

        #region // Convert (from one format to annother) related methods
        //********************************************************************************************************************************

        ///<!-- the <para> makes the text appear on newline in the XML comment-->
        /// <summary>
        /// <para>-------------------------------------------</para>
        /// This removes/replaces all kind of linebreaks in a string
        /// <para>but in the same way preserves the sentence newline breaks
        /// by puttin an additional space instead of 'the removed newline'</para>
        /// <para>soatextdon'tbecomelikethis (if there where linebreaks between each word).</para>
        /// <para>the rules to do it:</para>
        /// <para>1. the sentence before 'the newline' don't ends  with a space.</para>
        /// <para>2. the sentence after  'the newline' don't start with a space.</para>
        /// <para>-------------------------------------------</para>
        /// <para>the newlines are replaced in the following order:</para>
        /// <para> 1. removes all CR+LF (Windows)</para>
        /// <para> 2. removes all LF (Unix based systems)</para>
        /// <para> 3. removes all CR (Unix based systems)</para>
        /// <para> 'LF'='0x0A'='\n'</para>
        /// <para> 'CR'='0x0D'='\r'</para>
        /// </summary>
        /// <returns>formatted human readable text</returns>
        public static string ConvertToOneLineText(this string value)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = value.SplitByNewLines(true, true);

            sb.Append(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i - 1].EndsWith(" ") || lines[i].StartsWith(" "))
                    sb.Append(lines[i]); // don't add additional space
                else
                    sb.Append(lines[i] + " "); // add additional space
            }


            return sb.ToString(); // note only a reference to the final string is returned here.
        }
        /// <summary>
        /// Get bytes using System.Buffer.BlockCopy method
        /// </summary>
        /// <param name="thisString"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this string thisString)
        {
            byte[] bytes = new byte[thisString.Length * sizeof(char)];
            System.Buffer.BlockCopy(thisString.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        public static string ToString(this object[] thisObjectArray, string seperator)
        {
            string strOut = "";
            for (int i = 0; i < thisObjectArray.Length; i++)
            {
                strOut += thisObjectArray[i].ToString();
                if (i < thisObjectArray.Length - 1)
                    strOut += seperator;
            }
            return strOut;
        }
        public static string[] ToStringArray(this object[] thisObjectArray)
        {
            string[] stringArray = new string[thisObjectArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                stringArray[i] = thisObjectArray[i].ToString();
            return stringArray;
        }
        public static bool TryParseToBool(this string thisString, out bool value)
        {
            thisString = thisString.ToLower().Trim();

            if (thisString == "true") value = true;
            else if (thisString == "t") value = true;
            else if (thisString == "1") value = true;
            else if (thisString == "yes") value = true;
            else if (thisString == "y") value = true;
            else if (thisString == "false") value = false;
            else if (thisString == "f") value = false;
            else if (thisString == "0") value = false;
            else if (thisString == "no") value = false;
            else if (thisString == "n") value = false;
            else
            {
                value = false;
                return false;
            }
            return true;
        }
        /// <summary>
        /// <para>converts string value "true","t","1","yes","y" to boolean type true</para>
        /// <para>converts string value "false","f","0","no","n" to boolean type true</para>
        /// <para>note. the string input is case independent.</para>
        /// </summary>
        /// <param name="thisString"></param>
        /// <returns>returns true only if the input string matches one of the true strings</returns>
        public static bool TryParseToBool(this string thisString)
        {
            bool dummy;
            thisString.TryParseToBool(out dummy);
            return dummy;
        }
        public static bool ConvertFromByteAsciiHex(this string thisString, int startIndex, int endIndex, out string outString)
        {
            outString = "";

            if (!thisString.ValidateIndexes(startIndex, endIndex, 2))
                return false;

            for (int i = startIndex; i < endIndex; i += 2)
            {
                String hs = string.Empty;

                hs = thisString.Substring(i, 2);

                if (hs.ConvertOne_TwoCharHexString2AsciiString(true, true, out hs))
                {
                    outString += hs;
                }
            }
            return true;
        }
        public static bool ConvertFromByteAsciiHex(this string thisString, int startIndex, int endIndex, out byte[] byteArray)
        {
            if (!thisString.ValidateIndexes(startIndex, endIndex, 2))
            {
                byteArray = null;
                return false;
            }
            byteArray = new byte[(endIndex - startIndex) / 2];
            int bi = 0;
            string hs = "";
            try
            {
                for (int i = startIndex; i < endIndex; i += 2)
                {
                    hs = thisString.Substring(i, 2);
                    byteArray[bi++] = System.Convert.ToByte(hs, 16);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool ConvertFromByteAsciiHex(this string thisString, int startIndex, int endIndex, out int[] byteArray)
        {
            if (!thisString.ValidateIndexes(startIndex, endIndex, 2))
            {
                byteArray = null;
                return false;
            }
            byteArray = new int[(endIndex - startIndex) / 2];
            int bi = 0;
            string hs = "";
            try
            {
                for (int i = startIndex; i < endIndex; i += 2)
                {
                    hs = thisString.Substring(i, 2);
                    byteArray[bi++] = (int)System.Convert.ToByte(hs, 16);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool ConvertFrom2ByteAsciiHex(this string thisString, int startIndex, int endIndex, out int[] intArray)
        {
            if (!thisString.ValidateIndexes(startIndex, endIndex, 4))
            {
                intArray = null;
                return false;
            }
            intArray = new int[(endIndex - startIndex) / 4];
            int bi = 0;
            string hs = "";
            try
            {
                for (int i = startIndex; i < endIndex; i += 4)
                {
                    hs = thisString.Substring(i, 4);
                    intArray[bi++] = System.Convert.ToInt32(hs, 16);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static byte Calculate_LR_Checksum(this byte[] thisByteArray)
        {
            byte lrcs = 0;
            for (int i = 0; i < thisByteArray.Length; i++)
            {
                lrcs += thisByteArray[i];
            }
            return (byte)((lrcs ^ (byte)0xFF) + (byte)1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisString"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="divideRangeBy">the check that is performed using this is: (endIndex - startIndex) % divideRangeBy != 0
        /// <para>if not used set this to 1 but never to zero (then you get divide by zero exception)</para></param>
        /// <returns></returns>
        public static bool ValidateIndexes(this string thisString, int startIndex, int endIndex, int divideRangeBy)
        {
            if (startIndex >= thisString.Length)
                return false;
            if (endIndex > thisString.Length)
                return false;
            if (startIndex >= endIndex)
                return false;
            if ((endIndex - startIndex) % divideRangeBy != 0)
                return false;
            return true;
        }

        public static bool ConvertOne_TwoCharHexString2AsciiString(this string thisString, bool convertCr_0D, bool convertLf_0A, out string outString)
        {
            if (thisString.Length != 2)
            {
                outString = "(thisString.Length != 2) you need a string containing two hex chars for this to work!";
                return false;
            }
            outString = "";
            try
            {
                uint decval = System.Convert.ToUInt32(thisString, 16);

                if (decval == 0x0A)
                {
                    if (convertLf_0A)
                        outString = "\n";
                }
                else if (decval == 0x0D)
                {
                    if (convertCr_0D)
                        outString = "\r";
                }
                else if (decval == 0x1F)
                {
                    outString = System.Convert.ToChar(0x2588).ToString(); // fullblock char
                }
                else if (decval != 0x00)
                    outString = System.Convert.ToChar(decval).ToString();
            }
            catch (Exception ex)
            {
                outString = ex.ToString();
                return false;
            }
            return true;
        }
        //********************************************************************************************************************************
        #endregion // Convert (from one format to annother) related methods

        #region // WhiteSpace related methods
        //********************************************************************************************************************************
        /// <summary> This method trim all string entries in the array. </summary>
        /// <param name="thisStringList"></param>
        public static void TrimAll(this string[] thisStringArray)
        {
            for (int i = 0; i < thisStringArray.Length; i++)
            {
                thisStringArray[i] = thisStringArray[i].Trim();
            }
        }
        public static int TrimmedLength(this string str)
        {
            return str.Trim().Length;
        }
        public static void SkipToNonSpace(this string thisString, ref int index)
        {
            while (index < thisString.Length)
            {
                if (thisString[index] != ' ') // skip additional spaces
                    return;
                index++;
            }
        }
        public static int CountLeadingSpaces(this string thisString)
        {
            int c = 0;
            while (c < thisString.Length)
            {
                if (thisString[c] != ' ') // skip additional spaces
                    break;
                c++;
            }
            return c;
        }
        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
        public static bool NotWhiteSpace(char chr)
        {
            if (chr == ' ') return false;
            if (chr == '\t') return false;
            return true;
        }
        public static bool ContainsWhiteSpaceOnly(this string value)
        {
            int strLength = value.Length;
            for (int i = 0; i < strLength; i++)
            {
                if (NotWhiteSpace(value[i])) return false;
            }
            return true;
        }
        public static bool ContainsWhiteSpaceOnly(this string value, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (NotWhiteSpace(value[i])) return false;
            }
            return true;
        }
        /// <summary> Replaces each tab with only one space. </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceTabsWithSpaces(this string value)
        {
            return value.Replace('\t', ' ');
        }
        /// <summary> Replaces each tab with number spaces. </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceTabWithSpaces(this string value, int spaces)
        {
            return value.Replace("\t", new String(' ', spaces));
        }
        //********************************************************************************************************************************
        #endregion // WhiteSpace related methods

        #region // (Try) Get Substring extensions
        //********************************************************************************************************************************
        public static bool GetNextSubString(this string str, int startIndex, int endIndex, out string subString)
        {
            subString = null;
            if (startIndex > endIndex) // empty string line
            {
                return false;
            }
            // not empty string line
            if (str.ContainsWhiteSpaceOnly(startIndex, endIndex))
            {
                return false;
            }
            subString = str.SubstringBetween(startIndex, endIndex);

            return true;
        }
        /// <summary> This extracts the string between first and last index, the character at last index is included. </summary>
        /// <param name="value"></param>
        /// <param name="firstIndex"></param>
        /// <param name="lastIndex"></param>
        /// <returns></returns>
        public static string SubstringBetween(this string value, int firstIndex, int lastIndex)
        {
            return value.Substring(firstIndex, lastIndex - firstIndex + 1);
        }
        /// <summary> Trying: get (start to first occurrence of 'StringValue')-substring, not including the 'value' </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringTo(this string thisString, string value, out string subString, out int indexOf)
        {
            indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(0, indexOf);
            return true;
        }
        /// <summary> Trying: get (start to first occurrence of 'CharValue')-substring, not including the 'value' </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringTo(this string thisString, char value, out string subString, out int indexOf)
        {
            indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(0, indexOf);
            return true;
        }
        /// <summary> Trying: get (first occurrence of 'StringValue' to end)-substring, not including the 'value' </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringFrom(this string thisString, string value, out string subString, out int indexOf)
        {
            indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(indexOf + value.Length);
            return true;
        }
        /// <summary> Trying: get (first occurrence of 'CharValue' to end)-substring, not including the 'value'</summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringFrom(this string thisString, char value, out string subString, out int indexOf)
        {
            indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(indexOf + 1);
            return true;
        }
        /// <summary> Trying: get (start to first occurrence of 'StringValue')-substring, not including the 'value' </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringTo(this string thisString, string value, out string subString)
        {
            int indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(0, indexOf);
            return true;
        }
        /// <summary> Trying: get (start to first occurrence of 'CharValue')-substring, not including the 'value' </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringTo(this string thisString, char value, out string subString)
        {
            int indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(0, indexOf);
            return true;
        }
        /// <summary> Trying: get (first occurrence of 'StringValue' to end)-substring, not including the 'value' </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringFrom(this string thisString, string value, out string subString)
        {
            int indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(indexOf + value.Length);
            return true;
        }
        /// <summary> Trying: get (first occurrence of 'CharValue' to end)-substring, not including the 'value' </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringFrom(this string thisString, char value, out string subString)
        {
            int indexOf = thisString.IndexOf(value);

            if (indexOf == -1)
            {
                subString = null;
                return false;
            }
            subString = thisString.Substring(indexOf + 1);
            return true;
        }
        //********************************************************************************************************************************
        #endregion // (Try) Get Substring extensions

        /*
        private void updateLineCount(int newcount)
        {
            if (TextLines != null)
            {
                string[] lines = new string[newcount];

                for (int i = 0; (i < lines.Length) && (i < TextLines.Length); i++)
                    lines[i] = TextLines[i];
                TextLines = lines;
            }
            else
            {
                string[] textLines = new string[newcount];

                for (int i = 0; (i < textLines.Length); i++)
                    textLines[i] = "";
            }
        }
        */

        /*
		private void SplitStrArray2CharArray(string[] str, char[,] CharsInNthLine)
		{
			for(LineNumber = 0;LineNumber  < numOfLines; LineNumber++)
			{
				char[] Temp =  str[LineNumber].ToCharArray();
				for(int j = 0; j < Temp.Length; j++)
				{
					CharsInNthLine[j,LineNumber]= Temp[j];
				}
			}
		}

        private void SplitStr2CharArray(string str, char[,] CharsInNthLine)
        {
            int sci = 0; // str char index
            int li = 0; // line index
            int ci = 0; // col index
            
            while (sci < str.Length)
            {
                CharsInNthLine[ci++, li] = str[sci++];

                if (ci == charsPerLine)
                {
                    ci = 0;
                    if (li < numOfLines) li++;
                    else break;
                }
            }
        }
        */
    }
}
namespace System.Collections.Generic
{
    using System.Runtime.CompilerServices;

    public static class MicrosanExtensions2
    {
        public static bool DontContainsItems(this System.Collections.Generic.List<string> thisStringList)
        {
            return (thisStringList.Count == 0);
        }
        /// <summary>
        /// This method trim all string entries in the list.
        /// </summary>
        /// <param name="thisStringList"></param>
        public static void TrimAll(this System.Collections.Generic.List<string> thisStringList)
        {
            for (int i = 0; i < thisStringList.Count; i++)
            {
                thisStringList[i] = thisStringList[i].Trim();
            }
        }
    }
}
namespace System.Drawing
{
    using System;

    public class SimpleBitmap
    {
        public Color[,] Data;

        public SimpleBitmap(int width, int heigth)
        {
            Data = new Color[heigth, width];
        }
    }

    

    public static class MicrosanExtensions
    {
        public static Color[,] GetArea(this Bitmap thisBitmap, int xOffset, int yOffset, int width, int height)
        {
            Color[,] Data = new Color[height, width];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Data[y, x] = thisBitmap.GetPixel(x + xOffset, y + yOffset);
                }
            }
            return Data;
        }

        public static void SetArea(this Bitmap thisBitmap, Color[,] Data, int xOffset, int yOffset)
        {
            int width = Data.GetLength(1);
            int height = Data.GetLength(0);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    thisBitmap.SetPixel(x + xOffset, y + yOffset, Data[y,x]);
                }
            }
        }

        public static void FillArea(this Bitmap thisBitmap, int xStart, int yStart, int width, int height, Color clearColor)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    thisBitmap.SetPixel(x + xStart, y + yStart, clearColor);
                }
            }
        }
    }
}
namespace System.Data
{
    public enum DataSearchType
    {
        CaseUnsensitive,
        CaseSensitive
    }
    public static class MicrosanExtensions
    {
        public static string[] GetTableNames(this DataSet thisDataSet)
        {
            string[] tableNames = new string[thisDataSet.Tables.Count];
            for (int i = 0; i < tableNames.Length; i++)
            {
                tableNames[i] = thisDataSet.Tables[i].TableName;
            }
            return tableNames;
        }

        public static void AddStringDataColumns(this DataTable thisDataTable, string[] columnNames)
        {
            Type t = typeof(string);
            for (int i = 0; i < columnNames.Length; i++)
            {
                thisDataTable.Columns.Add(columnNames[i], t);
            }
            t = null;
            thisDataTable = null;
        }

        public static bool TryFindData(this DataTable thisDataTable, string dataToFind, bool IgnoreCase, bool trimMode, out int rowIndex, out int colIndex)
        {
            string currentData = "";
            
            for (rowIndex = 0; rowIndex < thisDataTable.Rows.Count; rowIndex++)
            {
                if (!thisDataTable.Rows[rowIndex].ItemArray.TryGetIndexOfAsString(dataToFind, IgnoreCase, trimMode, out colIndex))
                    continue;
                currentData = thisDataTable.Rows[rowIndex].ItemArray[colIndex].ToString();
                if (currentData.Equals(dataToFind, IgnoreCase, trimMode))
                    return true;
            }
            colIndex = -1;
            return false;
        }

        public static bool ContainsData(this DataRow dataRow)
        {
            for (int ci = 0; ci < dataRow.ItemArray.Length; ci++)
            {
                if (!dataRow.ItemArray[ci].IsNullOrEmpty(true))
                    return true;
            }
            return false;
        }

        public static void RemoveEmptyColumnsAndRows(this DataTable thisDataTable)
        {
            thisDataTable.RemoveEmptyColumns();
            thisDataTable.RemoveEmptyRows();            
        }

        public static void RemoveEmptyColumns(this DataTable thisDataTable)
        {
            for (int ci = (thisDataTable.Columns.Count - 1); ci != -1; ci--)
            {
                if (thisDataTable.IsColumnEmpty(ci))
                    thisDataTable.Columns.RemoveAt(ci);
            }
        }

        public static void RemoveEmptyRows(this DataTable thisDataTable)
        {
            for (int ri = (thisDataTable.Rows.Count - 1); ri != -1; ri--)
            {
                if (thisDataTable.IsRowEmpty(ri))
                    thisDataTable.Rows.RemoveAt(ri);
            }
        }

        public static bool IsRowEmpty(this DataTable thisDataTable, int rowIndex)
        {
            for (int i = 0; i < thisDataTable.Rows[rowIndex].ItemArray.Length; i++)
            {
                if (!thisDataTable.Rows[rowIndex].ItemArray[i].IsNullOrEmpty(true))
                    return false;
            }
            return true;
        }

        public static bool IsColumnEmpty(this DataTable thisDataTable, int columnIndex)
        {
            for (int i = 0; i < thisDataTable.Rows.Count; i++)
            {
                if (!thisDataTable.Rows[i].ItemArray[columnIndex].IsNullOrEmpty(true))
                    return false;
            }
            return true;
        }

        public static string[] ToStringArray(this DataRow thisDataRow, string[] columnsToGet)
        {
            string[] stringArray = new string[columnsToGet.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                try { stringArray[i] = thisDataRow[columnsToGet[i]].ToString(); }
                catch { stringArray[i] = "N/A: " + columnsToGet[i]; }
            }
            return stringArray;
        }

        public static void AddRange(this DataRowCollection thisDataRowCollection, DataRow[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                thisDataRowCollection.Add(rows[i].ItemArray);
            }
        }

        public static DataTable CreateNewEmpty(this DataTable thisDataTable, Type defaultDataType)
        {
            DataTable dt = new DataTable();
            for (int ci = 0; ci < thisDataTable.Columns.Count; ci++)
            {
                dt.Columns.Add(thisDataTable.Columns[ci].ColumnName, defaultDataType);
            }
            return dt;
        }

        public static DataTable GetRows(this DataTable thisDataTable, int startIndex, int endIndex, bool IncludeEmptyRows)
        {
            DataTable dtRows = thisDataTable.CreateNewEmpty(typeof(string));
            
            while (startIndex <= endIndex)
            {
                if (thisDataTable.Rows[startIndex].ContainsData() || IncludeEmptyRows)
                    dtRows.Rows.Add(thisDataTable.Rows[startIndex].ItemArray);
                startIndex++;
            }
            return dtRows;
        }

        public static string GetRowContents(this DataRow thisDataRow, string seperator)
        {
            return String.Join(seperator, thisDataRow.ItemArray.ToStringArray());
        }

        public static string GetRowContents(this DataRow thisDataRow, string seperator, string[] columnNames)
        {
            return String.Join(seperator, thisDataRow.ToStringArray(columnNames));
        }
    }
}
namespace System
{
    using System;
    using System.Data;
    
    /// <summary>
    /// 
    /// </summary>
    public static class MicrosanExtensions
    {
        private static string GLOBAL_LINEBREAK = "\r\n";

        public static int TextLengthWithout(this System.Windows.Forms.RichTextBox thisRichTextBox, string characters)
        {
            int count = 0;
            for (int i = 0; i < thisRichTextBox.Text.Length; i++)
            {
                if (!thisRichTextBox.Text[i].IsEqualAnyOf(characters))
                    count++;
            }
            return count;
        }

        public static int GetTextLength_Invoked(this System.Windows.Forms.RichTextBox thisRichTextBox)
        {
            int length = 0;
            thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    length = thisRichTextBox.TextLength;
                }));
            return length;
        }
        public static void AppendLineBreak(this System.Windows.Forms.RichTextBox thisRichTextBox, bool scrollToEnd, bool invoke)
        {
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    thisRichTextBox.AppendText(GLOBAL_LINEBREAK);
                    if (scrollToEnd) thisRichTextBox.ScrollToEnd_ThreadSafe();
                }));
            }
            else
            {
                thisRichTextBox.AppendText(GLOBAL_LINEBREAK);
                if (scrollToEnd) thisRichTextBox.ScrollToEnd_ThreadSafe();
            }
        }
        public static void AppendLineBreak(this System.Windows.Forms.RichTextBox thisRichTextBox, bool invoke)
        {
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    thisRichTextBox.AppendText(GLOBAL_LINEBREAK);
                 }));
            }
            else
            {
                thisRichTextBox.AppendText(GLOBAL_LINEBREAK);
            }
        }
        public static void AppendLines(this System.Windows.Forms.RichTextBox thisRichTextBox, string[] lines, bool scrollToEnd, bool invoke)
        {
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    thisRichTextBox.AppendLines_ThreadSafe(lines, scrollToEnd);
                }));
            }
            else
                thisRichTextBox.AppendLines_ThreadSafe(lines, scrollToEnd);
        }
        public static void AppendLines_ThreadSafe(this System.Windows.Forms.RichTextBox thisRichTextBox, string[] lines, bool scrollToEnd)
        {
            for (int i= 0; i < lines.Length; i++)
            {
                thisRichTextBox.AppendText(lines[i] + GLOBAL_LINEBREAK);
            }
            if (scrollToEnd) thisRichTextBox.ScrollToEnd_ThreadSafe();
        }
        public static void AppendColoredLines(this System.Windows.Forms.RichTextBox thisRichTextBox, string[] lines, Drawing.Color backColor, Drawing.Color textColor, bool scrollToEnd, bool invoke)
        {
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    thisRichTextBox.AppendColoredLines_ThreadSafe(lines, backColor, textColor, scrollToEnd);
                }));
            }
            else
                thisRichTextBox.AppendColoredLines_ThreadSafe(lines, backColor, textColor, scrollToEnd);
        }
        public static void AppendColoredLines_ThreadSafe(this System.Windows.Forms.RichTextBox thisRichTextBox, string[] lines, Drawing.Color backColor, Drawing.Color textColor, bool scrollToEnd)
        {
            for (int i= 0; i < lines.Length; i++)
            {
                thisRichTextBox.AppendText(lines[i] + GLOBAL_LINEBREAK);
                thisRichTextBox.MarkWithColor(thisRichTextBox.TextLength - lines[i].Length, lines[i].Length, textColor, backColor, false);
            }
            if (scrollToEnd) thisRichTextBox.ScrollToEnd_ThreadSafe();
        }
        public static void AppendLine_s(this System.Windows.Forms.RichTextBox thisRichTextBox, bool scrollToEnd, bool invoke, params string[] line_s)
        {
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    thisRichTextBox.AppendLine_s(false, line_s);
                }));
            }
            else
                thisRichTextBox.AppendLine_s(false, line_s);

            if (scrollToEnd)
            {
                thisRichTextBox.ScrollToEnd(invoke);
            }
        }
        public static void AppendLine_s(this System.Windows.Forms.RichTextBox thisRichTextBox, bool scrollToEnd, params string[] line_s)
        {
            for (int i= 0; i < line_s.Length; i++)
            {
                thisRichTextBox.AppendText(line_s[i] + GLOBAL_LINEBREAK);
            }
            if (scrollToEnd) thisRichTextBox.ScrollToEnd_ThreadSafe();
        }

        public static void AppendText(this System.Windows.Forms.RichTextBox thisRichTextBox, string text, bool appendLineBreak, bool scrollToEnd, bool invoke)
        {
            thisRichTextBox.AppendText(text, invoke);
            if (appendLineBreak)
                thisRichTextBox.AppendLineBreak(false, invoke);
            if (scrollToEnd)
            {
                thisRichTextBox.ScrollToEnd(invoke);
            }
        }
        public static void AppendText(this System.Windows.Forms.RichTextBox thisRichTextBox, string text, bool invoke)
        {
            if (invoke)
                thisRichTextBox.AppendText_Invoked(text);
            else
                thisRichTextBox.AppendText(text);
        }
        public static void AppendTextWithColor(this System.Windows.Forms.RichTextBox thisRichTextBox, string text, bool appendLineBreak, Drawing.Color background, Drawing.Color foreground, bool scrollToEnd, bool invoke)
        {
            thisRichTextBox.AppendText(text, invoke);
            int thisRichTextBox_TextLength = 0;
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    thisRichTextBox_TextLength = thisRichTextBox.TextLength;
                }));
            }
            thisRichTextBox.MarkWithColor(thisRichTextBox_TextLength - text.Length, text.Length, foreground, background, invoke);

            if (appendLineBreak)
                thisRichTextBox.AppendLineBreak(invoke);

            if (scrollToEnd)
                thisRichTextBox.ScrollToEnd(invoke);
        }

        public static void ScrollToEnd(this Windows.Forms.RichTextBox thisRichTextBox, bool invoke)
        {
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    thisRichTextBox.ScrollToEnd_ThreadSafe();
                }));
            }
            else
                thisRichTextBox.ScrollToEnd_ThreadSafe();
        }
        public static void ScrollToEnd_ThreadSafe(this Windows.Forms.RichTextBox thisRichTextBox)
        {
            thisRichTextBox.Select(thisRichTextBox.TextLength, 0);
            //thisRichTextBox.ScrollToCaret();
            
        }

        public static void ScrollToCaret_Invoked(this Windows.Forms.RichTextBox thisRichTextBox)
        {
            thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
            {
                thisRichTextBox.ScrollToCaret();
            }));
        }

        public static void Select_Invoked(this Windows.Forms.RichTextBox thisRichTextBox, int Start, int Length)
        {
            thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
            {
                thisRichTextBox.Select(Start, Length);
            }));
        }

        public static void AppendText_Invoked(this Windows.Forms.RichTextBox thisRichTextBox, string text)
        {
            thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
            {
                thisRichTextBox.AppendText(text);
            }));
        }

        public static void MarkWithColor(this Windows.Forms.RichTextBox thisRichTextBox, int Start, int Length, Drawing.Color textColor, Drawing.Color backColor, bool invoke)
        {
            if (invoke)
            {
                thisRichTextBox.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    MarkWithColor_ThreadSafe(thisRichTextBox, Start, Length, textColor, backColor);
                }));
            }
            else
                MarkWithColor_ThreadSafe(thisRichTextBox, Start, Length, textColor, backColor);
        }
        private static void MarkWithColor_ThreadSafe(Windows.Forms.RichTextBox thisRichTextBox, int Start, int Length, Drawing.Color textColor, Drawing.Color backColor)
        {
            int StartTemp = 0, LengthTemp = 0;
            Drawing.Color BgColorTemp, FgColorTemp;
            // backup values
            BgColorTemp = thisRichTextBox.SelectionBackColor;
            FgColorTemp = thisRichTextBox.SelectionColor;
            StartTemp = thisRichTextBox.SelectionStart;
            LengthTemp = thisRichTextBox.SelectionLength;
            // mark text with color
            thisRichTextBox.SelectionLength = 0;
            if (Start < 0) Start = 0;
            thisRichTextBox.SelectionStart = Start;
            thisRichTextBox.SelectionLength = Length;
            thisRichTextBox.SelectionBackColor = backColor;
            thisRichTextBox.SelectionColor = textColor;

            // restore values
            thisRichTextBox.SelectionLength = 0;
            thisRichTextBox.SelectionStart = StartTemp;
            thisRichTextBox.SelectionLength = LengthTemp;
            thisRichTextBox.SelectionBackColor = BgColorTemp;
            thisRichTextBox.SelectionColor = FgColorTemp;
        }

        public static bool IfFirstOrNoItemSelected(this System.Windows.Forms.ComboBox thisComboBox)
        {
            return (thisComboBox.SelectedIndex < 1);
        }

        public static bool NoItemSelected(this System.Windows.Forms.ComboBox thisComboBox)
        {
            return (thisComboBox.SelectedIndex == -1);
        }
                
        public static void Panel1Visible(this System.Windows.Forms.SplitContainer thisSplitContainer, bool value)
        {
            thisSplitContainer.Panel1Collapsed = !value;
        }
        public static void Panel2Visible(this System.Windows.Forms.SplitContainer thisSplitContainer, bool value)
        {
            thisSplitContainer.Panel2Collapsed = !value;
        }

        public static bool Panel1Visible(this System.Windows.Forms.SplitContainer thisSplitContainer)
        {
            return !thisSplitContainer.Panel1Collapsed;
        }
        public static bool Panel2Visible(this System.Windows.Forms.SplitContainer thisSplitContainer)
        {
            return !thisSplitContainer.Panel2Collapsed;
        }

        public static void Add(this Windows.Forms.ToolStripItemCollection tsic, string text, bool checkedState, EventHandler onClick)
        {
            Windows.Forms.ToolStripMenuItem tsmi = new Windows.Forms.ToolStripMenuItem(text, null, onClick);
            tsmi.Checked = checkedState;
            tsic.Add(tsmi);
            tsmi = null;
        }
        public static void Add(this Windows.Forms.ToolStripItemCollection tsic, string text, EventHandler onClick)
        {
            tsic.Add(text, null, onClick);
        }
        /// <summary>
        /// This will only add a new System.Windows.Forms.ToolStripSeparator
        /// </summary>
        /// <param name="tsic"></param>
        public static void AddSeperator(this Windows.Forms.ToolStripItemCollection tsic)
        {
            tsic.Add(new System.Windows.Forms.ToolStripSeparator());
        }

        private class ResizeEmptyColumnsThreaded
        {
            System.Windows.Forms.DataGridView dgv = null;
            int newWidth = -1;
            public ResizeEmptyColumnsThreaded(System.Windows.Forms.DataGridView dgv, int newWidth)
            {
                this.dgv = dgv;
                this.newWidth = newWidth;
            }
            public void Start()
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(DoWork));
                t.Start();
            }
            private void DoWork()
            {
                int columnCount = 0;
                dgv.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    columnCount = dgv.Columns.Count;
                }));
                for (int colIndex = 0; colIndex < columnCount; colIndex++)
                {
                    if (dgv.IsColumnEmpty(colIndex))
                        dgv.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                        {
                            dgv.Columns[colIndex].Width = newWidth;
                        }));
                }
            }
        }
        private class ResizeEmptyRowsThreaded
        {
            System.Windows.Forms.DataGridView dgv = null;
            int newHeight = -1;
            public ResizeEmptyRowsThreaded(System.Windows.Forms.DataGridView dgv, int newHeight)
            {
                this.dgv = dgv;
                this.newHeight = newHeight;
            }
            public void Start()
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(DoWork));
                
                t.Start();
            }
            private void DoWork()
            {
                int rowCount = 0;
                dgv.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    rowCount = dgv.Rows.Count;
                }));
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    if (dgv.IsRowEmpty(rowIndex))
                        dgv.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                        {

                            dgv.Rows[rowIndex].Height = newHeight;
                        }));
                }
            }
        }
        public static void ResizeEmptyColumns(this System.Windows.Forms.DataGridView thisDataGridView, int newWidth)
        {
            ResizeEmptyColumnsThreaded rect = new ResizeEmptyColumnsThreaded(thisDataGridView, newWidth);
            rect.Start();
        }

        public static void ResizeEmptyRows(this System.Windows.Forms.DataGridView thisDataGridView, int newHeight)
        {
            ResizeEmptyRowsThreaded rert = new ResizeEmptyRowsThreaded(thisDataGridView, newHeight);
            rert.Start();
        }

        public static void ResizeNonEmptyRows(this System.Windows.Forms.DataGridView thisDataGridView, int newHeight)
        {
            int rowCount = 0;
            thisDataGridView.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
            {
                rowCount = thisDataGridView.Rows.Count;
            }));
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                if (!thisDataGridView.IsRowEmpty(rowIndex))
                thisDataGridView.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    
                        thisDataGridView.Rows[rowIndex].Height = newHeight;
                }));
            }
        }

        public static void SetDataGridViewColumnsSortMode(this System.Windows.Forms.DataGridView thisDataGridView, System.Windows.Forms.DataGridViewColumnSortMode dgvColSortMode)
        {
            for (int colIndex = 0; colIndex < thisDataGridView.ColumnCount; colIndex++)
            {
                thisDataGridView.Columns[colIndex].SortMode = dgvColSortMode;
            }
        }

        public static bool IsRowEmpty(this System.Windows.Forms.DataGridView thisDataGridView, int rowIndex)
        {
            DataTable dt = null;
            thisDataGridView.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
            {
                dt = thisDataGridView.DataSource as DataTable;
            }));
            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            {
                if (!dt.Rows[rowIndex][colIndex].IsNullOrEmpty(true))
                {
                    dt = null;
                    return false;
                }
            }
            dt = null;
            return true;
        }


        public static bool IsColumnEmpty(this System.Windows.Forms.DataGridView thisDataGridView, int colIndex)
        {
            DataTable dt = null;
            thisDataGridView.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
            {
                dt = thisDataGridView.DataSource as DataTable;
            }));
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                if (!dt.Rows[rowIndex][colIndex].IsNullOrEmpty(true))
                {
                    //MessageBox.Show(dt.Columns[colIndex].ColumnName, "Not empty");
                    dt = null;
                    return false;
                }
            }
            //MessageBox.Show(dt.Columns[colIndex].ColumnName, "This is empty");
            dt = null;
            return true;
        }

        public static void SetItems(this System.Windows.Forms.ListBox.ObjectCollection thisListBoxObjectCollection, string[] items)
        {
            thisListBoxObjectCollection.Clear();
            thisListBoxObjectCollection.AddRange(items);
        }

        public static void SetDataSource(this System.Windows.Forms.DataGridView thisDataGridView, object source)
        {
            thisDataGridView.DataSource = null;
            thisDataGridView.DataSource = source;
        }

        public static void ClearDataSource(this System.Windows.Forms.DataGridView thisDataGridView)
        {
            thisDataGridView.DataSource = null;
        }

        
    }
    public enum SimpleMessageBoxIcon
    {
        None = 0,
        Error = 0x10,
        Question = 0x20,
        Warning = 0x30,
        Information = 0x40
    }
    public enum SimpleMessageBoxButtons
    {
        OK,
        OKCancel,
        AbortRetryIgnore,
        YesNoCancel,
        YesNo,
        RetryCancel
    }


    public static class SimpleMessageBox
    {
        /// <summary> Shows all the different types of icons, one after annother.</summary>
        public static void TestShowAllTypes()
        {
            TestShowType(SimpleMessageBoxIcon.None);
            TestShowType(SimpleMessageBoxIcon.Error);
            TestShowType(SimpleMessageBoxIcon.Question);
            TestShowType(SimpleMessageBoxIcon.Warning);
            TestShowType(SimpleMessageBoxIcon.Information);
        }
        public static void TestShowType(SimpleMessageBoxIcon icon)
        {
            Windows.Forms.MessageBox.Show(icon.ToString(), icon.ToString(), Windows.Forms.MessageBoxButtons.OK, (Windows.Forms.MessageBoxIcon)icon);
        }

        public static System.Windows.Forms.DialogResult Show(string title, string text, SimpleMessageBoxIcon type, SimpleMessageBoxButtons buttons)
        {
            return Windows.Forms.MessageBox.Show(text, title, (Windows.Forms.MessageBoxButtons)buttons, (Windows.Forms.MessageBoxIcon)type);
        }

        /// <summary>Shows a standard Windows.Forms.MessageBox with Information icon and OK button only</summary>
        /// <param name="title">The title of the messagebox</param> <param name="text"> Text contents in messagebox</param>
        public static void Information(string title, string text)
        {
            Show(title, text, SimpleMessageBoxIcon.Information, SimpleMessageBoxButtons.OK);
        }

        /// <summary>Shows a standard Windows.Forms.MessageBox with Question icon and Yes/No buttons. <para></para></summary>
        /// <param name="title">The title of the messagebox</param> <param name="text"> Text contents in messagebox</param>
        /// <returns>Returns true only if Yes is pressed.</returns>
        public static bool Question(string title, string text)
        {
            return (System.Windows.Forms.DialogResult.Yes == Show(title, text, SimpleMessageBoxIcon.Question, SimpleMessageBoxButtons.YesNo));
        }

        /// <summary>Shows a standard Windows.Forms.MessageBox with Error icon and OK button only. <para></para></summary>
        /// <param name="title">The title of the messagebox</param> <param name="text"> Text contents in messagebox</param>
        /// <returns>Returns standard System.Windows.Forms.DialogResult</returns>
        public static void Error(string title, string text)
        {
            Show(title, text, SimpleMessageBoxIcon.Error, SimpleMessageBoxButtons.OK);
        }

        /// <summary>Shows a standard Windows.Forms.MessageBox with Error icon and specified buttons. <para></para></summary>
        /// <param name="title">The title of the messagebox</param> <param name="text"> Text contents in messagebox</param>
        /// <returns>Returns standard System.Windows.Forms.DialogResult</returns>
        public static System.Windows.Forms.DialogResult Error(string title, string text, SimpleMessageBoxButtons buttons)
        {
            return Show(title, text, SimpleMessageBoxIcon.Error, buttons);
        }

    }
    public static class FileDialogOneShot
    {
        public static bool OpenFile(string title, string filter, string initialDirectory, out string FileName)
        {
            using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
            {
                ofd.Title = title;
                ofd.Filter = filter;
                ofd.Multiselect = false;
                ofd.ReadOnlyChecked = true;
                ofd.SupportMultiDottedExtensions = true;
                ofd.AddExtension = true;
                ofd.InitialDirectory = initialDirectory;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    FileName = ofd.FileName;
                else
                    FileName = null;
            }
            return (FileName != null);
        }

        public static bool SaveFile(string title, string filter, string initialDirectory, out string filePath)
        {
            using (System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog())
            {
                sfd.Title = title;
                sfd.Filter = filter;
                sfd.SupportMultiDottedExtensions = true;
                sfd.AddExtension = true;
                sfd.InitialDirectory = initialDirectory;

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    filePath = sfd.FileName;
                else
                    filePath = null;
            }
            return (filePath != null);
        }

        public static bool OpenFiles(string title, string filter, string initialDirectory, out string[] filePaths)
        {
            using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
            {
                ofd.Title = title;
                ofd.Filter = filter;
                ofd.Multiselect = true;
                ofd.ReadOnlyChecked = true;
                ofd.SupportMultiDottedExtensions = true;
                ofd.AddExtension = true;
                ofd.InitialDirectory = initialDirectory;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    filePaths = ofd.FileNames;
                else
                    filePaths = null;
            }
            return (filePaths != null);
        }
    }
}




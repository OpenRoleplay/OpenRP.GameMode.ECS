using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Extensions
{
    public static class StringExtension
    {
        public static string WordWrap(this string text, int lineLength)
        {
            string[] words = text.Split(' ');
            int charCount = 0;
            string formattedText = "";

            for (int i = 0; i < words.Length; i++)
            {
                formattedText += words[i] + " ";
                charCount += words[i].Length;

                if (charCount > lineLength)
                {
                    formattedText += "\n";
                    charCount = 0;
                }
            }

            return formattedText;
        }

    }
}

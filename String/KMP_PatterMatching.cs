using System;
public class SubstringSearch
    {
        /**
         * Compute pattern array to maintain size of suffix which is same as prefix
         * Time/space complexity is O(size of pattern)
         */
        private int[] patternArray(char[] pattern)
        {
            int[] lps = new int[pattern.Length];

            int j = 0;
            lps[0] = 0;

            for (int i = 1; i < pattern.Length;)
            {
                if (pattern[j] == pattern[i])
                {
                    lps[i] = j + 1;
                    j++; i++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        /**
         * KMP algorithm of pattern matching.
         */
        public bool KMP(char[] text, char[] pattern)
        {
            int[] lps = patternArray(pattern);

            int i = 0; int j = 0;
            while (i < text.Length && j < pattern.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++; j++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if (j == pattern.Length)
            {
                return true;
            }
            return false;
        }

        public static void Main(string[] args)
        {

            string str = "abcxabcdabcdabcy";
            string subString = "abcdabcy";
            SubstringSearch ss = new SubstringSearch();
            bool result = ss.KMP(str.ToCharArray(), subString.ToCharArray());
            Console.WriteLine(result);

        }
    }
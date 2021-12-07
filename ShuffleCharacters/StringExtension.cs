using System;
using System.Text;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentException">Source string is null or empty or white spaces.</exception>
        /// <exception cref="ArgumentException">Count of iterations is less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Source string is null or empty or white spaces", nameof(source));
            }

            if (count < 0)
            {
                throw new ArgumentException("Count of iterations is less than 0", nameof(source));
            }

            StringBuilder res = new StringBuilder(source);

            for (int i = 1; i <= count; i++)
            {
                SingleShuffleChars(ref res);

                if (res.ToString() == source)
                {
                    for (int j = 1; j <= count % i; j++)
                    {
                        SingleShuffleChars(ref res);
                    }

                    break;
                }
            }

            return res.ToString();
        }

        private static void SingleShuffleChars(ref StringBuilder source)
        {
            for (int i = 1, j = 2; j < source.Length; i++, j += 2)
            {
                source.Insert(i, source[j]);
                source.Remove(j + 1, 1);
            }
        }
    }
}

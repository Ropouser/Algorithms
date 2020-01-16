using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Algorithms
{
    public class StringsAndArrays
    {
        // Is Unique character
        private bool IsUniqueChars(String str)
        {
            var hashset = new HashSet<char>();
            foreach (var c in str)
            {
                if (hashset.Contains(c)) return false;
                hashset.Add(c);
            }

            return true;
        }

        // Check if is permutation
        private bool IsPermutation(string original, string valueToTest)
        {
            if (original.Length != valueToTest.Length)
            {
                return false;
            }

            var originalAsArray = original.ToCharArray();
            Array.Sort(originalAsArray);
            original = new string(originalAsArray);

            var valueToTestAsArray = valueToTest.ToCharArray();
            Array.Sort(valueToTestAsArray);
            valueToTest = new string(valueToTestAsArray);

            return original.Equals(valueToTest);
        }

        // URLify
        int Count_the_number_of_spaces(char[] input)
        {
            var spaceCount = 0;
            foreach (var character in input)
            {
                if (character == ' ')
                    spaceCount++;
            }
            return spaceCount;
        }

        private void ReplaceSpaces(char[] input, int length)
        {
            var space = new[] { '0', '2', '%' };
            var spaceCount = Count_the_number_of_spaces(input);
            // calculate new string size
            var index = length + spaceCount * 2;
            void SetCharsAndMoveIndex(params char[] chars)
            {
                foreach (var c in chars)
                    input[index--] = c;
            }
            // copying the characters backwards and inserting %20
            for (var indexSource = length - 1; indexSource >= 0; indexSource--)
                if (input[indexSource] == ' ')
                    SetCharsAndMoveIndex(space);
                else SetCharsAndMoveIndex(input[indexSource]);
        }

        // Palindrome permutation
        public static int GetCharNumber(char c)
        {
            var val = char.ToLower(c) - 'a';
            if (0 <= val && val <= 25)
            {
                return val;
            }
            return -1;
        }

        public static bool IsPermutationOfPalindrome(String phrase)
        {
            int countOdd = 0;
            int[] table = new int[26];
            foreach (char c in phrase)
            {
                int x = GetCharNumber(c);
                if (x != -1)
                {
                    table[x]++;

                    if (table[x] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else
                    {
                        countOdd--;
                    }
                }
            }
            return countOdd <= 1;
        }

        // One away
        public static bool OneAway(string first, string second)
        {
            if (first == second)
                return true;

            int differences = 0;
            int shift = 0;

            string compareString = first.Length < second.Length ? first : second;
            string testString = first.Length < second.Length ? second : first;

            for (int i = 0; i < compareString.Length; i++)
            {
                if (testString.Length != compareString.Length)
                {
                    if (testString[i + shift] != compareString[i])
                    {
                        differences++;
                        shift++;
                        i--;
                    }
                }
                else
                {
                    if (testString[i] != compareString[i])
                        differences++;
                }

                if (differences >= 2)
                {
                    return false;
                }
            }

            return true;
        }

        // One away their solution
        public static bool OneEditAway2(String first, String second)
        {
            /* Length checks. */
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false;
            }

            /* Get shorter and longer string.*/
            String s1 = first.Length < second.Length ? first : second;
            String s2 = first.Length < second.Length ? second : first;

            int index1 = 0;
            int index2 = 0;
            bool foundDifference = false;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    /* Ensure that this is the first difference found.*/
                    if (foundDifference) return false;
                    foundDifference = true;
                    if (s1.Length == s2.Length)
                    { // On replace, move shorter pointer
                        index1++;
                    }
                }
                else
                {
                    index1++; // If matching, move shorter pointer
                }
                index2++; // Always move pointer for longer string
            }
            return true;
        }

        // String compression
        public static string StringCompression(string input)
        {
            var result = new StringBuilder();
            var count = 1;

            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    count++;
                    if(i != input.Length - 2)
                        continue;
                }

                result.Append(input[i]);
                result.Append(count.ToString());

                if (input[i] != input[i + 1])
                {
                    count = 1;

                    if (i == input.Length - 1)
                    {
                        result.Append(input[i + 1]);
                    }
                }

            }

            return result.Length < input.Length ? result.ToString() : input;
        }

        private string CompressBetter(string str)
        {
            var sb = new StringBuilder();
            var last = str[0];
            var count = 1;

            for (var i = 1; i < str.Length; i++)
            {
                if (str[i] == last)
                {
                    count++;
                }
                else
                {
                    sb.Append(last);
                    sb.Append(count);
                    last = str[i];
                    count = 1;
                }
            }
            sb.Append(last);
            sb.Append(count);

            return str.Length < sb.Length ? str : sb.ToString();
        }

        // Rotate matrix 90 degrees
        public static void RotateMatrix(int[][] matrix)
        {
            var spins = 
                matrix.Length % 2 == 0 ? 
                matrix.Length / 2 
                : matrix.Length / 2 - 1;

            for (int i = 0; i < spins; i++)
            {
                for (int j = i; j < matrix.Length - 1; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][matrix.Length - 1 - i];

                    var secondTemp = matrix[matrix.Length - 1 - j][i];
                    matrix[matrix.Length - 1 - j][i] = temp;

                    matrix[j][matrix.Length - 1 - i] = matrix[matrix.Length - 1 - i][matrix.Length - 1 - j];
                    matrix[matrix.Length - 1 - i][matrix.Length - 1 - j] = secondTemp;
                }
            }
        }

        // Zero matrix

        public static void ZeroMatrix()
        {


        }
    }
}

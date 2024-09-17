using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class labFuncs
    {
        //������� 1
        public static int Proc(char d1, char d2, char op)
        {
            if (!char.IsDigit(d1) || !char.IsDigit(d2))
                throw new ArgumentException("��� ������� ������ ���� �������.");

            int n1 = d1 - '0';
            int n2 = d2 - '0';

            return op switch
            {
                '+' => n1 + n2,
                '-' => n1 - n2,
                '*' => n1 * n2,
                '/' => n2 != 0 ? n1 / n2 : throw new DivideByZeroException(),
                _ => throw new ArgumentException("�������� ��������."),
            };
        }
        //������� 2
        public static void PrintCharCodes()
        {
            char[] symbols = { ' ', '.', ',', ';', ':', '�', '�' };

            foreach (char c in symbols)
            {
                int decimalCode = (int)c;
                string hexCode = decimalCode.ToString("X");

                Console.WriteLine($"������: {c}, ���������� ���: {decimalCode}, ����������������� ���: {hexCode}");
            }
        }
        //������� 3
        public static void PrintAllCharCodes()
        {
            char[] symbols = new char[62 + 66];
            int index = 0;

            for (char c = '0'; c <= '9'; c++)
                symbols[index++] = c;

            for (char c = 'A'; c <= 'Z'; c++)
                symbols[index++] = c;

            for (char c = 'a'; c <= 'z'; c++)
                symbols[index++] = c;

            for (char c = '�'; c <= '�'; c++)
                symbols[index++] = c;

            for (char c = '�'; c <= '�'; c++)
                symbols[index++] = c;

            foreach (char c in symbols)
            {
                int decimalCode = (int)c;
                string hexCode = decimalCode.ToString("X");

                Console.WriteLine($"������: {c}, ���������� ���: {decimalCode}, ����������������� ���: {hexCode}");
            }
        }

        //������� 4
        public static char[] ConvertToCharArray(string text)
        {
            return text.ToCharArray();
        }

        //������� 5
        public static string ConvertToText(char[] charArray)
        {
            return new string(charArray);
        }
        //������� 6
        public static void PrintCharArray(char[] charArray)
        {
            foreach (char c in charArray)
            {
                Console.Write(c);
            }
            Console.WriteLine(); // ��� �������� ������ ����� ������ �������
        }

        //������� 7
        public static void PrintInputCharCodes(char[] charArray)
        {
            foreach (char c in charArray)
            {
                int decimalCode = (int)c;
                string hexCode = decimalCode.ToString("X");

                Console.WriteLine($"������: {c}, ���������� ���: {decimalCode}, ����������������� ���: {hexCode}");
            }
        }

        //������� 8
        public static void PrintWhitespaceCharCodes(char[] charArray)
        {
            foreach (char c in charArray)
            {
                if (char.IsWhiteSpace(c))
                {
                    int decimalCode = (int)c;
                    string hexCode = decimalCode.ToString("X");

                    Console.WriteLine($"������: '{c}', ���������� ���: {decimalCode}, ����������������� ���: {hexCode}");
                }
            }
        }
        //������� 9
        public static void CountLettersAndDigits(char[] charArray, out int letterCount, out int digitCount)
        {
            letterCount = 0;
            digitCount = 0;

            foreach (char c in charArray)
            {
                if (char.IsLetter(c))
                {
                    letterCount++;
                }
                else if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }
        }

        //������� 10
        public static int FindChar(char[] charArray, char target)
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == target)
                {
                    return i; // ���������� ������, ���� ������ ������
                }
            }

            return -1; // ���������� -1, ���� ������ �� ������
        }
        //������� 11
        public static int CountCharOccurrences(char[] charArray, char target)
        {
            int count = 0;

            foreach (char c in charArray)
            {
                if (c == target)
                {
                    count++;
                }
            }

            return count;
        }
        //������� 12
        public static void ReplaceChar(char[] charArray, char first, char second)
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == first)
                {
                    charArray[i] = second;
                }
            }
        }

        //������� 13
        public static char[] RemoveChar(char[] charArray, char target)
        {
            int newSize = 0;
            foreach (char c in charArray)
            {
                if (c != target)
                {
                    newSize++;
                }
            }
            char[] newArray = new char[newSize];
            int index = 0;
            foreach (char c in charArray)
            {
                if (c != target)
                {
                    newArray[index++] = c;
                }
            }
            return newArray;
        }
        //������� 14
        public static char[] CompressSpaces(char[] charArray)
        {
            int newSize = 0;
            bool inSpaceSequence = false;
            foreach (char c in charArray)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!inSpaceSequence)
                    {
                        newSize++;
                        inSpaceSequence = true;
                    }
                }
                else
                {
                    newSize++;
                    inSpaceSequence = false;
                }
            }
            char[] newArray = new char[newSize];
            int index = 0;
            inSpaceSequence = false;
            foreach (char c in charArray)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!inSpaceSequence)
                    {
                        newArray[index++] = ' ';
                        inSpaceSequence = true;
                    }
                }
                else
                {
                    newArray[index++] = c;
                    inSpaceSequence = false;
                }
            }
            return newArray;
        }
        //������� 15
        public static char[] ReverseArray(char[] charArray)
        {
            char[] reversedArray = new char[charArray.Length];
            int index = 0;

            // ��������� ����� ������ � �������� �������
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                reversedArray[index++] = charArray[i];
            }

            return reversedArray;
        }

        //������� 16
        public static bool IsPalindrome(char[] charArray)
        {
            int left = 0;
            int right = charArray.Length - 1;
            while (left < right)
            {
                if (charArray[left] != charArray[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        //������� 17
        public static (int wordCount, int sentenceCount) CountWordsAndSentences(char[] charArray)
        {
            int wordCount = 0;
            int sentenceCount = 0;
            bool inWord = false;
            foreach (char c in charArray)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (!inWord)
                    {
                        wordCount++;
                        inWord = true;
                    }
                }
                else
                {
                    if (c == '.' || c == '?' || c == '!')
                    {
                        sentenceCount++;
                    }
                    inWord = false;
                }
            }
            if (inWord)
            {
                wordCount++;
            }
            return (wordCount, sentenceCount);
        }
        //������� 18
        public static char[] CapitalizeSentences(char[] charArray)
        {
            bool capitalizeNext = true;
            char[] resultArray = new char[charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];
                if (char.IsLetter(c))
                {
                    if (capitalizeNext)
                    {
                        resultArray[i] = char.ToUpper(c);
                        capitalizeNext = false;
                    }
                    else
                    {
                        resultArray[i] = char.ToLower(c);
                    }
                }
                else
                {
                    resultArray[i] = c;
                    if (c == '.' || c == '?' || c == '!')
                    {
                        capitalizeNext = true;
                    }
                }
            }
            return resultArray;
        }
        //������� 19
        public static (char[] separators, char[] punctuation) ExtractSeparatorsAndPunctuation(char[] charArray)
        {
            HashSet<char> separatorsSet = new HashSet<char>();
            HashSet<char> punctuationSet = new HashSet<char>();

            foreach (char c in charArray)
            {
                if (char.IsWhiteSpace(c))
                {
                    separatorsSet.Add(c);
                }
                else if (c == '.' || c == ',' || c == ';' || c == ':' || c == '?' || c == '!')
                {
                    punctuationSet.Add(c);
                }
            }
            return (separatorsSet.ToArray(), punctuationSet.ToArray());
        }

        //������� 20
        public static string RemoveSpaces(string input)
        {
            return input.Replace(" ", "");
        }

        //������� 21
        public static string ReplaceSpacesWithHyphens(string input)
        {
            return input.Replace(" ", "-");
        }

        //������� 22
        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //������� 23
        public static int CountAAndT(string input)
        {
            int countA = 0;
            int countT = 0;
            foreach (char c in input)
            {
                if (c == '�' || c == '�')
                {
                    countA++;
                }
                else if (c == '�' || c == '�')
                {
                    countT++;
                }
            }
            return countA + countT;
        }

        //������� 24
        public static int CountWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        //������� 25
        public static string[] ExtractWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return Array.Empty<string>();
            }
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        //������� 26
        public static void PrintStringArray(string[] array)
        {
            foreach (string element in array)
            {
                Console.WriteLine(element);
            }
        }
        //������� 27
        public static string ReverseWordsInSentence(string input)
        {
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            string reversedSentence = string.Join(" ", words);
            reversedSentence = char.ToUpper(reversedSentence[0]) + reversedSentence.Substring(1).ToLower() + ".";
            return reversedSentence;
        }

        //������� 28
        public static int[] CountCharsInLines(string input)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);
            int[] charCounts = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                charCounts[i] = lines[i].Length;
            }

            return charCounts;
        }

        //������� 29
        public static string RemoveLineAndQuestionLine(string input, int lineToRemove)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);
            var result = new List<string>();
            bool questionMarkLineRemoved = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (i == lineToRemove - 1)
                {
                    continue;
                }

                if (!questionMarkLineRemoved && lines[i].Trim().EndsWith("?"))
                {
                    questionMarkLineRemoved = true;
                    continue;
                }

                result.Add(lines[i]);
            }

            return string.Join("\n", result);
        }
        //������� 30
        public static void CheckBracketBalance(string input)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!labFuncs.AreBracketsBalanced(lines[i]))
                {
                    Console.WriteLine($"����� ������: {i + 1}");
                    Console.WriteLine($"������������������ ������: {lines[i]}");
                }
            }
        }

        public static bool AreBracketsBalanced(string line)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in line)
            {
                if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
        //������� 31
        public static int GetLongestLineLength(string input)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);
            int maxLength = 0;

            foreach (string line in lines)
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }

            return maxLength;
        }

        public static int GetLongestLineNumber(string input)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);
            int maxLength = 0;
            int longestLineIndex = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > maxLength)
                {
                    maxLength = lines[i].Length;
                    longestLineIndex = i + 1;
                }
            }

            return longestLineIndex;
        }

        public static string GetLongestLine(string input)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);
            string longestLine = "";
            int maxLength = 0;

            foreach (string line in lines)
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                    longestLine = line;
                }
            }

            return longestLine;
        }

        //������� 32
        public static string ReverseLinesInSameOrder(string input)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = ReverseString(lines[i]);
            }

            return string.Join("\n", lines);
        }
        public static string ReverseLinesInReverseOrder(string input)
        {
            string[] lines = input.Split(new[] { '\n' }, StringSplitOptions.None);
            Array.Reverse(lines);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = ReverseString(lines[i]);
            }

            return string.Join("\n", lines);
        }

        //������� 33
        public static string FindLongestString(string[] strings)
        {
            if (strings == null || strings.Length == 0)
            {
                throw new ArgumentException("������ ����� �� ����� ���� ������.");
            }

            string longestString = strings[0];

            foreach (string str in strings)
            {
                if (str.Length > longestString.Length)
                {
                    longestString = str;
                }
            }

            return longestString;
        }
        //������� 34
        public static string JoinWithDelimiter(string[] strings, char delimiter)
        {
            if (strings == null || strings.Length == 0)
            {
                return string.Empty;
            }

            return string.Join(delimiter, strings);
        }
        //������� 35
        public static string[] SplitIntoArray(string input, char delimiter)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new string[0];
            }

            return input.Split(delimiter);
        }
        public static void PrintArray(string[] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("������ ����.");
                return;
            }

            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }

        //������� 36
        public static string JoinArrayWithDelimiter(string[] array, char delimiter)
        {
            if (array == null || array.Length == 0)
            {
                return string.Empty;
            }

            return string.Join(delimiter, array);
        }
    }
}
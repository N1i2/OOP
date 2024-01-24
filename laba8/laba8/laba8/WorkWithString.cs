using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyString
{
    static class WorkWithString
    {
        public static void DeleteAllZnack(ref string text)
        {
            List<char> znack = new List<char>();
            string result = "";

            znack.Add('.');
            znack.Add(',');
            znack.Add('!');
            znack.Add('?');

            for (int i = 0; i < text.Length; i++)
            {
                if (znack.Contains(text[i]))
                    continue;

                result += text[i];
            }

            text = result;
        }

        public static void CreatOneWord(ref string text)
        {
            text = string.Join("_", text.Split(' '));
        }

        public static string CreatFence(string text)
        {
            string first = "";
            string second = "";

            for (int i = 0; i < text.Length; i++)
                if (i % 2 == 0)
                    first += text[i];
                else
                    second += text[i];

            first = first.ToUpper();
            second = second.ToLower();
            text = "";

            for (int i = 0; i < second.Length; i++)
            {
                text += first[i];
                text += second[i];
            }

            if (first.Length != second.Length)
                text += first[first.Length - 1];

            return text;
        }

        public static string ShowMirror(string text)
        {
            string rev = " || ";

            for (int i = text.Length - 1; i >= 0; i--)
                rev += text[i];

            return text + rev;
        }

        public static bool LocateCharA(string text)
        {
            for(int i =0; i<text.Length;i++)
                if (text[i] == 'A' || text[i]=='a')
                    return true;

            return false;
        }
    }
}

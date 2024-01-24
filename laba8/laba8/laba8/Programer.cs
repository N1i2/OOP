using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProger
{
    class Programer
    {
        public Programer(string name, float vers, string[] operat, string[] tehnik, string[] termin)
        {
            Operation = new List<string>();
            Tehnolage = new List<string>();
            Termin = new List<string>();
            Name = name;
            Versia = vers;
            CreatList(Operation, operat);
            CreatList(Tehnolage, tehnik);
            CreatList(Termin, termin);
            schetCol = ++helpCol;
        }

        private static int helpCol = 0;
        public int schetCol;

        private string name;
        private float versia;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Replace(" ", "") == "")
                    throw new Exception("Имя не может быть пустым");

                name = value;
            }
        }
        public float Versia
        {
            get { return versia; }
            set
            {
                if (value <= 0)
                    throw new Exception("Версия не может быть <= 0");

                versia = value;
            }
        }

        public List<string> Operation { get; set; }
        public List<string> Tehnolage { get; set; }
        public List<string> Termin { get; set; }

        private void CreatList(List<string> oper, string[] value)
        {
            for (int i = 0; i < value.Length; i++)
                if (!oper.Contains(value[i]))
                    oper.Add(value[i]);
        }
    }
}

﻿using System;

namespace MyPlace
{
    sealed partial class State : Land
    {
        private President pres = new President();

        public void GetInfoPres(string name, int age)
        {
            if (name == string.Empty)
            {
                Console.WriteLine("Такогоне может быть");
                return;
            }
            if (age < 40)
            {
                Console.WriteLine("Слишком молоой для президента");
                return;
            }

            pres.age = age;
            pres.name = name;
        }
    }
}
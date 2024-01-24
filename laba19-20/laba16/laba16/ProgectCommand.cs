using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommand
{
    public class ProgectCommand : ICommand
    {
        string _name = string.Empty;

        public ProgectCommand(string name)
        {
            _name = name;
        }

        public void Execut()
        {
            if(_name == string.Empty)
                Console.WriteLine("Никого не было");

                Console.WriteLine(_name);
        }
    }
}

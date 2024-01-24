using MyCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyCommand
{
   public class Invoke
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            this._command = command;
        }

        public void ShowAllNames()
        {
            Console.WriteLine("Последний посетитель");

            if (this._command is ICommand)
                this._command.Execut();
        }
    }
}

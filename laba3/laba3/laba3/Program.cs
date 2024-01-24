using System;
using MyStacks;
using MyExtention;

namespace laba3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>(17);

            myStack--;
            myStack--;

            if (myStack)
                Console.WriteLine("Не пуст");
            else
                Console.WriteLine("Пуст");

            myStack = myStack + 17;
            myStack = myStack + 20;
            myStack--;
            myStack = myStack + 45;
            myStack++;
            myStack = myStack + 130;

            if (myStack)
                Console.WriteLine("Не пуст");
            else
                Console.WriteLine("Пуст");

            MyStack<int> myStack1 = new MyStack<int>();
            myStack1 = myStack1 > myStack;

            myStack1[1] = 32;
            Console.WriteLine(myStack1[1]);

            MyStack<int> hell=new MyStack<int>();

            //husbkrhsbhtjhsbhvshjkdbvhjxkbvhjzdbfvrhzkbvfhsvbhfzkvbhj
            
            hell.Geter(name: "dima", otdel:1);
            
            //vfhdjv gdkvzdbhkhvjslbtrhjsbhslrbhjlbtshjvoebtrhjsvbthsgkbhtrs

            myStack1--;
            myStack1--;
            myStack1--;

            Console.WriteLine("\nСумма удоленных элементов: {0}", MyStack<int>.StaticOpereshen.SumDelElement());

            Console.WriteLine("\nКоличество удоленных элементов: {0}", MyStack<int>.StaticOpereshen.ShowCol());

            Console.WriteLine("\nРазность между наибольшим и наимеьшим числом удоленных элементов: {0}", MyStack<int>.StaticOpereshen.FmaxTnim());
            Console.WriteLine();

            string hello = "hello. how are you. im fine.";

            Console.WriteLine(hello.LocatePart());
            myStack = myStack + 11;
            Console.WriteLine(myStack.StackAverage());
        }
    }
}
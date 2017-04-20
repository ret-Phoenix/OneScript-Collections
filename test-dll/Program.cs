using OneScript_Collections;
using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_dll
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExtStack itm = new ExtStack();
            //IValue data = ValueFactory.Create("str1");
            //_queue.Enqueue(data);

            Queue<int> val = new Queue<int>();
            val.Enqueue(1);
            val.Enqueue(2);
            val.Enqueue(3);

            //int[] ar = new int[val.Count];
            int[] ar = new int[5];


            val.CopyTo(ar, 1);

            //PrintValues(ar, ' ');

            Console.WriteLine("data:");
            Console.WriteLine(ar);

            int v = 9;
        }

        public static void PrintValues(Array myArr, char mySeparator)
        {
            foreach (Object myObj in myArr)
            {
                Console.Write("{0}{1}", mySeparator, myObj);
            }
            Console.WriteLine();
        }
    }
}

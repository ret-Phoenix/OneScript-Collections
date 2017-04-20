using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using ScriptEngine.HostedScript.Library;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneScript_Collections
{
    [ContextClass("Стек", "ExtStack")]
    public class ExtStack : AutoContext<ExtStack>
    {

        /// <summary>
        /// 
        /// </summary>
        public ExtStack()
        {
           Stack<IValue> _queue = new Stack<IValue>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ExtStack(int data)
        {
            Stack<IValue> _queue = new Stack<IValue>(data);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ExtStack(ArrayImpl data)
        {
            IValue[] ar = new IValue[data.Count()];
            foreach (var itm in data)
            {
                ar[ar.Count() - 1] = itm;
            }
            Stack<IValue> _queue = new Stack<IValue>(ar);
        }

        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor(IValue data)
        {
            if (data.DataType == DataType.Number)
            {
                return new ExtStack((int)data.AsNumber());
            }
            else if ((data.DataType == DataType.Object) && (data.GetType() == (new ArrayImpl()).GetType()))
            {
                return new ExtStack((ArrayImpl)data);
            }
            return new ExtStack();
        }
    }
}

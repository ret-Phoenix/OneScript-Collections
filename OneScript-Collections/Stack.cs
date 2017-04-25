// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneScript_Collections
{
    /// <summary>
    /// 
    /// </summary>
    [ContextClass("Стек", "Stack")]
    public class Stack : AutoContext<Stack>, ICollectionContext, IEnumerable<IValue>
    {
        private System.Collections.Generic.Stack<IValue> _stack;

        /// <summary>
        /// 
        /// </summary>
        public Stack()
        {
            _stack = new System.Collections.Generic.Stack<IValue>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public Stack(int data)
        {
            _stack = new System.Collections.Generic.Stack<IValue>(data);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public Stack(ArrayImpl data)
        {
            _stack = new System.Collections.Generic.Stack<IValue>(data);
        }



        /// <summary>
        /// Создание без параметров
        /// </summary>
        /// <returns></returns>
        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new Stack();
        }

        /// <summary>
        /// Инициализирует новый экземпляр Очереди, который содержит элементы, скопированные из указанной коллекции, и имеет емкость, достаточную для размещения всех скопированных элементов
        /// Инициализирует новый пустой экземпляр класса очереди с указанной начальной емкостью.
        /// </summary>
        /// <param name="data">Число/Массив</param>
        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor(IValue data)
        {
            if (data.DataType == DataType.Number)
            {
                return new Stack((int)data.AsNumber());
            }
            else if ((data.DataType == DataType.Object) && (data.GetType() == (new ArrayImpl()).GetType()))
            {
                return new Stack((ArrayImpl)data);
            }
            return new Stack();
        }

        /// <summary>
        /// Представление
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Стек";
        }


        #region Enumerator

        public IEnumerator<IValue> GetEnumerator()
        {
            foreach (var item in _stack)
            {
                yield return item;
            }
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(GetEnumerator());
        }

        #region IEnumerable<IValue> Members

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #endregion Enumerator


        /// <summary>
        /// Получает число элементов, содержащихся в интерфейсе Очереди
        /// </summary>
        /// <returns></returns>
        [ContextMethod("Количество", "Count")]
        public int Count()
        {
            return _stack.Count;
        }

        /// <summary>
        /// Удаляет все объекты из Очереди.
        /// </summary>
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            _stack.Clear();
        }

        /// <summary>
        /// Определяет, входит ли элемент в коллекцию очереди.
        /// </summary>
        /// <param name="val">Проверяемое значение</param>
        /// <returns></returns>
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue val)
        {
            return _stack.Contains(val);
        }



        /// <summary>
        /// Удаляет и возвращает объект в верхней части стека
        /// </summary>
        [ContextMethod("ВзятьИзОчереди", "Pop")]
        public IValue Pop()
        {
            return _stack.Pop();
        }

        /// <summary>
        /// Вставляет объект как верхний элемент стека
        /// </summary>
        /// <param name="val">Добавляемое значение</param>
        [ContextMethod("Добавить", "Push")]
        public void Push(IValue val)
        {
            _stack.Push(val);
        }

        /// <summary>
        /// Служит хэш-функцией по умолчанию
        /// </summary>
        /// <returns></returns>
        [ContextMethod("ПолучитьХешКод", "GetHashCode")]
        public int GetHashCode()
        {
            return _stack.GetHashCode();
        }

        /// <summary>
        /// Возвращает объект, находящийся в начале очереди, но не удаляет его.
        /// </summary>
        /// <returns></returns>
        [ContextMethod("Пик", "Peek")]
        public IValue Peek()
        {
            return _stack.Peek();
        }

        /// <summary>
        /// Новый массив, содержащий элементы, скопированные из очереди
        /// </summary>
        /// <returns></returns>
        [ContextMethod("ВМассив", "ToArray")]
        public ArrayImpl ToArray()
        {
            ArrayImpl inArray = new ArrayImpl();
            IValue[] val = _stack.ToArray();
            foreach (var itm in val)
            {
                inArray.Add(itm);
            }
            return inArray;
        }

        /// <summary>
        /// Устанавливает емкость равной фактическому количеству элементов в очереди, если это количество составляет менее 90 процентов текущей емкости.
        /// </summary>
        [ContextMethod("Обрезать", "TrimExcess")]
        public void TrimExcess()
        {
            _stack.TrimExcess();
        }
    }
}

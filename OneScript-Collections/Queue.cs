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
    [ContextClass("Очередь", "Queue")]
    public class Queue : AutoContext<Queue> , ICollectionContext, IEnumerable<IValue>
    {
        private System.Collections.Generic.Queue<IValue> _queue;

        /// <summary>
        /// 
        /// </summary>
        public Queue()
        {
            _queue = new System.Collections.Generic.Queue<IValue>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public Queue(int data)
        {
            _queue = new System.Collections.Generic.Queue<IValue>(data);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public Queue(ArrayImpl data)
        {
            _queue = new System.Collections.Generic.Queue<IValue>(data);
        }



        /// <summary>
        /// Создание без параметров
        /// </summary>
        /// <returns></returns>
        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new Queue();
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
                return new Queue((int)data.AsNumber());
            }
            else if ((data.DataType == DataType.Object) && (data.GetType() == (new ArrayImpl()).GetType()))
            {
                return new Queue((ArrayImpl)data);
            }
            return new Queue();
        }

        /// <summary>
        /// Представление
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Очередь";
        }

        
        #region Enumerator

        public IEnumerator<IValue> GetEnumerator()
        {
            foreach (var item in _queue)
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
            return _queue.Count;
        }

        /// <summary>
        /// Удаляет все объекты из Очереди.
        /// </summary>
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            _queue.Clear();
        }

        /// <summary>
        /// Определяет, входит ли элемент в коллекцию очереди.
        /// </summary>
        /// <param name="val">Проверяемое значение</param>
        /// <returns></returns>
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue val)
        {
            return _queue.Contains(val);
        }

        /// <summary>
        /// Копирует элементы коллекции в существующий массив, начиная с указанного значения индекса массива.
        /// </summary>
        /// <param name="inArray">Массив приемник</param>
        /// <param name="startIndex">Отсчитываемый от нуля индекс в массиве, указывающий начало копирования.</param>
        [ContextMethod("Скопировать", "CopyTo")]
        public void CopyTo(ArrayImpl inArray, int startIndex)
        {
            throw new Exception();
            //int newSize = inArray.Count() + (_stack.Count-startIndex);
            ////Console.WriteLine("newSize:" + newSize);
            //IValue[] internalArray = new IValue[newSize];
            //_stack.CopyTo(internalArray, startIndex);

            //int cnt = internalArray.Count();
            ////Console.WriteLine("s3");

            //for (int i = 0; i < cnt; i++)
            //{
            //    inArray.Add(internalArray[i]);
            //}
        }

        /// <summary>
        /// Удаляет объект из начала очереди и возвращает его.
        /// </summary>
        [ContextMethod("ВзятьИзОчереди", "Dequeue")]
        public IValue Dequeue()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// Добавляет объект в конец очереди
        /// </summary>
        /// <param name="val">Добавляемое значение</param>
        [ContextMethod("Добавить", "Enqueue")]
        public void Enqueue(IValue val)
        {
            _queue.Enqueue(val);
        }

        /// <summary>
        /// Определяет, равен ли заданный объект текущему объекту.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        //[ContextMethod("Равен", "Equals ")]
        //public bool isEquals(IValue val)
        //{
        //    return _stack.Equals(val);
        //}

        //[ContextMethod("ОсвободитьРесурсы", "Finalize ")]
        //public void Finalize()
        //{
        //    _stack.Finalize();
        //}

        /// <summary>
        /// Служит хэш-функцией по умолчанию
        /// </summary>
        /// <returns></returns>
        [ContextMethod("ПолучитьХешКод", "GetHashCode")]
        public int GetHashCode()
        {
            return _queue.GetHashCode();
        }

        /// <summary>
        /// Возвращает объект, находящийся в начале очереди, но не удаляет его.
        /// </summary>
        /// <returns></returns>
        [ContextMethod("Пик", "Peek")]
        public IValue Peek()
        {
            return _queue.Peek();
        }

        /// <summary>
        /// Новый массив, содержащий элементы, скопированные из очереди
        /// </summary>
        /// <returns></returns>
        [ContextMethod("ВМассив", "ToArray")]
        public ArrayImpl ToArray()
        {
            ArrayImpl inArray = new ArrayImpl();
            IValue[] val = _queue.ToArray();
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
            _queue.TrimExcess();
        }
    }
}

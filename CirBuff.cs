using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace config1v1
{
    class CirBuff<T>
    {
        T[] buff;
        int index; // normally holds index of last added item, not next free space
        Stack<int> markers;

        public CirBuff(int buffSize) {
            buff = new T[buffSize];
            index = -1;
            markers = new Stack<int>();
        }

        public void Add(T item)
        {
            MoveIndex(1);
            buff[index] = item;
        }

        public void Reset()
        {
            index = 0;
        }

        /*
        public List<T> ToList(int fromIndex, int howMuch)
        {
            List<T> r = new List<T>();
            T[] buffCopy = new T[buff.Length];
            buff.CopyTo(buffCopy, 0);
            return r;
        }
        */

        public int GetIndexAfterMove(int howMuch)
        {
            if (Math.Abs(howMuch) >= buff.Length)
            {
                throw new Exception("Moving range must be < buffer capacity. You moved " + Math.Abs(howMuch) + " but capacity is " + buff.Length);
            }

            int _index = index;
            _index += howMuch;

            // to the right?
            if (howMuch > 0)
            {
                if (_index >= buff.Length)
                {
                    _index = _index - buff.Length;
                }
            }
            // to the right?
            else if (howMuch < 0)
            {
                if (_index < 0)
                {
                    _index = buff.Length + howMuch;
                }
            }
            // we do not handle zero input
            return _index;
        }

        public void ResetIndex()
        {
            index = 0;
        }

        public void SetIndex(int newIndex)
        {
            index = newIndex;
        }

        public int GetCurrentIndex()
        {
            return index;
        }

        public void MoveIndex(int howMuch)
        {
            index = GetIndexAfterMove(howMuch);
        }

        /// <summary>
        /// Gets item at next index but does not move index.
        /// </summary>
        /// <returns>T</returns>
        public T GetItemAtNextIndex()
        {
            return buff[GetIndexAfterMove(1)];
        }

        /// <summary>
        /// Gets item in previous item but does not move index.
        /// </summary>
        /// <returns>T</returns>
        public T GetItemAtPrevIndex()
        {
            return buff[GetIndexAfterMove(-1)];
        }

        /// <summary>
        /// Gets item at provided index or current internal index, and optionally advance index to next position.
        /// </summary>
        /// <param name="index">Index of element to get</param>
        /// <returns>Item</returns>
        public T GetItem(int? atIndex = null, bool advance = true)
        {
            if(GetCurrentIndex() == -1)
            {
                throw new Exception("Buffer is empty.");
            }

            T item = buff[atIndex ?? GetCurrentIndex()];
            if (advance)
            {
                if (atIndex != null)
                {
                    index = (int)atIndex;
                }
                MoveIndex(1);
            }
            return item;
        }

        /// <summary>
        /// Push current index to stack.
        /// </summary>
        /// <returns></returns>
        public int MarkerPush()
        {
            markers.Push(index);
            return index;
        }

        /// <summary>
        /// Get last pushed marker index from stack.
        /// </summary>
        /// <returns></returns>
        public int MarkerPop()
        {
            index = markers.Pop();
            return index;
        }
    }
}

/*
// testiranje circular buffera
CirBuff<double> cb = new CirBuff<double>(10);
for (int i = 0; i < 10; i++) // ubacimo vise no sto more stat
{
    cb.Add(i + 0.1);
}

Console.WriteLine("Starting current index is: " + cb.GetCurrentIndex());
Console.WriteLine("Value at current index is at: " + cb.GetItem(null, false));
cb.MoveIndex(-3);
Console.WriteLine("Moving 3 back, and index is: " + cb.GetCurrentIndex());
Console.WriteLine("Value at current index is at: " + cb.GetItem(null, false));
cb.MoveIndex(8);
Console.WriteLine("Moving 8 forward, and index is: " + cb.GetCurrentIndex());
Console.WriteLine("Value at current index is at: " + cb.GetItem(null, false));
cb.Reset();
Console.WriteLine("After reset, previous: " + cb.GetItemAtPrevIndex());
*/

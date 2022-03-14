using System;
using System.Linq;

namespace RestaurantSystem.Models
{
    public class MyArray<T>
    {
        private T[] TArray { get; set; }
        private int Index = 0;
        private int Size = 5;

        public MyArray()
        {
            TArray = new T[Size];
        }

        public void AddElement(T elementToAdd)
        {
            if (CheckIfFull())
            {
                TArray = IncreaseListSize();
            }

            if (elementToAdd != null)
            {
                TArray[Index] = elementToAdd;
                Index++;
            }
            else
            {
                throw new ArgumentNullException(nameof(elementToAdd));
            }
        }
        private bool CheckIfFull()
        {
            if (Index == Size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private T[] IncreaseListSize()
        {
            Size += (Size / 2);
            var newArray = new T[Size];
            TArray.CopyTo(newArray, 0);
            return newArray;
        }
        public string[] ConvertToStringArray()
        {
            return TArray.Where(x => x != null)
                         .Select(x => x.ToString())
                         .ToArray();
        }


    }
}

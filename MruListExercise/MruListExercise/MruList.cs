using System;
using System.Collections.Generic;

namespace MruListExercise
{
    public class MruList
    {
        int _capacity;

        public List<string> Items { get; }

        public MruList()
        {
            Items = new List<string>();
        }

        public MruList(int capacity) : this()
        {
            if (capacity > 0)
                _capacity = capacity;
            else
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than 0");
        }

        public void Add(string item)
        {
            if (string.IsNullOrEmpty(item))
                throw new ArgumentException("Cannot be null or empty", nameof(item));

            Items.Remove(item);

            if (Items.Count == _capacity && _capacity > 0)
                Items.RemoveAt(Items.Count - 1);

            Items.Insert(0, item);
        }
    }
}

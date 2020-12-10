using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Blazor.Wpf.Components
{
    public class BList<T> : ComponentBase, IList<T>
    {
        public T this[int index] { get => _list[index]; set => throw new NotImplementedException(); }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        private List<T> _list { get; set; } = new List<T>();

       public void Add(T item)
       {
            _list.Add(item);
       }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        protected override void OnParametersSet()
        {
            StateHasChanged();
            base.OnParametersSet();
        }

    }
}

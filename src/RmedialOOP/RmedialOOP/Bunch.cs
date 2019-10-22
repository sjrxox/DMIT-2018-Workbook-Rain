using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmedialOOP
{
    public class Node<T>
    {
        public T Thing { get; set; }
        public Node<T> Next { get; set; }
    }


    public class Bunch<T>
    {
        // Private Fields
        private Node<T> _FirstItem;
        private Node<T> _LastName;

        public void Add(T item)
        {
            if(_FirstItem == null)
            {
                _FirstItem = new Node<T> { Thing = item };
                _LastName = _FirstItem;
            }
        }
    }
}

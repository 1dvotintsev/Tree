﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLibrary;

namespace Tree
{
    public class Node<T> where T : IInit, IComparable, ICloneable, new()
    {
        Node<T>? left;
        Node<T>? right;
        T? data;

        public T? Data
        {
            get => data; set => data = value;
        }

        public Node<T>? Left
        {
            get { return left; }
            set => left = value;
        }

        public Node<T>? Right
        {
            get { return right; }
            set => right = value;
        }

        public Node()
        {
            left = null;
            right = null;;
            data = default;
        }

        public Node(T item)
        {
            left = null;
            right = null;
            data = item;
        }

        public override string? ToString()
        {
            if (data == null)
            {
                return "";
            }
            else
            {
                return Data.ToString();
            }
        }
    }
}

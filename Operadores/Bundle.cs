﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operadores
{
    public class Bundle : IEnumerable<Toy>
    {
        public int Size { get; private set; }
        public int ToyCount { get { return TrueBox.Count; } }

        private List<Toy> TrueBox;

        public Bundle(int size)
        {
            Size = size;
            TrueBox = new List<Toy>(Size);
        }

        public bool TryAddToy(Toy t)
        {
            if (ToyCount >= Size) return false;
            TrueBox.Add(t);
            return true;
        }

        public static Bundle operator +(Bundle bundle, Toy t)
        {
            var newBundle = new Bundle(bundle.Size + 1);
            foreach (var toy in bundle)
            {
                newBundle.TryAddToy(toy);
            }
            newBundle.TryAddToy(t);
            return newBundle;
        }

        public static Bundle operator +(Toy t, Bundle bundle)
        {
            if (!bundle.TryAddToy(t))
                throw new InvalidOperationException("Bundle is already full!");
            return bundle;
        }

        public static Bundle operator +(Bundle a, Bundle b)
        {
            Bundle bundle = new Bundle(a.Size + b.Size);
            foreach (var toy in a)
            {
                bundle.TryAddToy(toy);
            }
            foreach (var toy in b)
            {
                bundle.TryAddToy(toy);
            }
            return bundle;
        }

        public override string ToString()
        {
            return "Bundle (" + Size + "/" + ToyCount + ") [" + String.Join(", ", TrueBox.Select(t => t.Name)) + "]";
        }

        public IEnumerator<Toy> GetEnumerator()
        {
            return TrueBox.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return TrueBox.GetEnumerator();
        }
    }
}

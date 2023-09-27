using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    abstract class MultimediaComponent
    {
        protected string Name;

        public MultimediaComponent(string name)
        {
            this.Name = name;
        }

        public abstract void Add(MultimediaComponent component);
        public abstract void Remove(MultimediaComponent component);
        public abstract void Display(int depth);
    }



}

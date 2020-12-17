using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace DesignPatterns
{

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large
    }


    public class Product
    {
        public String Name { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        public Product(string name, Size size, Color color)
        {
            Name = name;
            Size = size;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Name}, Color {Color} Size: {Size}";
        }

    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }


    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }


    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public void AddSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                {
                    yield return i;
                }
            }

                    
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           var pnd = Console.ReadLine();

            var score = Console.ReadLine();

            Console.WriteLine(score);


        }

        static void Filter()
        {
            var apple = new Product("apple", Size.Small, Color.Red);
            var tree = new Product("tree", Size.Large, Color.Green);
            var house = new Product("house", Size.Large, Color.Blue);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();
            foreach (var i in bf.Filter(products, new ColorSpecification(Color.Blue)))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Hello World!");
        }


    }
}

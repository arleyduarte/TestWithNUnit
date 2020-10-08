using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Fundamentals
{
    public class ClassB : IClassB
    {
        public void MethodB(string name)
        {
            Console.WriteLine($"ClassB  MethodB {name}");
        }
    }
}

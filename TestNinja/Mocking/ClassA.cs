using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Fundamentals
{
    public class ClassA
    {

        private IClassB _classB;


        public  ClassA(IClassB classB)
        {
            _classB = classB;

        }


        public void MethodA(string param)
        {
            Console.WriteLine("ClassA  MethodA");
            if(param == null)
                return;
            

            _classB.MethodB("X");
        }
    }
}

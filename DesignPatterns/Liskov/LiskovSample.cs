using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Liskov
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }


        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }


    public class Square : Rectangle
    {

        public override int Width
        {
            set { base.Height = base.Width = value; }
        }

        public override int Height
        {
            set { base.Height = base.Width = value; }
        }
    }

    //Liskov sustitution principle
    public  class LiskovSample
    {
        static public int Area(Rectangle r) => r.Height * r.Width;

        Rectangle r1 = new Rectangle(2,3);

        //Este es el principio se puede ir atras en herencia
        Rectangle sq = new Square();


    }



}

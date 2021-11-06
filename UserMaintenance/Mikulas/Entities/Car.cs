using Mikulas.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas.Entities
{
    class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            Image ImageFile = Image.FromFile("Images/car.png");
            g.DrawImage(ImageFile, new Rectangle(0, 0, Width, Height));
        }
    }
}

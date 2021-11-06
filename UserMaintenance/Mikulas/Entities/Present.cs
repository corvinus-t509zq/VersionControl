using Mikulas.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas.Entities
{
    public class Present : Toy
    {
        public SolidBrush PresentColorribbon { get; private set; }
        public SolidBrush PresentColorbox { get; private set; }
        public Present(Color ribbon, Color box)
        {
            PresentColorribbon = new SolidBrush(ribbon);
            PresentColorbox = new SolidBrush(box);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(PresentColorbox, 0, 0, Width, Height);
            //függőleges szalag
            g.FillRectangle(PresentColorribbon, Height / 5 * 2, 0, Width / 5, Height);
            //vízszintes szalag
            g.FillRectangle(PresentColorribbon, 0, Height / 5 * 2, Width, Height / 5);
        }
    }
}

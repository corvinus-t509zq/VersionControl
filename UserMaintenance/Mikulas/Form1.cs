using Mikulas.Abstractions;
using Mikulas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikulas
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; } 
        }


        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void CreateTimer_Tick(object sender, EventArgs e)
        {
            var Toy = Factory.CreateNew();
            _toys.Add(Toy);
            Toy.Left = -Toy.Width;
            mainPanel.Controls.Add(Toy);
        }

        private void ConveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxposition = 0;
            foreach (var ball in _toys)
            {
                ball.MoveToy();
                if (ball.Left > maxposition)
                {
                    maxposition = ball.Left;
                }
            }
            if (maxposition > 1000)
            {
                var oldestball = _toys[0];
                mainPanel.Controls.Remove(oldestball);
                _toys.Remove(oldestball);
            }
        }
    }
}

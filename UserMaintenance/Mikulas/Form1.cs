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
            set { _factory = value; DisplayNext(); } 
        }


        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
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
         private Toy _nextToy;
        private void DisplayNext()
        {
            if (_nextToy!= null)
            {
                Controls.Remove(_nextToy);
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Top = labelNext.Top + labelNext.Height + 20;
            _nextToy.Left = labelNext.Left;
            Controls.Add(_nextToy);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //car
            Factory = new CarFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ball
            Factory = new BallFactory
            {
                BallColor = buttonColor.BackColor
            };

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //színválasztás
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = button.BackColor;
            if (cd.ShowDialog() != DialogResult.OK) return;
            button.BackColor = cd.Color;

        }

        private void buttonPresent_Click(object sender, EventArgs e)
        {
            //Present
            Factory = new PresentFactory
            {
                PresentColorBox = buttonPresentColor1.BackColor,
                PresentColorRibbon = buttonPresentColor2.BackColor

            };
        }

      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week08.Entities;
using Week08.Abstractions;

namespace Week08
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;
        Toy _nextToy;
        public IToyFactory Factory
        {
            get { return _factory; }
            set 
            {
                _factory = value;
                DisplayNext();    
            }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
            toy.Left = toy.Width * (-1);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var item in _toys)
            {
                item.MoveToy();
                if (item.Left > maxPosition)
                {
                    maxPosition = item.Left;
                }
            }
            if (maxPosition == 1000)
            {
                var oldestBall = _toys[0];
                mainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = button3.BackColor
            };
        }
        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                Controls.Remove(_nextToy);
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left + label1.Width / 2 - _nextToy.Width / 2;
            Controls.Add(_nextToy);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = button3.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button3.BackColor = cd.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory()
            {
                ribbon = button5.BackColor,
                box = button6.BackColor
            };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = button5.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button5.BackColor = cd.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = button6.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button6.BackColor = cd.Color;
            }
        }
    }
}

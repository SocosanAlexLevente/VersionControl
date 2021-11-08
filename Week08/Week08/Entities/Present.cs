using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week08.Abstractions;

namespace Week08.Entities
{
    class Present : Toy
    {
        public SolidBrush szalag { get; private set; }
        public SolidBrush brush { get; private set; }
        public Present(Color ribbon, Color box)
        {
            szalag = new SolidBrush(ribbon);
            brush = new SolidBrush(box);
        }
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(brush, 0, 0, Width, Height);
            g.FillRectangle(szalag,0,Height/5*2,Width,Height/5);
            g.FillRectangle(szalag, Width/5*2, 0, Width/5, Height);
        }
    }
}

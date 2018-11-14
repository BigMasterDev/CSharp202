using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Loy.GDI.Example
{
    class Arrow
    {
        int x1, y1, x2, y2;
        Color color;

        public int X1 { get => x1; set => x1 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y2 { get => y2; set => y2 = value; }
        public Color Color { get => color; set => color = value; }

        public Arrow()
        {
            X1 = 0; Y1 = 0; X2 = 0; Y2 = 0;
            color = Color.Black;
        }
        public void Show(PaintEventArgs e)
        {
            Draw(e);
        }
        protected virtual void Draw(PaintEventArgs e)
        {
            using (Pen myPen = new Pen(Color.Black))
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(-7, -7, 0, 0);
                myPath.AddLine(7, -7, 0, 0);
                myPen.CustomEndCap = new CustomLineCap(null, myPath);
                myPen.Color = color;
                e.Graphics.DrawLine(myPen, x1, y1, x2, y2);
            }
        }
    }
}

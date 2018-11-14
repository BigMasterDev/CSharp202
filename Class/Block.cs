using System.Drawing;
using System.Windows.Forms;

namespace Loy.GDI.Example
{
    public class Block
    {
        // backing fileds
        int x, y, height, width = 0;
        Color color = Color.AliceBlue;
        string name = string.Empty;

        // properties
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public Color Color { get => color; set => color = value; }
        public string Name { get => name; set => name = value; }

        public void Show(PaintEventArgs e)
        {
            DrawBlock(e);
            DrawText(e);
        }
        protected virtual void DrawBlock(PaintEventArgs e)
        {
            var myFillRec = new Rectangle(x, y, width, height); // x,y,width,height
            var drawBrush = new SolidBrush(Color);
            e.Graphics.FillRectangle(drawBrush, myFillRec);
        }
        protected virtual void DrawText(PaintEventArgs e)
        {
            var drawFont = new Font("Segoe UI", 10);
            var drawBrush = new SolidBrush(Color.Black);
            var drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            Rectangle rect1 = new Rectangle(X, Y, Width, Height);
            e.Graphics.DrawString(name, drawFont, drawBrush, rect1, drawFormat);
        }

    }
}

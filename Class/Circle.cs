using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Loy.GDI.Example
{
    public class Circle : Block
    {
        protected override void DrawBlock(PaintEventArgs e)
        {
            var drawBrush = new SolidBrush(Color);
            e.Graphics.FillEllipse(drawBrush, new Rectangle(X, Y, Width, Height));
        }
    }
}

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Loy.GDI.Example
{
    public class RoundedRect : Block
    {
        protected override void DrawBlock(PaintEventArgs e)
        {
            int radius = 6;
            Rectangle rec = new Rectangle(X, Y, Width, Height);
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rec.Location, size);
            GraphicsPath path = new GraphicsPath();
            if (radius == 0) path.AddRectangle(rec);
            path.AddArc(arc, 180, 90); // top left arc  
            arc.X = rec.Right - diameter; // top right arc  
            path.AddArc(arc, 270, 90);
            arc.Y = rec.Bottom - diameter; // bottom right arc  
            path.AddArc(arc, 0, 90); // bottom left arc 
            arc.X = rec.Left;
            path.AddArc(arc, 90, 90);
            // rounded rectangle is ready to be drawn
            path.CloseFigure();
            var drawBrush = new SolidBrush(Color);
            e.Graphics.FillPath(drawBrush, path);
        }
    }
}

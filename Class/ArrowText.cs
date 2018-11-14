using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;

namespace Loy.GDI.Example
{ 
    class ArrowText: Arrow
    {
        string text = string.Empty;
        public string Text { get => text; set => text = value; }

        protected override void Draw(PaintEventArgs e)
        {
            base.Draw(e);
            DrawText(e);
        }
        private void DrawText(PaintEventArgs e)
        {
            var gr = e.Graphics;
            PointF start_point = new PointF(X1, Y1);
            PointF end_point = new PointF(X2, Y2);
            var drawFont = new Font("Segoe UI", 10);
            var drawBrush = new SolidBrush(Color);
            bool text_above_segment = true;
            float dx = end_point.X - start_point.X;
            float dy = end_point.Y - start_point.Y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

            dx /= dist; dy /= dist;
            GraphicsState state = gr.Save();
            if (text_above_segment)
                gr.TranslateTransform(0, -gr.MeasureString(Text, drawFont).Height, MatrixOrder.Append);
            float angle = (float)(180 * Math.Atan2(dy, dx) / Math.PI);
            gr.RotateTransform(angle, MatrixOrder.Append);
            gr.TranslateTransform(start_point.X, start_point.Y, MatrixOrder.Append);
            gr.DrawString(Text, drawFont, drawBrush, 0, 0);
            gr.Restore(state);
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Loy.GDI.Example
{
    public class Clock
    {
        public void DrawClockFace(Graphics e, Size ClientSize)
        {
            // Draw.
            using (Pen thick_pen = new Pen(Color.Blue, 4))
            {
                // Outline.
                e.DrawEllipse(thick_pen,
                    (-ClientSize.Width / 2) + 2, (-ClientSize.Height / 2) + 2,
                    ClientSize.Width-5, ClientSize.Height-5);

                // Get scale factors.
                float outer_x_factor = 0.45f * ClientSize.Width;
                float outer_y_factor = 0.45f * ClientSize.Height;
                float inner_x_factor = 0.425f * ClientSize.Width;
                float inner_y_factor = 0.425f * ClientSize.Height;
                float big_x_factor = 0.4f * ClientSize.Width;
                float big_y_factor = 0.4f * ClientSize.Height;

                // Draw the tick marks.
                thick_pen.StartCap = LineCap.Triangle;
                for (int minute = 1; minute <= 60; minute++)
                {
                    double angle = Math.PI * minute / 30.0;
                    float cos_angle = (float)Math.Cos(angle);
                    float sin_angle = (float)Math.Sin(angle);
                    PointF outer_pt = new PointF(
                        outer_x_factor * cos_angle,
                        outer_y_factor * sin_angle);
                    if (minute % 5 == 0)
                    {
                        PointF inner_pt = new PointF(
                            big_x_factor * cos_angle,
                            big_y_factor * sin_angle);
                        e.DrawLine(thick_pen, inner_pt, outer_pt);
                    }
                    else
                    {
                        PointF inner_pt = new PointF(
                            inner_x_factor * cos_angle,
                            inner_y_factor * sin_angle);
                        e.DrawLine(Pens.Blue, inner_pt, outer_pt);
                    }
                }
                // Draw the center.
                e.FillEllipse(Brushes.Blue, -5, -5, 10, 10);
            }
        }

        // Draw the clock's hands.
        public void DrawClockHands(Graphics e, Size ClientSize)
        {
            using (Pen thick_pen = new Pen(Color.Red, 4))
            {
                // Get the hour and minute plus any fraction that has elapsed.
                DateTime now = DateTime.Now;
                float hour = now.Hour +
                    now.Minute / 60f +      // Plus 60th of hours.
                    now.Second / 3600f;     // Plus 3600th of hours.
                float minute = now.Minute +
                    now.Second / 60f;       // Plus 60th of minutes.

                // Draw the hour hand.
                PointF center = new PointF(0, 0);
                float hour_x_factor = 0.2f * ClientSize.Width;
                float hour_y_factor = 0.2f * ClientSize.Height;
                double hour_angle = -Math.PI / 2 + 2 * Math.PI * hour / 12.0;
                PointF hour_pt = new PointF(
                    (float)(hour_x_factor * Math.Cos(hour_angle)),
                    (float)(hour_y_factor * Math.Sin(hour_angle)));
                thick_pen.Color = Color.Red;
                e.DrawLine(thick_pen, hour_pt, center);

                // Draw the minute hand.
                float minute_x_factor = 0.3f * ClientSize.Width;
                float minute_y_factor = 0.3f * ClientSize.Height;
                double minute_angle = -Math.PI / 2 + 2 * Math.PI * minute / 60.0;
                PointF minute_pt = new PointF(
                    (float)(minute_x_factor * Math.Cos(minute_angle)),
                    (float)(minute_y_factor * Math.Sin(minute_angle)));
                thick_pen.Width = 2;
                e.DrawLine(thick_pen, minute_pt, center);

                // Draw the second hand.
                float second_x_factor = 0.4f * ClientSize.Width;
                float second_y_factor = 0.4f * ClientSize.Height;
                double second_angle = -Math.PI / 2 +
                    2 * Math.PI * (int)(now.Second) / 60.0;
                PointF second_pt = new PointF(
                    (float)(second_x_factor * Math.Cos(second_angle)),
                    (float)(second_y_factor * Math.Sin(second_angle)));
                e.DrawLine(Pens.Red, second_pt, center);
            }
        }
    }
}

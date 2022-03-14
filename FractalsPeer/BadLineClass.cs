using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsPeer
{
    class BadLineClass : FractalsParentClass
    {
        public static void DrawFractal(int depth, Canvas canvas, Point a, Point b)
        {
            Line line = new Line();
            line.X1 = a.X;
            line.Y1 = a.Y;
            line.X2 = b.X;
            line.Y2 = b.Y;
            double dx = b.X - a.X;
            double dy = a.Y - b.Y;
            double dist = (double)Math.Sqrt(dx * dx + dy * dy);
            double thirdDist = dist / 3.0;
            double phi = Math.Atan2(dy, dx);
            line.Stroke = Brushes.Black;
            Point c = new Point(a.X + dx / 3, a.Y + dy / 3);
            Point d = new Point(b.X - dx / 3, b.Y - dy / 3);
            Point e = new Point(a.X + Math.Cos(phi + Math.PI/3.0) * thirdDist /2.0,
                    a.Y + Math.Cos(phi + Math.PI/3.0) * thirdDist / 2.0);
            canvas.Children.Add(line);
            if (depth > 0)
            {
                DrawFractal(depth - 1, canvas, a, c);
                DrawFractal(depth - 1, canvas, d, b);
                DrawFractal(depth - 1, canvas, c, e);
                DrawFractal(depth - 1, canvas, e, d);
            }
            else 
            {
                
                Line lineEr = new Line();
                lineEr.X1 = c.X;
                lineEr.X2 = d.X;
                lineEr.Y1 = c.Y;
                lineEr.Y2 = d.Y;
                Line lineV1 = new Line();
                lineV1.X1 = c.X;
                lineV1.X2 = e.X;
                lineV1.Y1 = c.Y;
                lineV1.Y2 = e.Y;
                Line lineV2 = new Line();
                lineV2.X1 = e.X;
                lineV2.X2 = d.X;
                lineV2.Y1 = e.Y;
                lineV2.Y2 = d.Y;
                lineEr.Stroke = Brushes.GhostWhite;
                lineV1.Stroke = Brushes.Black;
                lineV2.Stroke = Brushes.Black;
                canvas.Children.Add(lineEr);
                canvas.Children.Add(lineV1);
                canvas.Children.Add(lineV2);
            }
        }
    }
}

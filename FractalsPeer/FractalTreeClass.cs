using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsPeer
{
    internal class FractalTreeClass: FractalsParentClass
    {
        /// <summary>
        /// Рекурсивный метод отрисовки дерева.
        /// </summary>
        /// <param name="startPoint">Точка, с которой начинается отрисовка.</param>
        /// <param name="len">Длина отрезка.</param>
        /// <param name="k">Коэффициент длины начального отрезка к следующему.</param>
        /// <param name="a1">Угол наклона первого отрезка.</param>
        /// <param name="a2">Угол наклона второго отрезка.</param>
        /// <param name="aCrnt">Угол наклона данного отрезка.</param>
        /// <param name="rDepth">Глубина рекурсии.</param>
        /// <param name="canvas">Контейнер Canvas, в котором отрисовывается фрактал.</param>
        
        public static void DrawFractal(Point startPoint, double len, double k, double a1, double a2, double aCrnt, int rDepth, Canvas canvas) 
        {
            double XS = startPoint.X;
            double YS = startPoint.Y;
            double XE = XS + len * Math.Cos(aCrnt * Math.PI * 2 / 360.0);
            double YE = YS + len * Math.Sin(aCrnt * Math.PI * 2 / 360.0);
            Line line = new();
            line.Stroke = Brushes.Black;
            Console.WriteLine(XS);
            line.X1 = (int)XS;
            line.Y1 = (int)YS;
            line.X2 = (int)XE;
            line.Y2 = (int)YE;
            canvas.Children.Add(line);
            try
            {
                if (rDepth == 0)
                {
                    return;
                }
                else
                {
                    DrawFractal(new Point(XE, YE), len * k, k, a1, a2, aCrnt - a1, rDepth-1, canvas);
                    DrawFractal(new Point(XE, YE), len * k, k, a1, a2, aCrnt + a2, rDepth-1, canvas);
                }
            }
            catch (StackOverflowException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
            catch (Exception ex2) 
            {
                Console.WriteLine(ex2.Message);
            }
        }
    }
}

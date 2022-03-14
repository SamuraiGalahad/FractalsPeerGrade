using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsPeer
{
    class TriangleSerpClass: FractalsParentClass
    {
        /// <summary>
        /// Метод отрисовки треугольника Серпински.
        /// </summary>
        /// <param name="depth">Глубина рекурсии.</param>
        /// <param name="canvas">Конкретный canvas.</param>
        /// <param name="a">Первая точка треугольника.</param>
        /// <param name="b">Вторая точка трегольника.</param>
        /// <param name="c">Третья точка треугольника.</param>

        public static void DrawFractal(int depth, Canvas canvas, Point a, Point b, Point c) 
        {
            Line line1 = new Line();
            line1.X1 = (int)a.X;
            line1.X2 = (int)b.X;
            line1.Y1 = (int)a.Y;
            line1.Y2 = (int)b.Y;
            Line line2 = new Line();
            line2.X1 = (int)a.X;
            line2.X2 = (int)c.X;
            line2.Y1 = (int)a.Y;
            line2.Y2 = (int)c.Y;
            Line line3 = new Line();
            line3.X1 = (int)b.X;
            line3.X2 = (int)c.X;
            line3.Y1 = (int)b.Y;
            line3.Y2 = (int)c.Y;
            line1.Stroke = Brushes.Black;
            line2.Stroke = Brushes.Black;
            line3.Stroke = Brushes.Black;
            canvas.Children.Add(line1);
            canvas.Children.Add(line2);
            canvas.Children.Add(line3);
            try
            {
                if (depth == 0)
                {
                    return;
                }
                else
                {
                    DrawFractal(depth - 1, canvas, GetHalf(line1), GetHalf(line2), GetHalf(line3));
                }
            }
            catch (StackOverflowException)
            {
            }
            catch (Exception) 
            {
            }
        }

        /// <summary>
        /// Метод поиска точки середины отрезка.
        /// </summary>
        /// <param name="line">Отрезок.</param>
        /// <returns>Точка середины отрезка.</returns>

        private  static Point GetHalf(Line line) 
        {
            return new Point((double)(line.X1 + line.X2) / 2.0, (double)(line.Y1 + line.Y2) / 2.0);
        }

    }
}

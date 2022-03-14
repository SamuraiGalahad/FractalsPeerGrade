using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsPeer
{
    class CubeFractalClass:FractalsParentClass
    {
        Point[] _points = new Point[4]{ new Point(100, 200), new Point(100, 500),
            new Point(400, 500), new Point(400, 200)};
        Point[] _pointsOnLine = new Point[8] {new Point(100, 300), new Point(100, 400), new Point(200, 500),
        new Point(300, 500), new Point(400, 400), new Point(400, 300), new Point(300,200), new Point(200, 200)};
        double daw;
        Point[] _pointsInCube = new Point[4] {new Point(200, 300), new Point(200, 400),
        new Point(300, 400), new Point(300, 300)};
        CubeFractalClass[] cubs;


        public CubeFractalClass(Point[] points) 
        {
            _points = points;
            daw = 1.0 / 3 * (_points[1].X - _points[0].X);
            _pointsOnLine = new Point[8] {new Point(_points[0].X, _points[0].Y + daw),
            new Point(_points[0].X, _points[0].Y + 2 * daw),
            new Point(_points[1].X + daw, _points[1].Y),
            new Point(_points[1].X + 2 * daw, _points[1].Y),
            new Point(_points[2].X, _points[2].Y - daw),
            new Point(_points[2].X, _points[2].Y - 2 * daw),
            new Point(_points[3].X - daw, _points[3].Y),
            new Point(_points[3].X - 2 * daw, _points[3].Y)};
            _pointsInCube = new Point[4] {new Point(_points[0].X + daw, _points[0].Y + daw),
            new Point(_points[1].X + daw, _points[1].Y - daw),
            new Point(_points[2].X - daw, _points[2].Y - daw),
            new Point(_points[3].X - daw, _points[3].Y + daw)};
            cubs = new CubeFractalClass[8]
                {
                    new CubeFractalClass(new Point[4]{_points[0], _pointsOnLine[0], _pointsInCube[0], _pointsOnLine[7]}),
                    new CubeFractalClass(new Point[4]{_points[1], _pointsOnLine[1], _pointsInCube[1], _pointsOnLine[2]}),
                    new CubeFractalClass(new Point[4]{_points[2], _pointsOnLine[3], _pointsInCube[2], _pointsOnLine[4]}),
                    new CubeFractalClass(new Point[4]{_points[3], _pointsOnLine[6], _pointsInCube[3], _pointsOnLine[5]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[0], _pointsOnLine[1], _pointsInCube[0], _pointsInCube[1]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[2], _pointsOnLine[3], _pointsInCube[2], _pointsInCube[3]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[4], _pointsOnLine[5], _pointsInCube[4], _pointsInCube[5]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[6], _pointsOnLine[7], _pointsInCube[6], _pointsInCube[7]})
                };
        }
        public CubeFractalClass() 
        {
            daw = 1.0 / 3 * (_points[1].X - _points[0].X);
            cubs = new CubeFractalClass[8]
                {
                    new CubeFractalClass(new Point[4]{_points[0], _pointsOnLine[0], _pointsInCube[0], _pointsOnLine[7]}),
                    new CubeFractalClass(new Point[4]{_points[1], _pointsOnLine[1], _pointsInCube[1], _pointsOnLine[2]}),
                    new CubeFractalClass(new Point[4]{_points[2], _pointsOnLine[3], _pointsInCube[2], _pointsOnLine[4]}),
                    new CubeFractalClass(new Point[4]{_points[3], _pointsOnLine[6], _pointsInCube[3], _pointsOnLine[5]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[0], _pointsOnLine[1], _pointsInCube[0], _pointsInCube[1]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[2], _pointsOnLine[3], _pointsInCube[2], _pointsInCube[3]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[4], _pointsOnLine[5], _pointsInCube[4], _pointsInCube[5]}),
                    new CubeFractalClass(new Point[4]{_pointsOnLine[6], _pointsOnLine[7], _pointsInCube[6], _pointsInCube[7]})
                };
        }

        public override void DrawFractal(int depth, Canvas canvas) 
        {
            Polygon pol = new Polygon();
            foreach (Point point in _points) 
            {
                pol.Points.Add(point);
            }
            Polygon polIn = new Polygon();
            foreach (Point point in _pointsInCube) 
            {
                polIn.Points.Add(point);
            }
            pol.Fill = Brushes.Black;
            polIn.Fill = Brushes.GhostWhite;
            canvas.Children.Add(pol);
            if (depth <= 0)
            {
                return;
            }
            else 
            {
                canvas.Children.Add(polIn);
                foreach (CubeFractalClass frac in cubs) 
                {
                    frac.DrawFractal(depth - 1, canvas);
                }
            }
            
        }
    }
}

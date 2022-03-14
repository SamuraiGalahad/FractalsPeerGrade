using System;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsPeer
{
    /// <summary>
    /// Родительский класс для всех фракталов.
    /// </summary>

    class FractalsParentClass
    {
        private int recDef = 10;
        public virtual void DrawFractal(int depth, Canvas canvas) 
        {

        }
    }
}

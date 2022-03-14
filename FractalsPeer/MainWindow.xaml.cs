using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalsPeer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        // Индекс фрактала. 0 - не выбран.
        private int frctlInd = 0;

        // Глубина рекурсии.
        private double rDepth = 0;

        // Параметры для дерева.
        // Коэффициет длины.
        private double coeff = 0.7;
        // Значение первого угла в градусах.
        private int alpha = 45;
        // Значение второго угла в градусах.
        private int betta = 45;

        // Значение точек для треугольника.
        Point startA = new Point(100, 400);
        Point startB = new Point(500, 400);
        Point startC = new Point(300, 100);

        // Точки для кривой Коха.
        Point sA = new Point(200, 300);
        Point sB = new Point(500, 300);

        /// <summary>
        /// Выбор фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FractalsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            Point point = new Point(300, 240);
            if (combobox != null) 
            {
                switch (((ComboBoxItem)combobox.SelectedItem).Content)
                {
                    case "Дерево Пифагора": 
                        frctlInd = 1; RedrawFractal();
                        ViewElementsForTree(); break;
                    case "Кривая Коха": 
                        frctlInd = 2; RedrawFractal();
                        HideElementsForTree(); break;
                    case "Ковер Серпинского": 
                        frctlInd = 3; RedrawFractal();
                        HideElementsForTree(); break;
                    case "Треугольник Серпинского": 
                        frctlInd = 4; RedrawFractal();
                        HideElementsForTree(); break;
                    case "Множество Кантора": frctlInd = 5; RedrawFractal(); break;
                    default: frctlInd = 0;
                        HideElementsForTree(); break;
                }
            }
        }

        /// <summary>
        /// Метод события, который меняет глубину рекурсии 
        /// при изменении значения слайдера.
        /// </summary>
        /// <param name="sender">Сам слайдер.</param>
        /// <param name="e"></param>

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider? slider = sender as Slider;
            if (slider.Value != null)
            {
                rDepth = slider.Value;
                textBlockR.Text = $"Глубина рекурсии: {(int)rDepth}";
            }
            RedrawFractal();
            
        }

        /// <summary>
        /// Метод перерисовки фракталов при изменении парметров. 
        /// </summary>
        
        private void RedrawFractal() 
        {
            canvas.Children.Clear();
            Point point = new Point(290, 240);
            if (frctlInd == 1)
            {
                FractalTreeClass.DrawFractal(point, 70, coeff, alpha, betta, -90, (int)rDepth, canvas);
            }
            else if (frctlInd == 2)
            {
                BadLineClass.DrawFractal((int)rDepth, canvas, sA, sB);
            }
            else if (frctlInd == 3) 
            {
                CubeFractalClass fractal3 = new CubeFractalClass();
                fractal3.DrawFractal((int)rDepth, canvas);
            }
            else if (frctlInd == 4)
            {
                TriangleSerpClass.DrawFractal((int)rDepth, canvas, startA, startB, startC);
            }
        }

        /// <summary>
        /// Метод события, который меняет  коэффициент длины
        /// при изменении значения.
        /// </summary>
        /// <param name="sender">Сам слайдер.</param>
        /// <param name="e"></param>

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider? slider = sender as Slider;
            if (slider.Value != null)
            {
                coeff = slider.Value;
                textBlockKC.Text = $"Значение: {(int)(coeff * 100)/ 1}%";
            }
            RedrawFractal();
        }

        /// <summary>
        /// При изменении слайдера угла a изменяется
        /// его значение и перерисовывается сам фрактал.
        /// </summary>
        /// <param name="sender">Сам слайдер.</param>
        /// <param name="e"></param>

        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider? slider = sender as Slider;
            if (slider.Value != null)
            {
                alpha = (int)slider.Value;
                textBlockAA.Text = $"Значение: {alpha}*";
            }
            RedrawFractal();
        }

        /// <summary>
        /// При изменении слайдера угла b изменяется
        /// его значение и перерисовывается сам фрактал.
        /// </summary>
        /// <param name="sender">Сам слайдер.</param>
        /// <param name="e"></param>

        private void Slider_ValueChanged_3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider? slider = sender as Slider;
            if (slider.Value != null)
            {
                betta = (int)slider.Value;
                textBlockBA.Text = $"Значение: {betta}*";
            }
            RedrawFractal();
        }

        /// <summary>
        /// Метод, который пенеяет в разметке XAML параметры
        /// Visibility для параметров дерева на Visible.
        /// </summary>

        private void ViewElementsForTree() 
        {
            textBlockAA.Visibility = Visibility.Visible;
            textBlockBA.Visibility = Visibility.Visible;
            textBlockKC.Visibility = Visibility.Visible;
            textBlockA.Visibility = Visibility.Visible;
            textBlockB.Visibility = Visibility.Visible;
            textBlockK.Visibility = Visibility.Visible;
            slider3.Visibility = Visibility.Visible;
            slider2.Visibility = Visibility.Visible;
            slider1.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Метод, который пенеяет в разметке XAML параметры
        /// Visibility для параметров дерева на Hidden.
        /// </summary>

        private void HideElementsForTree()
        {
            textBlockAA.Visibility = Visibility.Hidden;
            textBlockBA.Visibility = Visibility.Hidden;
            textBlockKC.Visibility = Visibility.Hidden;
            textBlockA.Visibility = Visibility.Hidden;
            textBlockB.Visibility = Visibility.Hidden;
            textBlockK.Visibility = Visibility.Hidden;
            slider3.Visibility = Visibility.Hidden;
            slider2.Visibility = Visibility.Hidden;
            slider1.Visibility = Visibility.Hidden;
        }
    }
}

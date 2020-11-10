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

namespace Dzz_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class Circel 
    {
        public double r;
        public double lenght;
        public double area;

        public double Radius
        {
            set 
            {
                if (value > 0)
                    r = value;
            }
            get {
                return r;
            }
        }
        public double AreaC(double r) 
        {
            double S = Math.PI * Math.Pow(r, 2);
            return S;
        }
        public double LenghtC(double r)
        {
            double L = 2 * Math.PI * r;
            return L;
        }
        public bool Intheround(double x, double y, double r) 
        {
            bool f1;
            if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) < r)
                f1 = true;
            else
                f1 = false;
            return f1; 
        }
        public override string ToString()
        {
            return $"Круг радиуса {r:0.000} см";
       }
    }

    public partial class MainWindow : Window
    {
        List<Circel> Circels = new List<Circel>
        {
            new Circel { r = 1, lenght=2 * Math.PI * 1, area=Math.PI * Math.Pow(1, 2) },
            new Circel { r = 2, lenght=2 * Math.PI * 2, area=Math.PI * Math.Pow(2, 2) },
            new Circel { r = 3, lenght=2 * Math.PI * 3, area=Math.PI * Math.Pow(3, 2) },
            new Circel { r = 4, lenght=2 * Math.PI * 4, area=Math.PI * Math.Pow(4, 2) },
            new Circel { r = 5, lenght=2 * Math.PI * 5, area=Math.PI * Math.Pow(5, 2) },
            new Circel { r = 6, lenght=2 * Math.PI * 6, area=Math.PI * Math.Pow(6, 2) }
        };
        public void updateCircelList()
        {
            LbCircle.Items.Clear();
            foreach (var circel in Circels)
            {
                LbCircle.Items.Add(circel);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            updateCircelList();
        }
        private void bAddCircle_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Circel circel = new Circel();
                circel.r = double.Parse(tbInputRadius.Text.Replace('.', ','));
                Lesszero(circel.r);
                circel.lenght = circel.LenghtC(circel.r);
                circel.area = circel.AreaC(circel.r);
                Circels.Add(circel);
                updateCircelList();
                tbInputRadius.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введённый значения не соответствую требованиям!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                tbInputRadius.Clear();
            }
            catch (InvalidRadius)
            {
                MessageBox.Show("Радиус должен быть больше нуля!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                tbInputRadius.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Обратитесь к разработчику: " + ex.Message,
                    "Неизвестная ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbInputRadius.Clear();
            }

        }

        private void tbCheck_Click(object sender, RoutedEventArgs e)
        {
            double x=0, y=0;
            bool f1 = false, f2 = false;
            try
            {
                x = double.Parse(tbCoordX.Text.Replace('.', ','));
                f1 = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Введённый значения не соответствую требованиям!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                tbCoordX.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Обратитесь к разработчику: " + ex.Message,
                    "Неизвестная ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCoordX.Clear();
            }
            try
            {
                y = double.Parse(tbCoordX.Text.Replace('.', ','));
                f2 = true;

            }
            catch (FormatException)
            {
                MessageBox.Show("Введённый значения не соответствую требованиям!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                tbCoordY.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Обратитесь к разработчику: " + ex.Message,
                    "Неизвестная ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCoordY.Clear();
            }
            if (LbCircle.SelectedItem != null && f1 == true && f2 == true)
            {
                Circel circel = LbCircle.SelectedItem as Circel;
                if (circel.Intheround(x, y, circel.r) == true)
                {
                    MessageBox.Show("Точка лежит внутри выбранного круга.");
                    LbCircle.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Точка не лежит внутри выбранного круга.");
                    LbCircle.SelectedItem = null;
                }
            }
            else if (LbCircle.SelectedItem == null)
            {
                MessageBox.Show("Выберите из списка круг который хотите проверить",
                    "Внимание",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
            }
        }
        private void tbProperties_Click(object sender, RoutedEventArgs e)
        {
            if (LbCircle.SelectedItem != null)
            {
                Circel circel = LbCircle.SelectedItem as Circel;
                MessageBox.Show($"Радиус круга: {circel.r:0.000}\nПлощадь круга: {circel.area:0.000}\nДлина окружности: {circel.lenght:0.000}",
                    "Получите и распишитесь",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
                LbCircle.SelectedItem = null;
            }
            else if (LbCircle.SelectedItem == null)
            {
                MessageBox.Show("Выберите из списка круг, свойства которого хотите увидеть.",
                    "Внимание",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
            }

            }

        public class InvalidRadius : Exception { }
        public void Lesszero(double t)
        {
            if (t <= 0)
                throw new InvalidRadius();
        }


    }
}

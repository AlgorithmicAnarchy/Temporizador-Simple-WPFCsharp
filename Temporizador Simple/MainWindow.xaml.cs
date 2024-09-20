using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Temporizador_Simple
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tiempo;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Activar;
        }

        private void Correr()
        {
            try
            {
                if (tiempo == 0)
                {
                    tiempo = int.Parse(tbtiempo.Text);
                    cuentaAtras.Text = tiempo.ToString();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Por favor, ingresa un número válido en el campo de tiempo.", "Error de formato", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void iniciarbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Correr();
                timer.Start();
                iniciarbtn.IsEnabled = false;
                detenerbtn.IsEnabled = true;
                pausarbtn.IsEnabled = true;
                tbtiempo.Visibility = Visibility.Hidden;
                textinformativo.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al iniciar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Activar(object sender, EventArgs e)
        {
            try
            {
                if (tiempo > 0)
                {
                    tiempo--;
                    cuentaAtras.Text = tiempo.ToString();
                }

                if (tiempo <= 0)
                {
                    timer.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en el temporizador: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void detenerbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                timer.Stop();
                tiempo = int.Parse(tbtiempo.Text);
                cuentaAtras.Text = tiempo.ToString();
                iniciarbtn.IsEnabled = true;
                detenerbtn.IsEnabled = true;
                tbtiempo.Visibility = Visibility.Visible;
                textinformativo.Visibility = Visibility.Visible;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Por favor, ingresa un número válido en el campo de tiempo.", "Error de formato", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al detener: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void pausarbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                timer.Stop();
                iniciarbtn.IsEnabled = true;
                detenerbtn.IsEnabled = true;
                pausarbtn.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al pausar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cerrar la ventana: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al mover la ventana: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

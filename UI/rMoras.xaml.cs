using RegistroPrestamoDetalle.BLL;
using RegistroPrestamoDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroPrestamoDetalle.UI
{
    /// <summary>
    /// Interaction logic for rMoras.xaml
    /// </summary>
    public partial class rMoras : Window
    {
        private Moras Mora = new Moras();
        double total;
        public rMoras()
        {
            InitializeComponent();
            this.DataContext = Mora;
        }

        private void BuscarMoraIdButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarBuscar())
            {
                return;
            }

            Moras moras = MorasBLL.Buscar(int.Parse(MoraIdTextBox.Text));
            Mora = moras;
            Refrescar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var detalle = new MorasDetalle(int.Parse(IdTextBox.Text), int.Parse(MoraIdDetalleTextBox.Text),
                int.Parse(PrestamoIdTextBox.Text), double.Parse(ValorTextBox.Text));

            Mora.MorasDetalle.Add(detalle);
            Mora.Total = double.Parse(TotalTextBox.Text);

            Refrescar();
            MoraIdDetalleTextBox.Clear();
            PrestamoIdTextBox.Clear();
            ValorTextBox.Clear();
            IdTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            Mora.MorasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
            RestarValance();
            Refrescar();

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (MorasBLL.Guardar(Mora))
            {
                Limpiar();
                MessageBox.Show("Guardado.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
               
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarBuscar())
            {
                return;
            }

            if (MorasBLL.Eliminar(int.Parse(MoraIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ValorTextBox_TextChanged(object sender, TextChangedEventArgs e)//Esta funcion va haciendo las sumatoria del toatal en tiempo real.
        {
            total = Mora.Total;
            double valor = 0;

            if (!Regex.IsMatch(ValorTextBox.Text, "^[0-9]+$") && !Regex.IsMatch(ValorTextBox.Text, @"^\w+$"))
            {
                if (Regex.IsMatch(ValorTextBox.Text, @"(\d+(\.)?\d*)"))
                {
                    total += double.Parse(ValorTextBox.Text);
                    TotalTextBox.Text = total.ToString();
                }
                else
                {
                    valor = 0;
                    TotalTextBox.Text = valor.ToString();
                }      
            }
            else if(Regex.IsMatch(ValorTextBox.Text, "^[0-9]+$"))
            {
                valor = double.Parse(ValorTextBox.Text);
                total += valor;

                TotalTextBox.Text = total.ToString();   
            }

        }

        public void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = Mora;
        }

        public void Limpiar()
        {
            this.Mora = new Moras();
            this.DataContext = Mora;
        }

        public bool ValidarBuscar()
        {
            if (!Regex.IsMatch(MoraIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo caracteres numericos.", "Caracter invalido.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!MorasBLL.Existe(Mora.MoraId))
            {
                MessageBox.Show("Este registro no existe.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
           

            return true;
        }

        public void RestarValance()//Al remover una mora esta funcion le resta al balance el valor de la mora a remover.
        {
            var row = (MorasDetalle)DetalleDataGrid.SelectedItem;
            Mora.Total = Mora.Total - row.Valor;
        }

        public bool Validar()
        {
            if(IdTextBox.Text.Length == 0 || MoraIdDetalleTextBox.Text.Length == 0 || 
                PrestamoIdTextBox.Text.Length == 0 || ValorTextBox.Text.Length == 0 || MoraIdTextBox.Text.Length == 0)
            {
                MessageBox.Show("No pueden haber campos vacios.", "Campo vacio.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (!Regex.IsMatch(IdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Id.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(MoraIdDetalleTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo MoraId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(PrestamoIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo PrestamoId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(ValorTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Valor.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}

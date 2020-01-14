using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace PruebaBD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IsmaBDEntities contexto;
        CLIENTE c;
        CollectionViewSource vista;

        public MainWindow()
        {
            

            InitializeComponent();

            contexto = new IsmaBDEntities();
            contexto.CLIENTES.Load();
            contexto.PEDIDOS.Load();
            vista = new CollectionViewSource();
            vista.Source = contexto.CLIENTES.Local;
 

            CLIENTE c = new CLIENTE();
            

            #region General

            ClientesListBox.DataContext = contexto.CLIENTES.Local;

            #endregion

            #region Añadir

            c = new CLIENTE();
            DatosStackPanel.DataContext = c;

            #endregion

            #region Eliminar

            EliminarClientesComboBox.DataContext = contexto.CLIENTES.Local;

            #endregion

            #region Modificar

            ClientesComboBox.DataContext = contexto.CLIENTES.Local;

            #endregion

            #region DataGrid

            ClienteDataGrid.DataContext = contexto.CLIENTES.Local;

            #endregion

            #region Filtro

            FiltroDataGrid.DataContext = vista;

            vista.Filter += Vista_Filter;

            #endregion

            

        }

        private void Vista_Filter(object sender, FilterEventArgs e)
        {
            CLIENTE item = (CLIENTE)e.Item;

            if(FiltroTextBox.Text == "")
            {
                e.Accepted = true;
            }
            else
            {
                if (item.nombre.Contains(FiltroTextBox.Text))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }

        private void Button_Click_Añadir(object sender, RoutedEventArgs e)
        {
            contexto.CLIENTES.Add(c);
            contexto.SaveChanges();
            c = new CLIENTE();
            DatosStackPanel.DataContext = c;
        }

        private void Button_Click_Eliminar(object sender, RoutedEventArgs e)
        {
            contexto.CLIENTES.Remove((CLIENTE)EliminarClientesComboBox.SelectedItem);
            contexto.SaveChanges();
        }

        private void Button_Click_Modificar(object sender, RoutedEventArgs e)
        {
            contexto.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vista.View.Refresh();
        }
    }
}

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

        public MainWindow()
        {
            

            InitializeComponent();

            contexto = new IsmaBDEntities();

            contexto.CLIENTES.Load();

            ClientesListBox.DataContext = contexto.CLIENTES.Local;

            ClientesComboBox.DataContext = contexto.CLIENTES.Local;

        }
    }
}

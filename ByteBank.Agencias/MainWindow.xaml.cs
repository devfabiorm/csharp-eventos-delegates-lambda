using ByteBank.Agencias.DAL;
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

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ByteBankEntities _byteBankContext = new ByteBankEntities();
        private readonly AgenciasListBox lstAgencias;
        public MainWindow()
        {
            InitializeComponent();

            lstAgencias = new AgenciasListBox(this);
            AtualizaControles();
        }

        private void AtualizaControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            container.Children.Add(lstAgencias);

            lstAgencias.Items.Clear();

            var agencias = _byteBankContext.Agencias;
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao = MessageBox.Show("Deseja realmente excluir este item?", "Confirmação", MessageBoxButton.YesNo);

            if(confirmacao == MessageBoxResult.Yes)
            {
                //Excluir item
            }
            else
            {
                //Fazer nada
            }
        }
    }
}

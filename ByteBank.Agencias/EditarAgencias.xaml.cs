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
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Lógica interna para EditarAgencias.xaml
    /// </summary>
    public partial class EditarAgencias : Window
    {
        private readonly Agencia _agencia;
        public EditarAgencias(Agencia agencia)
        {
            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            InitializeComponent();
            AtualizarCamposDeTexto();
            AtualizarControles();            
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtDescricao.Text = _agencia.Descricao;
            txtEndereco.Text = _agencia.Endereco;
        }

        private void AtualizarControles()
        {
            //RoutedEventHandler dialogResultTrue = delegate (object o, RoutedEventArgs e)
            //{
            //    DialogResult = true;
            //};

            //RoutedEventHandler dialogResultFalse = delegate (object o, RoutedEventArgs e)
            //{
            //    DialogResult = false;
            //};

            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            var okEventHandler = dialogResultTrue + Fechar; //O compilador transforma esse código no Delegate.Combine
            var cancelarEventHandler = dialogResultFalse + Fechar;
            //var cancelarEventHandler = (RoutedEventHandler)Delegate.Combine((RoutedEventHandler)btnCancelar_Click, (RoutedEventHandler)Fechar);

            //btnOk.Click += new RoutedEventHandler(btnOk_Click);
            //btnCancelar.Click += new RoutedEventHandler(btnCancelar_Click);

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            //btnOk.Click += new RoutedEventHandler(Fechar);
            //btnCancelar.Click += new RoutedEventHandler(Fechar);

            txtNome.Validacao += ValidaCampoNuloVazio;

            txtNumero.Validacao += ValidaCampoNuloVazio;
            txtNumero.Validacao += ValidaSomenteDigito;

            txtTelefone.Validacao += ValidaCampoNuloVazio;
            txtDescricao.Validacao += ValidaCampoNuloVazio;
            txtEndereco.Validacao += ValidaCampoNuloVazio;
        }
        
        private void ValidaSomenteDigito(object sender, ValidacaoEventArgs e)
        {
           var ehValido = e.Texto.All(Char.IsDigit);
            e.EhValido = ehValido;
        }

        private void ValidaCampoNuloVazio(object sender, ValidacaoEventArgs e)
        {
            var ehValido = !string.IsNullOrEmpty(e.Texto.Trim());
            e.EhValido = ehValido;           
        }


        //private void btnOk_Click(object sender, RoutedEventArgs e) =>
        //    DialogResult = true;

        //private void btnCancelar_Click(object sender, RoutedEventArgs e) =>
        //    DialogResult = false;

        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}

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

namespace listagem_alunos
{
    /// <summary>
    /// Lógica interna para EditarEscolaWindow.xaml
    /// </summary>
    public partial class EditarEscolaWindow : Window
    {
        public EditarEscolaWindow()
        {
            InitializeComponent();
        }

        public void botao_salvar(object sender, RoutedEventArgs e) //Como fechar a janela
        {
            DialogResult = true;
        }
    }
}

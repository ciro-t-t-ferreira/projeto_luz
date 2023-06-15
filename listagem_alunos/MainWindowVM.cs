using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace listagem_alunos
{
    
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<Aluno> listaAlunos { get; set;}

        public ICommand comando { get; private set;}

        public MainWindowVM() {

            listaAlunos = new ObservableCollection<Aluno>()
            {
                nome = "fulaninho",
                Idade = "42",
                Serie = "3ª"
                
            };
            //Exemplo:
            //lista = new ObservableCollection<string>();
            //lista.Add("Elemento");
            //nome = "?";
            //comando = new RelayCommand((object _) =>
            //{

                //lista.Add(nome);
                //Notifica("nome");

            //});

        }
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void Notifica(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

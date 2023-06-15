using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listagem_alunos
{
    public class Escola : INotifyPropertyChanged
    {
        private int id;
        private string nome;
        public event PropertyChangedEventHandler PropertyChanged;

        public void AtualizarNome(Escola escola)
        {
            this.Nome = escola.Nome;
            
        }

        public Escola ShallowCopy()
        {
            return (Escola)this.MemberwiseClone();
        }

        public Escola()
        {

        }

        public Escola(int id, string nome) 
        {
            this.id = id;
            this.nome = nome;           
        }

        public string Nome 
        {
            get { return nome; }
            set { nome = value; Notificar(nameof(Nome)); } 
        }

        public int Id
        { 
            get { return id; }
            set { id = value;  }
        }

        private void Notificar(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        }
}

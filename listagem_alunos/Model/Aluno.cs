using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.TeamFoundation.Client.AddDomainDialogDataSource;
using System.Text.RegularExpressions;

namespace listagem_alunos
{
    
    public class Aluno : INotifyPropertyChanged
    {

        private int id;
        private string nome;
        private int idade;
        private string serie;
        private string escola;
                              

        public event PropertyChangedEventHandler PropertyChanged;

        public Aluno ShallowCopy()
        {
            return (Aluno)this.MemberwiseClone();
        }
        public void AtualizarNome(Aluno aluno)
        {
            this.Nome = aluno.Nome;
            Notificar(nameof(this.Nome));
        }

        public void AtualizarIdade(Aluno aluno)
        {
            this.Idade = aluno.Idade;
            Notificar(nameof(this.Idade));
        }

        public void AtualizarSerie(Aluno aluno)
        {
            this.Serie = aluno.Serie;
            Notificar(nameof(this.Serie));
        }

        public Aluno()
        {

        }

        public Aluno(string escola)
        {
            this.escola = escola;
            
        }


        public Aluno(int id, string nome, int idade, string serie, string escola) 
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.serie = serie;
            this.escola = escola;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome 
        {
            get { return nome; } 
            set { nome = value; }  
        }

        public int Idade
        {
            get { return idade; }
            set { idade = value;}
            
        }
               
        public string Serie
        {
            get { return serie; }
            set { serie = value;  }
        }

        public string Escola
        {
            get { return escola; }
            set { escola = value; }
        }

        

        private void Notificar(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

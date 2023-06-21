using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listagem_alunos.Conexao
{

    //OBS: classe criada apenas para realizar os testes

    public class DataBaseManager : IConexaoBD
    {
        private readonly IConexaoBD Database;

        public DataBaseManager(IConexaoBD database)
        {
            Database = database;
        }

        public void AddAlunoDB(Aluno alunocadastro)
        {
            Database.AddAlunoDB(alunocadastro);
        }

        public void AddEscolaDB(Escola escolacadastro)
        {
            Database.AddEscolaDB(escolacadastro);
        }

        public void AtualizaAlunoDB(Aluno alunoselecionado)
        {
            Database.AtualizaAlunoDB(alunoselecionado);
        }

        public void AtualizaEscolaDB(Escola Escolaselecionada)
        {
            Database.AtualizaEscolaDB(Escolaselecionada);
        }

        public void DeletaAlunoDB(Aluno alunoselecionado)
        {
            Database.DeletaAlunoDB(alunoselecionado);
        }

        public void DeletaEscolaDB(Escola Escolaselecionada)
        {
            Database.DeletaEscolaDB(Escolaselecionada);
        }

        public List<Aluno> ReadAluno()
        {
            return Database.ReadAluno();
        }

        public List<Escola> ReadEscola()
        {
            return Database.ReadEscola();
        }
    }
}

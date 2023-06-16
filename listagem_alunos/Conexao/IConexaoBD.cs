using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listagem_alunos
{
    public interface IConexaoBD
    {
        void AddEscolaDB(Escola escolacadastro);
        List<Escola> ReadEscola();
        void AtualizaEscolaDB(Escola Escolaselecionada);
        void DeletaEscolaDB(Escola Escolaselecionada);
        List<Aluno> ReadAluno();
        void AddAlunoDB(Aluno alunocadastro);
        void AtualizaAlunoDB(Aluno alunoselecionado);
        void DeletaAlunoDB(Aluno alunoselecionado);

    }
}

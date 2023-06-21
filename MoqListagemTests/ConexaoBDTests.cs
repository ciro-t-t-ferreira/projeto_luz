using Autofac.Extras.Moq;
using listagem_alunos;
using listagem_alunos.Conexao;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace MoqListagemTests
{
    public class ConexaoBDTests
    {
     
        [Fact]
        public void ReadEscola_test()
        {
            
            using(var mock = AutoMock.GetLoose()) 
            {
                mock.Mock<IConexaoBD>() 
                    .Setup(x => x.ReadEscola())
                    .Returns(AmostraEscolas);

                
                var cls = mock.Create<DataBaseManager>(); //A classe aqui precisa depender da interface, e não implementar ela
                var expected = AmostraEscolas();
                var actual = cls.ReadEscola();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }

        }

        [Fact]
        public void AddEscolaDB_test()
        {

            using (var mock = AutoMock.GetLoose())
            {
                var escola_exemplo = AmostraEscolas()[0];
                mock.Mock<IConexaoBD>()
                    .Setup(x => x.AddEscolaDB(escola_exemplo));
                    
                var cls = mock.Create<DataBaseManager>();
                cls.AddEscolaDB(escola_exemplo);

                mock.Mock<IConexaoBD>()
                    .Verify(x => x.AddEscolaDB(escola_exemplo), Times.Exactly(1));
            }

        }

        [Fact]
        public void ReadAluno_test()
        {

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConexaoBD>()
                    .Setup(x => x.ReadAluno())
                    .Returns(AmostraAlunos);


                var cls = mock.Create<DataBaseManager>(); //A classe aqui precisa depender da interface, e não implementar ela
                var expected = AmostraAlunos();
                var actual = cls.ReadAluno();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }

        }
        [Fact]
        public void AddAlunoDB_test()
        {

            using (var mock = AutoMock.GetLoose())
            {
                var aluno_exemplo = AmostraAlunos()[0];
                mock.Mock<IConexaoBD>()
                    .Setup(x => x.AddAlunoDB(aluno_exemplo));

                var cls = mock.Create<DataBaseManager>();
                cls.AddAlunoDB(aluno_exemplo);

                mock.Mock<IConexaoBD>()
                    .Verify(x => x.AddAlunoDB(aluno_exemplo), Times.Exactly(1));
            }

        }

        private List<Aluno> AmostraAlunos()
        {
            List<Aluno> output = new List<Aluno>()
            {
                new Aluno
                {
                    Id = 1,
                    Nome = "Beatriz Almeida",
                    Idade = 16,
                    Serie = "2 ano",
                    Escola = "Puríssimo"
                },

                new Aluno
                {
                    Id = 2,
                    Nome = "Afonso Machado",
                    Idade = 17,
                    Serie = "3 ano",
                    Escola = "Puríssimo"
                },

                new Aluno
                {
                    Id = 3,
                    Nome = "Roberto Cavalcante",
                    Idade = 12,
                    Serie = "4ª série",
                    Escola = "Objetivo"
                }
            };

            return output;
        }

        private List<Escola> AmostraEscolas()
        {
            List<Escola> output = new List<Escola>()
            {
                new Escola
                {
                    Id = 1,
                    Nome = "Puríssimo"
                },

                new Escola
                {
                    Id = 2,
                    Nome = "Objetivo"
                },
            };
            return output;

        }
    }
}

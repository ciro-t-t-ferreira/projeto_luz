using Autofac.Extras.Moq;
using listagem_alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace MoqListagemTests
{
    public class ConexaoDBTests
    {
        [Fact]

        public void ReadEscola_test()
        {
            
            using(var mock = AutoMock.GetLoose()) 
            {
                mock.Mock<IConexaoBD>() //no exemplo do TC o objeto que entra no x no código dele é uma "instanciação" direta da interface, no meu é um objeto que implementa a interface
                    .Setup(x => x.ReadEscola())
                    .Returns(AmostraEscolas());

                
                var cls = mock.Create<ConexaoBD>();
                var expected = AmostraEscolas();
                var actual = cls.ReadEscola();

                Assert.True(actual != null);
                //Assert.Equal(expected.Count, actual.Count);
            }

        }

        public void AddEscola_test()
        {

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConexaoBD>() //no exemplo do TC o objeto que entra no x no código dele é uma "instanciação" direta da interface, no meu é um objeto que implementa a interface
                    .Setup(x => x.ReadEscola())
                    .Returns(AmostraEscolas());


                var cls = mock.Create<ConexaoBD>();
                var expected = AmostraEscolas();
                var actual = cls.ReadEscola();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }

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

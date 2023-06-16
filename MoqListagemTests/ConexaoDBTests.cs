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

        public void test()
        {
            
            using(var mock = AutoMock.GetLoose()) //Argumento tem que ser do tipo IDiposable
            {
                mock.Mock<ConexaoBD>() //o que eu coloco no argumento do <>? Só aceita interfaace? 
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

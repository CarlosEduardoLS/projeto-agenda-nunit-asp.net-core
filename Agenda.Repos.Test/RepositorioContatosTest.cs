using Agenda.DAL;
using Moq;
using NUnit.Framework;

namespace Agenda.Repos.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;

        [SetUp]
        public void SetUp() 
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void Test() {}

        [TearDown]
        public void TearDown() 
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}

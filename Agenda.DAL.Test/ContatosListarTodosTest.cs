using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace Agenda.DAL.Test
{
    public class ContatosListarTodosTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            Contato contato1 = _fixture.Create<Contato>();
            Contato contato2 = _fixture.Create<Contato>();

            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);

            var lstResultado = _contatos.ObterTodos();
            var contatoResultado = lstResultado.Where(o => o.Id == contato1.Id).FirstOrDefault();

            Assert.IsTrue(lstResultado.Count() >= 2);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}

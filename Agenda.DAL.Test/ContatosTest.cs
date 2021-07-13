using NUnit.Framework;
using System;
using Agenda.Domain;
using System.Linq;
using AutoFixture;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
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
        public void AdicionarContatoTest()
        {
            Contato contato = _fixture.Create<Contato>();
            _contatos.Adicionar(contato);
            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            Contato contato = _fixture.Create<Contato>();
            Contato contatoResultado;

            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]

        //public void ObterTodosOsContatosTest()
        //{
        //    Contato contato1 = _fixture.Create<Contato>();
        //    Contato contato2 = _fixture.Create<Contato>();

        //    _contatos.Adicionar(contato1);
        //    _contatos.Adicionar(contato2);

        //    var lstResultado = _contatos.ObterTodos();
        //    var contatoResultado = lstResultado.Where(o => o.Id == contato1.Id).FirstOrDefault();

        //    Assert.AreEqual(2, lstResultado.Count());
        //    Assert.AreEqual(contato1.Id, contatoResultado.Id);
        //    Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        //}

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}

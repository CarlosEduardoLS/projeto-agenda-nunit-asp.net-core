using Agenda.DAL;

namespace Agenda.Repos
{
    public class RepositorioContatos
    {
        private readonly IContatos contatos;
        private readonly ITelefones _telefones;

        public RepositorioContatos(IContatos contatos, ITelefones telefones)
        {
            this.contatos = contatos;
            _telefones = telefones;
        }
    }
}

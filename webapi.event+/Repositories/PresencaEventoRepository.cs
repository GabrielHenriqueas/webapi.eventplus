using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext ctx;

        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }

        //==================================================================

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento presencaBuscada = ctx.PresencaEvento.FirstOrDefault(x => x.IdPresencaEvento == id)!;

            if (presencaBuscada != null)
            {
                presencaBuscada.Situacao = presencaEvento.Situacao;
                presencaBuscada.Usuario = presencaEvento.Usuario;
                presencaBuscada.Evento = presencaEvento.Evento;

                ctx.PresencaEvento.Update(presencaBuscada!);

                ctx.SaveChanges();
            }
        }

        //==================================================================

        public PresencaEvento BuscarPorId(Guid id)
        {
            List<PresencaEvento> presencas = ctx.PresencaEvento.ToList();

            PresencaEvento presenca = presencas.FirstOrDefault(x => x.IdPresencaEvento == id)!;

            return presenca;
        }

        //==================================================================

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            try
            {
                ctx.PresencaEvento.Add(presencaEvento);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //==================================================================

        public void Deletar(Guid id)
        {
            PresencaEvento presencaEvento = ctx.PresencaEvento.FirstOrDefault(x => x.IdPresencaEvento == id)!;

            ctx.PresencaEvento.Remove(presencaEvento);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<PresencaEvento> Listar()
        {
            List<PresencaEvento> presencas = ctx.PresencaEvento.ToList();

            return presencas;
        }
    }
}

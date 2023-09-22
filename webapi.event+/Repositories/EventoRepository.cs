using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext ctx;

        public EventoRepository()
        {
            ctx = new EventContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = ctx.Evento.FirstOrDefault(x => x.IdEvento == id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.TipoEvento = evento.TipoEvento;
                eventoBuscado.Instituicao = evento.Instituicao;                
            }

            ctx.Evento.Update(eventoBuscado!);

            ctx.SaveChanges();
        }

        //==================================================================

        public Evento BuscarPorId(Guid id)
        {
            List<Evento> eventos = ctx.Evento.ToList();

            Evento evento = eventos.FirstOrDefault(x => x.IdEvento == id)!;

            return evento;
        }

        //==================================================================

        public void Cadastrar(Evento evento)
        {
            try
            {
                ctx.Evento.Add(evento);

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
            Evento evento = ctx.Evento.FirstOrDefault(x => x.IdEvento == id)!;

            ctx.Evento.Remove(evento);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Evento> Listar()
        {
            List<Evento> eventos = ctx.Evento.ToList();

            return eventos;
        }
    }
}

using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext ctx;

        public ComentarioEventoRepository()
        {
            ctx = new EventContext();
        }

        //==================================================================

        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
        {
            ComentarioEvento comentarioBuscado = ctx.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id)!;

            if (comentarioBuscado != null)
            {
                comentarioBuscado.Descricao = comentarioBuscado.Descricao;
            }

            ctx.ComentarioEvento.Update(comentarioBuscado!);

            ctx.SaveChanges();
        }

        //==================================================================

        public ComentarioEvento BuscarPorId(Guid id)
        {
            List<ComentarioEvento> comentarioEventos = ctx.ComentarioEvento.ToList();

            ComentarioEvento comentarioEvento = comentarioEventos.FirstOrDefault(x => x.IdComentarioEvento == id)!;

            return comentarioEvento;
        }

        //==================================================================

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                ctx.ComentarioEvento.Add(comentarioEvento);

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
            ComentarioEvento comentarioEvento = ctx.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id)!;

            ctx.ComentarioEvento.Remove(comentarioEvento);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<ComentarioEvento> Listar()
        {
            List<ComentarioEvento> comentarioEventos = ctx.ComentarioEvento.ToList();

            return comentarioEventos;
        }
    }
}

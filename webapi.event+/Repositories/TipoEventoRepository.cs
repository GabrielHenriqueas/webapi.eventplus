using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext ctx;

        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }

        //==================================================================

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoBuscado = ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoEvento.Titulo;
            }

            ctx.TipoEvento.Update(tipoBuscado!);

            ctx.SaveChanges();

        }

        //==================================================================

        public TipoEvento BuscarPorId(Guid id)
        {
            TipoEvento tipoEvento = ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

            return tipoEvento!;
        }

        //==================================================================

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoEvento);

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
            try
            {
                TipoEvento tipoEvento = ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

                ctx.TipoEvento.Remove(tipoEvento!);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //==================================================================

        public List<TipoEvento> Listar()
        {
            List<TipoEvento> tipoEvento = ctx.TipoEvento.ToList();

            return tipoEvento;
        }            
    }
}

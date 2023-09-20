using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        //private readonly EventContext ctx;

        //public TipoEventoRepository()
        //{
        //    ctx = new EventContext();
        //}

        //public void Atualizar(Guid id, TipoEvento tipoEvento)
        //{

        //}

        //public TipoEvento BuscarPorId(Guid id)
        //{
        //    TipoEvento tipoEvento = ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

        //    return tipoEvento!;
        //}

        //public void Cadastrar(TipoEvento tipoEvento)
        //{
        //    try
        //    {
        //        ctx.TipoEvento.Add(tipoEvento);

        //        ctx.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public void Deletar(Guid id)
        //{
        //    try
        //    {
        //        TipoEvento tipoEvento = ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id!);

        //        ctx.TipoEvento.Remove(tipoEvento!);

        //        ctx.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public List<TipoEvento> Listar();
        //{
        //    try
        //    {
        //        //TipoEvento tipoEvento = ctx.TipoEvento.ToList();

        //        //return tipoEvento;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            throw new NotImplementedException();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TipoEvento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext ctx;

        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                instituicaoBuscada.CNPJ = instituicao.CNPJ;
                instituicaoBuscada.Endereco = instituicao.Endereco;
            }

            ctx.Instituicao.Update(instituicaoBuscada!);

            ctx.SaveChanges();
        }

        //==================================================================

        public Instituicao BuscarPorId(Guid id)
        {
            List<Instituicao> instituicaos = ctx.Instituicao.ToList();

            Instituicao instituicao = instituicaos.FirstOrDefault(x => x.IdInstituicao == id)!;

            return instituicao;
        }

        //==================================================================

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                ctx.Instituicao.Add(instituicao);

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
            Instituicao instituicao = ctx.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;

            ctx.Instituicao.Remove(instituicao);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Instituicao> Listar()
        {
            List<Instituicao> instituicaos = ctx.Instituicao.ToList();

            return instituicaos;
        }
    }
}

using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void Cadastrar(PresencaEvento presencaEvento);

        void Deletar(Guid id);

        List<PresencaEvento> Listar();

        PresencaEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, PresencaEvento presencaEvento);
    }
}

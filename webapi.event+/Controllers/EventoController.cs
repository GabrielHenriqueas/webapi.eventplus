using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IEventoRepository _eventoRepository { get; set; }


        /// <summary>
        /// Instância do objeto _tipoUsuarioRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        //================================================================================================

        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return Ok(evento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Evento> ListarEventos = _eventoRepository.Listar();

                return Ok(ListarEventos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================
        /// <summary>
        /// Atualizar Tipo de Usuário existente passando o seu id
        /// </summary>
        /// <param name="id">Id do Objeto a ser atualizado</param>
        /// <param name="evento">Objeto Tipo de Usuário com as novas informações</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);

                return Ok(evento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================
        /// <summary>
        /// Deletar o Objeto pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}

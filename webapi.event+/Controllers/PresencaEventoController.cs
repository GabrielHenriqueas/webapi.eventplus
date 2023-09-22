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
    public class PresencaEventoController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IPresencaEventoRepository _presencaEventoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _presencaEventoRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        //================================================================================================

        [HttpPost]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(presencaEvento);

                return StatusCode(201);
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
                List<PresencaEvento> ListaPresencaEvento = _presencaEventoRepository.Listar();

                return StatusCode(200, ListaPresencaEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================

        [HttpPut]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Atualizar(id, presencaEvento);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaEventoRepository.Deletar(id);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que é um controlador de API é JSON
    /// </summary>
    [Produces("application/json")]


    public class TipoEventoController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _filmeRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        //================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de cadastrar Tipo de Evento
        /// </summary>
        /// <param name="tipoEvento">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================
        /// <summary>
        /// Endpoint que acessa o método de listar os Tipos de Evento
        /// </summary>
        /// <returns>Lista de TipoEvento e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma Lista para receber Tipos de Usuário
                List<TipoEvento> ListarTipoEvento = _tipoEventoRepository.Listar();

                //retorna o status code 200 ok e a lista de jogos no formato JSON
                return StatusCode(200, ListarTipoEvento);

                //Retorna apenas Lista de Tipos de Evento
                //return Ok(ListarTipoEvento);
            }
            catch (Exception e)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(e.Message);
            }
        }

        //================================================================================================
        /// <summary>
        /// Atualizar Tipo de Usuário existente passando o seu id
        /// </summary>
        /// <param name="id">Id do Objeto a ser atualizado</param>
        /// <param name="tipoEvento">Objeto Tipo de Usuário com as novas informações</param>
        /// <returns>Status Code</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(e.Message);
            }
        }

    }
}

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


    public class ComentarioEventoController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IComentarioEventoRepository _comentarioEventoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _comentarioEventoRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        //================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de cadastrar Comentário Evento
        /// </summary>
        /// <param name="comentarioEvento">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentarioEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de listar os Comentários do Evento
        /// </summary>
        /// <returns>Lista de ComentarioEvento e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma Lista para receber Tipos de Usuário
                List<ComentarioEvento> ListarComentario = _comentarioEventoRepository.Listar();

                //retorna o status code 200 ok e a lista de TipoUsuario no formato JSON
                return StatusCode(200, ListarComentario);

                //Retorna apenas Lista de Tipos de Usuário
                //return Ok(ListarTipoUsuario);
            }
            catch (Exception e)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(e.Message);
            }
        }

        //================================================================================================

        /// <summary>
        /// Atualizar Comentário do Evento existente passando o seu id
        /// </summary>
        /// <param name="id">Id do Objeto a ser atualizado</param>
        /// <param name="comentarioEvento">Objeto Tipo de Usuário com as novas informações</param>
        /// <returns>Status Code</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Atualizar(id, comentarioEvento);

                return StatusCode(200);
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
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);

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

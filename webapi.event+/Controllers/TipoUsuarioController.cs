using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


    public class TipoUsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instância do objeto _tipoUsuarioRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        //================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de cadastrar Tipo de Usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de listar os Tipos de Usuário
        /// </summary>
        /// <returns>Lista de TipoUsuario e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma Lista para receber Tipos de Usuário
                List<TipoUsuario> ListarTipoUsuario = _tipoUsuarioRepository.Listar();

                //retorna o status code 200 ok e a lista de TipoUsuario no formato JSON
                return StatusCode(200, ListarTipoUsuario);

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
        /// Atualizar Tipo de Usuário existente passando o seu id
        /// </summary>
        /// <param name="id">Id do Objeto a ser atualizado</param>
        /// <param name="tipoUsuario">Objeto Tipo de Usuário com as novas informações</param>
        /// <returns>Status Code</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);

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
                _tipoUsuarioRepository.Deletar(id);

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

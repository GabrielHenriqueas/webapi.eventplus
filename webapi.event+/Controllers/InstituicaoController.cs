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


    public class InstituicaoController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _instituicaoRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        //================================================================================================
        /// <summary>
        /// Endpoint que acessa o método de cadastrar Instituição
        /// </summary>
        /// <param name="instituicao">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================
    }
}

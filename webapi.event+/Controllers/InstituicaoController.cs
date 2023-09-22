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
        /// <summary>
        /// Endpoint que acessa o método de listar as Instituições
        /// </summary>
        /// <returns>Lista de Instituicao e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma Lista para receber Instituições
                List<Instituicao> ListarInstituicao = _instituicaoRepository.Listar();
                //retorna o status code 200 ok e a lista de instituicao no formato JSON
                return Ok(ListarInstituicao);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //================================================================================================
        /// <summary>
        /// Atualizar Instituição existente passando o seu id
        /// </summary>
        /// <param name="id">Id do Objeto a ser atualizado</param>
        /// <param name="instituicao">Objeto Tipo de Usuário com as novas informações</param>
        /// <returns>Status Code</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);

                return StatusCode(204);
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
                _instituicaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

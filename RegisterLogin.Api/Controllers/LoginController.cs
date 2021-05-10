using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterLogin.Api.Busines;
using RegisterLogin.Api.Domain.Models.Request;
using RegisterLogin.Api.Domain.Models.Response;
using Signa.Library.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Response = RegisterLogin.Api.Domain.Models.Response.Response;

namespace RegisterLogin.Api.Controllers
{
    [ApiController]
    [Route("api/login")]

    public class LoginController : ControllerBase
    {
        private readonly LoginBL _loginBL;
        public LoginController(LoginBL loginBL)
        {
            _loginBL = loginBL;
        }

        /// <summary>
        /// Cadastrar usuário
        /// </summary>
        /// <param name="loginReq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] LoginRequest loginReq)
        {
            var idUser = _loginBL.Insert(loginReq);

            return CreatedAtAction(nameof(GetById), new { id = idUser }, loginReq);
        }
                        
        /// <summary>
        /// Atualizar Login
        /// </summary>
        /// <param name="loginUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] LoginUpdateRequest loginUpdateRequest)
        {
            //if (loginUpdateRequest.IdLogin == 0 || loginUpdateRequest.IdLogin == null || loginUpdateRequest.IdLogin <= -0)//verifica se o usuário digitou o Login
            //{
            //    return BadRequest(new { message = "Informe um Login" });
            //}
            var linhasAfetadas = _loginBL.Update(loginUpdateRequest);

            if (loginUpdateRequest.IdLogin == 1)
            {
                return Ok(new Response { Message = "Usuário atualizado com sucesso." }); //Message retorna da classe response
            }

            else
            {
                return BadRequest(new { message = "Erro ao atualizar o cadastro de aluno, contate o administrador." });//message retorna direto do sistema
            }
        }

        /// <summary>
        /// Buscar por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var loginResponse = _loginBL.GetLoginById(id);

            if (loginResponse != null)
            {
                return Ok(loginResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum Registro foi encontrado." });
            }
        }

        /// <summary>
        /// Busca todos os Cadastros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(IEnumerable<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var loginResponse = _loginBL.GetAllLogin();

            if (loginResponse.Any())
            {
                return Ok(loginResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Erro, contate o administrador" });//pode fazer retorno pela response ou retorno pelo sistema sem colocar o Response
            }
        }

        /// <summary>
        /// Apagar Login
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var linhasAfetadas = _loginBL.Delete(id);

            if (linhasAfetadas == 1) //ou if(login response !=0)
            {
                return Ok(new Response { Message = "Aluno excluido com sucesso" });
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum aluno foi encontrado." }); // ou return BadRequest(new Response{ Message = "Nenhum aluno foi encontrado." });
            }
        }

    }
}

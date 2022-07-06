using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AR.Data.Interfaces;
using System.Threading.Tasks;
using System;
using AR.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace AR.Apresentacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obter todos os clientes.
        /// </summary>
        /// <response code="200">A lista de clientes foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de clientes.</response>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        /// <summary>
        /// Obter um cliente específico por ID.
        /// </summary>
        /// <param name="Id">ID do cliente.</param>
        /// <response code="200">O cliente foi obtido com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter o cliente.</response>
        [HttpGet("{Id}")]
        public IActionResult BuscaId([FromRoute] int Id)
        {
            return Ok(_repository.BuscaId(Id));
        }

        /// <summary>
        /// Deletar cliente.
        /// </summary>
        /// <param name="Id">ID do cliente.</param>
        /// <response code="200">O cliente foi deletado com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao deletar o cliente.</response>
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            if (_repository.Delete(Id)) return StatusCode(200, "O cliente foi deletado com sucesso");

            return StatusCode(500, "Ocorreu algum erro ao deletar o cliente");
        }

        ///<summary>
        /// Adicionar um Cliente
        /// </summary>
        /// <param name="matheus">Cliente a ser salvo no banco de dados</param>
        /// <remarks>
        /// Exemplo de requisição
        /// POST /Cliente
        /// {
        ///     "nome": "Exemplo",
        ///     "cpf": "00000000000",
        ///     "data_nascimento": "2022-07-06",
        ///     "email": "string",
        ///     "sexo": "m",
        ///     "ativo": "s"
        /// }
        /// </remarks>
        /// <returns>Mensagem de confirmação que o cliente foi salvo</returns>
        /// <response code="201">O cliente foi salvo corretamente</response>
        /// <response code="500">Dados inválidos</response>
        [HttpPost]
        public async Task<IActionResult> Add(Cliente cliente)
        {
            try
            {
                await _repository.Add(cliente);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Dados inválidos");
            }
        }

        /// <summary>
        /// Alterar cliente.
        /// </summary> 
        /// <param name="Id">ID do cliente.</param>
        /// <param name="Cliente">Modelo do cliente.</param>
        /// <response code="200">O cliente foi alterado com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao alterar o cliente.</response>
        [HttpPut("editar/")]
        public IActionResult Put(Cliente cliente)
        {
            if (_repository.Update(cliente))
                return Ok();

            return StatusCode(500, "Ocorreu algum erro ao alterar o cliente"); 
        }


    }
}


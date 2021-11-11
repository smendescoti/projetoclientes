using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClientes.Application.Interfaces;
using ProjetoClientes.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClientes.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //atributo
        private readonly IClienteApplicationService _clienteapplicationservice;

        //construtor para inicializar o atributo (injeção de dependência)
        public ClientesController(IClienteApplicationService clienteapplicationservice)
        {
            _clienteapplicationservice = clienteapplicationservice;
        }

        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model)
        {
            try
            {
                _clienteapplicationservice.Create(model);
                return Ok(new { Mensagem = "Cliente cadastrado com sucesso." });
            }
            catch(ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model)
        {
            try
            {
                _clienteapplicationservice.Update(model);
                return Ok(new { Mensagem = "Cliente atualizado com sucesso." });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clienteapplicationservice.Delete(id);
                return Ok(new { Mensagem = "Cliente excluído com sucesso." });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_clienteapplicationservice.GetAll());
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpGet("{dataMin}/{dataMax}")]
        public IActionResult GetByDataCadastro(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                return Ok(_clienteapplicationservice.GetByDataCadastro(dataMin, dataMax));
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_clienteapplicationservice.GetById(id));
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }
    }
}

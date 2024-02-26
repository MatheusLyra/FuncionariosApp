using AutoMapper;
using FuncionariosApp.Domain.Entities;
using FuncionariosApp.Domain.Interfaces.Services;
using FuncionariosApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncionariosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioDomainService? _funcionarioDomainService;
        private readonly IMapper? _mapper;

        public FuncionariosController(IFuncionarioDomainService? funcionarioDomainService, IMapper? mapper)
        {
            _funcionarioDomainService = funcionarioDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] FuncionariosPostModel model)
        {
            /*  var funcionario = new Funcionario
              {
                  Id = Guid.NewGuid(),
                  Nome = model.Nome,
                  Matricula = model.Matricula,
                  Cpf = model.Cpf,
                  DataAdmissao = model.DataAdmissao,
                  DataHoraCadastro = DateTime.Now,
                  EmpresaId = model.EmpresaId
              };
              _funcionarioDomainService?.Cadastrar(funcionario);
              return Ok("Cadastro do funcionário realizado com sucesso");
            */
            try
            {
                var funcionario = _mapper?.Map<Funcionario>(model);
                funcionario.DataHoraCadastro = DateTime.Now;
                _funcionarioDomainService?.Cadastrar(funcionario);

                return StatusCode(201, new 
                {
                    mensagem = "Funcionário cadastrado com sucesso.",
                    Id = funcionario.Id
                });
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    mensagem = e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
           
        }

        [HttpPut]
        public IActionResult Put([FromBody] FuncionariosPutModel model)
        {
            try
            {
                var funcionario = _mapper?.Map<Funcionario>(model);
                _funcionarioDomainService?.Atualizar(funcionario);

                return StatusCode(200, new
                {
                    mensagem = "Funcionário atualizado com sucesso.",
                    Id = funcionario.Id
                });
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    mensagem = e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _funcionarioDomainService?.Excluir(id);

                return StatusCode(200, new
                {
                    mensagem = "Funcionário excluído com sucesso.",
                });
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    mensagem = e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }

        [HttpGet]   
        public IActionResult Get()
        {
            try
            {
                var funcionarios = _mapper?.Map<List<FuncionariosGetModel>>(_funcionarioDomainService?.Consultar());
                return StatusCode(200, funcionarios);   
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var funcionario = _mapper?.Map<FuncionariosGetModel>(_funcionarioDomainService?.ConsultarPorId(id));
                return StatusCode(200, funcionario);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }


    }
}

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
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaDomainService _empresaDomainService;
        private readonly IMapper _mapper;

        public EmpresasController(IEmpresaDomainService empresaDomainService, IMapper mapper)
        {
            _empresaDomainService = empresaDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmpresasPostModel model)
        {
            try
            {
                var empresa = _mapper.Map<Empresa>(model);
                empresa.DataHoraCadastro = DateTime.Now;
                _empresaDomainService?.Cadastrar(empresa);

                return StatusCode(201, new
                {
                    mensagem = "Empresa cadastrada com sucesso",
                    Id = empresa.Id
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
        public IActionResult Put([FromBody] EmpresasPutModel model)
        {
            try
            {
                var empresa = _mapper.Map<Empresa>(model);
                _empresaDomainService?.Atualizar(empresa);

                return StatusCode(200, new
                {
                    mensagem = "Dados atualizados com sucesso",
                    Id = empresa.Id
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
                _empresaDomainService.Excluir(id);

                return StatusCode(200, new
                {
                    mensagem = "Empresa excluída com sucesso." 
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
                var empresas = _mapper.Map<List<EmpresasGetModel>>(_empresaDomainService.Consultar());
                return StatusCode(200, empresas);
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
                var empresa = _mapper.Map<EmpresasGetModel>(_empresaDomainService.ConsultarPorId(id));
                return StatusCode(200, empresa);    
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

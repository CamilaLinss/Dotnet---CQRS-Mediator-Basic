using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        //IMediator será a classe mediadora que através do método Send chama os command handlers 
        //que definimos, com base no objeto passado.

        //Perceba que n instancio e nem injeto a dependencia dos objetos para poder fazer os Commands
        //Assim estou utilizando uma classe mediadora para isso


        private readonly IRepository<Pessoa> _repo;
        private readonly IMediator _mediat;


        public PessoaController(IRepository<Pessoa> repo, IMediator mediat)
        {
            _repo = repo;
            _mediat = mediat;
           
        }



        [HttpPost]
        public async Task<IActionResult> Post(CadastraPessoaCommand command)
        {
            //Baseado no tipo do objeto command, o metodo send vai escolher o command que atende e
            //o command invoca o command handler que atende o mesmo

            var response = await _mediat.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraPessoaCommand command)
        {
            var response = await _mediat.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ExcluiPessoaCommand { Id = id };
            var result = await _mediat.Send(obj);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repo.Get(id));
        }

    }
}

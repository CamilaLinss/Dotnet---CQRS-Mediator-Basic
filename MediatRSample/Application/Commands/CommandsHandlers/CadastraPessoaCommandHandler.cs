using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notifications;
using MediatRSample.Repositorios;

namespace MediatRSample.Application.Commands.CommandsHandlers
{

    //Já os objetos Command Handler serão responsáveis por executar as ações definidas pelos 
    //objetos Command. É aqui que ficará centralizado grande parte da lógica da aplicação.

    //As boas práticas recomendam que para cada objeto Command haja um objeto Command Handler, 
    //entretanto seria possível implementar um objeto Command Handler para lidar com todos os 
    //commands definidos na aplicação.


    //IREQUESTHANDLER: nesta interface é especificado uma classe command e o tipo de retorno. 
    //Quando esta classe command gerar uma solicitação, o MediatR irá invocar o command handler, 
    //chamando o método Handler.

    // *Aqui indico que esse commandHandler vai atender a esse command declarado (CadastraPessoaCommand no caso)


    public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, string>
    {

        private readonly IMediator mediator;
        private readonly IRepository<Pessoa> repository;
        

        public CadastraPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }


        public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
        {
            
        var pessoa = new Pessoa { Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo };

        try {
            
            await repository.Add(pessoa);

            //Após a solicitação ser atendida, é possível utilizar o método Publish() para emitir 
            //uma notificação para todo sistema. Onde o MediatR irá procurar por uma a classe que 
            //tenha implementado a interface INotificationHandler<tipo da notificacao> e invocar o 
            //método Handler()

            //Criando a instancia da notificação e preenchendo seus campos
            await mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo});

            return await Task.FromResult("Pessoa criada com sucesso");

        } catch(Exception ex) {

            await mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });
            
            //publica notificação de erro, ou seja quando o erro ocorrer ele pode executar outro metodo
            await mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });

            return await Task.FromResult("Ocorreu um erro no momento da criação");
        }

        }












        
    }
}
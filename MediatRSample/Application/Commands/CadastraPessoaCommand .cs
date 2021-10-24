using MediatR;

namespace MediatRSample.Application.Commands
{

    //COMMANDS: Onde serão definidos os objetos DTOs que representam uma ação a ser executada

    //A parte dos commands é uma aplicação do padrão Command, que na implementação do MediatR é 
    //composta de dois objetos: Command e Command Handler.

    //Os objetos Command definem solicitações que irão alterar o estado dos dados e que o sistema 
    //precisa realizar. Por ser imperativo e se tratar de uma ação que será executada apenas uma 
    //vez (por solicitação)

    //Já os objetos Command Handler serão responsáveis por executar as ações definidas pelos objetos 
    //Command. É aqui que ficará centralizado grande parte da lógica da aplicação.



    //IREQUEST: Nesta interface genérica se especifica o tipo de dado que será retornado quando o 
    //command for processado. Também é atráves do uso desta interface que será possível vincular os 
    //commands com as classes Command Handlers. É desta forma que a biblioteca saberá qual objeto 
    //deve ser invocado quando uma solicitação for gerada.


    public class CadastraPessoaCommand : IRequest<string>   //IRequest é uma interface do MediatR.
                                                            //Quando for cadastrado, quero 
                                                            //retornar uma mensagem de sucesso(string). 
                                                            //Poderia ser um UsuarioResponse DTO.
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        
    }
}
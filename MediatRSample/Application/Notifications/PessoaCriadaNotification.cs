using MediatR;

namespace MediatRSample.Application.Notifications
{

    //Onde serão definidos os objetos DTOs que representam notificações

    //Notificações representam a notificação de que um evento especifico aconteceu

    //Quando um Publish() chama uma notificação, a mesma é acionada e engatilha um EventHandlers,
    //que traz o metodo que executa a ação correspondente esperada para aquele evento

    //Como vimos no tópico anterior, no método Handler de uma classe Command Handler, pode ser 
    //invocado o método Publish(), passando por parâmetro um objeto notificação. Todos os Event 
    //Handlers que estiverem “ouvindo” notificações do tipo do objeto “publicado” serão notificados 
    //e poderão processá-lo.


    public class PessoaCriadaNotification : INotification
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public bool IsEfetivado { get; set; }

    }
}
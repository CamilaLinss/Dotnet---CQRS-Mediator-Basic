using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Notifications;

namespace MediatRSample.Application.EventHandlers
{

    //Os Events Handlers tem os metodos que escutam as notificações e são engatilhados por elas
    //Metodos que implementam e atendem as notificações
    //Aqui tenho mais de uma notificação que pode ser atendida em um mesmo handlers, pois todas
    //tem o objetivo de de retornar/logar uma mensagem de resultado da operação

    // Um EventHandler pode ter mais de uma notification como uma notification pode ter varios 
    //EventHandlers ouvindo e atendendo uma mesma notification. Nesse ultimo caso, a notificação
    //invocaria todos os eventhandlers associados!!


                                    //Aqui colocamos todas as notificações que esse Event vai atender
                                    //Por tanto sempre que tiver essas notificações, essa classe vai
                                    //iniciar o respectivo metodo, utilizando a logica de sobrecarga
    public class LogEventHandler :  INotificationHandler<PessoaCriadaNotification>,
                                    INotificationHandler<PessoaAlteradaNotification>,
                                    INotificationHandler<PessoaExcluidaNotification>,
                                    INotificationHandler<ErroNotification>
    {

        public Task Handle(PessoaCriadaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.Idade} - {notification.Sexo}'");
            });

        }

        public Task Handle(PessoaAlteradaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} - {notification.Idade} - {notification.Sexo} - {notification.IsEfetivado}'");
            });

        }

        public Task Handle(PessoaExcluidaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
            });
        }



    }
}
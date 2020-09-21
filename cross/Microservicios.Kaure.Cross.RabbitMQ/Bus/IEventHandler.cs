using System.Threading.Tasks;
using Microservicios.Kaure.Cross.RabbitMQ.Events;

namespace Microservicios.Kaure.Cross.RabbitMQ.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
         where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}

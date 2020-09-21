using System.Threading.Tasks;
using Microservicios.Kaure.Cross.RabbitMQ.Commands;
using Microservicios.Kaure.Cross.RabbitMQ.Events;

namespace Microservicios.Kaure.Cross.RabbitMQ.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}

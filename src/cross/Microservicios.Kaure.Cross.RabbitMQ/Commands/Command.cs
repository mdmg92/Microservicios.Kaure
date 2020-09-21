using System;
using Microservicios.Kaure.Cross.RabbitMQ.Events;

namespace Microservicios.Kaure.Cross.RabbitMQ.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}

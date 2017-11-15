using System.Threading.Tasks;
using Store.Domain.Commands;
using Store.Domain.Events;

namespace Store.Domain.Bus
{
    public interface IBus
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
namespace Xendor.MessageBroker
{
    public interface IMessageFilter<out TOut>
    {
        Binding Binding { get; }
        TOut Mapper(IEnvelope data);
    }
}
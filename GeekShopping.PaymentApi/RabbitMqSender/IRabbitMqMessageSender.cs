using GeekShopping.MessageBus;

namespace GeekShopping.PaymentApi.RabbitMqSender
{
    public interface IRabbitMqMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}

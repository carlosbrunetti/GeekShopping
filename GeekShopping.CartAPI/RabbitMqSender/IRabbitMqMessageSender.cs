using GeekShopping.MessageBus;

namespace GeekShopping.CartApi.RabbitMqSender
{
    public interface IRabbitMqMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}

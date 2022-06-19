using GeekShopping.MessageBus;

namespace GeekShopping.OrderApi.RabbitMqSender
{
    public interface IRabbitMqMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}

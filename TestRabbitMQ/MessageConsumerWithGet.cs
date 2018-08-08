using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestRabbitMQ
{
    public class DeliverEventArgs : EventArgs
    {
        public DeliverEventArgs(string message)
        {
            this.message = message;
        }
        public string message;
    }

    public delegate void DeliverEventHandler(object consumer, DeliverEventArgs e);

    class MessageConsumerWithGet
    {
        string exChange = RabbitMQConfig.exchange;
        string type = RabbitMQConfig.type;
        string queue = RabbitMQConfig.queue;
        string routingKey = RabbitMQConfig.queue;
        IModel channel;
        public event DeliverEventHandler deliverCallback;
        BasicGetResult msgResponse;

        public MessageConsumerWithGet()//New 构造函数
        {

        }

        public MessageConsumerWithGet(string exChange, string type, string queue, string routingKey)//New 构造函数
        {
            this.exChange = exChange;
            this.type = type;
            this.queue = queue;
            this.routingKey = routingKey;
        }


        public void GetMessage(bool noAck = false)
        {
            IConnection conn = MessageFactory.Instance.Factory.CreateConnection();
            channel = conn.CreateModel();
            channel.ExchangeDeclare(exChange, type);//声明转发器(交换器,类型)
            channel.QueueDeclare(queue, RabbitMQConfig.IsDurable, false, false, null);
            channel.QueueBind(queue, exChange, routingKey);//为转发器指定队列，设置bindings
            msgResponse = channel.BasicGet(queue, noAck);
            if (msgResponse != null)
            {
                var msgBody = Encoding.UTF8.GetString(msgResponse.Body);
                deliverCallback(this, new DeliverEventArgs(msgBody));
                Console.WriteLine(string.Format("***接收时间:{0}，消息内容：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msgBody));
            }
        }

        public void BasicAck()
        {
            channel.BasicAck(msgResponse.DeliveryTag, false);
            channel.Close();
            channel = null;
            msgResponse = null;
        }

        public void Destroy()
        {
            if (channel != null ) channel.Close();
            msgResponse = null;
        }
    }
}

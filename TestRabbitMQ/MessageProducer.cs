using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestRabbitMQ
{
    class MessageProducer
    {

        string exChange = RabbitMQConfig.exchange;
        string type = RabbitMQConfig.type;
        string queue = RabbitMQConfig.queue;
        string routingKey = RabbitMQConfig.queue;
        bool isContinue = false;
        IModel channel;
        Thread thread;

        public MessageProducer()//New 构造函数
        {
            
        }

        public MessageProducer(string exChange, string type, string queue, string routingKey)//New 构造函数
        {
            this.exChange = exChange;
            this.type = type;
            this.queue = queue;
            this.routingKey = routingKey;
        }

        public void Start()
        {
            thread = new Thread(new ThreadStart(MessageProducerStart));//启动发送线程
            thread.Start();
        }

        void MessageProducerStart()
        {
            using (IConnection conn = MessageFactory.Instance.Factory.CreateConnection())
            {
                using (channel = conn.CreateModel())
                {
                    channel.ExchangeDeclare(exChange, type);//声明转发器(交换器,类型)
                    //如果声明一个已经存在的queue或exchange时，声明的属性(持久化Durable、自动删除等)必须与服务器一致，否则会抛出异常
                    channel.QueueDeclare(queue, RabbitMQConfig.IsDurable, false, false, null);
                    channel.QueueBind(queue, exChange, routingKey);//为转发器指定队列，设置binding
                    isContinue = true;
                    while (isContinue)
                    {

                    }
                }
            }
        }

        public void Destroy()
        {
            isContinue = false;
            //thread.Join();
            thread.Abort();
        }

        public void SendMessage(string St)//发送
        {
            byte[] String = System.Text.Encoding.UTF8.GetBytes(St);
            channel.BasicPublish(exChange, routingKey, null, String);
            Console.WriteLine(St + "已发送");
        }
    }
}

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestRabbitMQ
{
    class MessageConsumerWithSubscribe
    {
        string exChange = RabbitMQConfig.exchange;
        string type = RabbitMQConfig.type;
        string queue = RabbitMQConfig.queue;
        string routingKey = RabbitMQConfig.queue;
        IModel channel;
        public event DeliverEventHandler deliverCallback;
        Thread thread;
        bool isContinue;
        QueueingBasicConsumer consumer;
        readonly ushort maxFetchCount = 5;
        List<BasicDeliverEventArgs> deliverList = new List<BasicDeliverEventArgs>();

        public MessageConsumerWithSubscribe()//New 构造函数
        {

        }

        public MessageConsumerWithSubscribe(string exChange, string type, string queue, string routingKey)//New 构造函数
        {
            this.exChange = exChange;
            this.type = type;
            this.queue = queue;
            this.routingKey = routingKey;
        }
        public void Start()
        {
            //IConnection conn = MessageFactory.Instance.Factory.CreateConnection();
            //channel = conn.CreateModel();
            //channel.ExchangeDeclare(exChange, type);//声明转发器(交换器,类型)
            //channel.QueueDeclare(queue, RabbitMQConfig.IsDurable, false, false, null);
            //channel.QueueBind(queue, exChange, routingKey);//为转发器指定队列，设置bindings
            //channel.BasicQos(0, 1, false);
            //consumer = new QueueingBasicConsumer(channel);
            //channel.BasicConsume(queue, false, consumer);

            thread = new Thread(new ThreadStart(MessageConsumerStart));//启动发送线程
            thread.Start();
        }

        void MessageConsumerStart()
        {
            //IConnection conn = MessageFactory.Instance.Factory.CreateConnection();
            //channel = conn.CreateModel();
            //channel.ExchangeDeclare(exChange, type);//声明转发器(交换器,类型)
            //channel.QueueDeclare(queue, RabbitMQConfig.IsDurable, false, false, null);
            //channel.QueueBind(queue, exChange, routingKey);//为转发器指定队列，设置bindings
            //channel.BasicQos(0, 1, false);
            //consumer = new QueueingBasicConsumer(channel);
            //channel.BasicConsume(queue, false, consumer);

            using (IConnection conn = MessageFactory.Instance.Factory.CreateConnection())
            {
                using (channel = conn.CreateModel())
                {
                    channel.ExchangeDeclare(exChange, type);//声明转发器(交换器,类型)
                    channel.QueueDeclare(queue, RabbitMQConfig.IsDurable, false, false, null);
                    channel.QueueBind(queue, exChange, routingKey);//为转发器指定队列，设置binding

                    channel.BasicQos(0, maxFetchCount, false);
                    consumer = new QueueingBasicConsumer(channel);

                    //直接推送maxFetchCount个message到consumer.Queue，
                    channel.BasicConsume(queue, false, consumer);
                    isContinue = true;
                    while (isContinue)
                    {

                    }
                }
            }
        }

       
        public void GetMessage(bool noAck = false)
        {
            BasicDeliverEventArgs ea;
            if (consumer.Queue.Dequeue(2000, out ea))
            {
                deliverList.Add(ea);
                var msgBody = Encoding.UTF8.GetString(ea.Body);
                deliverCallback(this, new DeliverEventArgs(msgBody));
            }
            //    IConnection conn = MessageFactory.Instance.Factory.CreateConnection();
            //channel = conn.CreateModel();
            //channel.ExchangeDeclare(exChange, type);//声明转发器(交换器,类型)
            //channel.QueueDeclare(queue, RabbitMQConfig.IsDurable, false, false, null);
            //channel.QueueBind(queue, exChange, routingKey);//为转发器指定队列，设置bindings
            //msgResponse = channel.BasicGet(queue, noAck);
            //if (msgResponse != null)
            //{
            //    var msgBody = Encoding.UTF8.GetString(msgResponse.Body);
            //    deliverCallback(this, new DeliverEventArgs(msgBody));
            //    Console.WriteLine(string.Format("***接收时间:{0}，消息内容：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msgBody));
            //}
        }

        public void BasicAck()
        {
            ulong deliveryTag = deliverList[deliverList.Count - 1].DeliveryTag;
            Console.WriteLine("BasicAck：" + deliveryTag);
            channel.BasicAck(deliveryTag, true);
            deliverList.Clear();
        }

        public void Destroy()
        {
            isContinue = false;
            if (channel != null) channel.Close();
            channel = null;
            deliverList.Clear();
        }
    }
}

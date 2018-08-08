using System.Collections;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;
using System;
using System.Threading;
using System.Text;

namespace TestRabbitMQ
{
    public class MessageFactory
    {
        public string hosturi = RabbitMQConfig.hosturi;
        public string username = RabbitMQConfig.username;
        public string password = RabbitMQConfig.password;
        public string virtualHost = RabbitMQConfig.virtualHost;

        public ConnectionFactory Factory
        {
            get
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.VirtualHost = virtualHost;
                factory.UserName = username;
                factory.Password = password;
                factory.Endpoint = new AmqpTcpEndpoint(new Uri(hosturi));
                //timeout 为 0 来禁用心跳检测功能
                factory.RequestedHeartbeat = 0;
                return factory;
            }
        }

        private static MessageFactory _Instance = null;
        public static MessageFactory Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MessageFactory();
                }
                return _Instance;
            }
        }

        public MessageFactory()//New 构造函数
        {

        }
    }
}

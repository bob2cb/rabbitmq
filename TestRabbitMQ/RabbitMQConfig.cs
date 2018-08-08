using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRabbitMQ
{

    class RabbitMQConfig
    {
        public static string hosturi = "amqp://127.0.0.1:5672/";
        public static string username = "jhqc";
        public static string password = "cb123321";
        public static string virtualHost = "/";


        public static bool IsDurable = true;
        public static string exchange = "messages_exchange";
        public static string type = "direct";
        public static string routingKey = "messages_key";
        public static string queue = "messages_queue";
    }
}

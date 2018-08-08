using System;
using System.Windows.Forms;

using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;
using System.Text;

namespace TestRabbitMQ
{
    public partial class Form1 : Form
    {
        MessageProducer messageProducer;
        MessageConsumerWithGet consumerWithGet;
        MessageConsumerWithSubscribe consumerWithSubscribe;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            //Producer
            //Consumer

        }


        private void button_producer_Click(object sender, EventArgs e)
        {
            messageProducer = new MessageProducer();
            messageProducer.Start();
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                messageProducer.SendMessage("消息体" + i);
            }
        }


        private void button_initConsumer_Click(object sender, EventArgs e)
        {
            consumerWithGet = new MessageConsumerWithGet();
            consumerWithGet.deliverCallback += new DeliverEventHandler(DataProcess);

            consumerWithSubscribe = new MessageConsumerWithSubscribe();
            consumerWithSubscribe.deliverCallback += new DeliverEventHandler(DataProcess);
            consumerWithSubscribe.Start();
        }

        void DataProcess(object sender, DeliverEventArgs e)
        {
            Console.WriteLine(e.message);  //接收到的消息
        }


        private void button_RecieveMessageWithGet_Click(object sender, EventArgs e)
        {
            consumerWithGet.GetMessage(false);
        }

        private void button_AckMessageWithGet_Click(object sender, EventArgs e)
        {
            consumerWithGet.BasicAck();
        }

        private void button_RecieveMessageWithSubscribe_Click(object sender, EventArgs e)
        {
            consumerWithSubscribe.GetMessage();
        }

        private void button_AckMessageWithSubscribe_Click(object sender, EventArgs e)
        {
            consumerWithSubscribe.BasicAck();
        }
    }
}

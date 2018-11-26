using Com.ACBC.Framework.Database;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigService.Common
{
    public class Global
    {
        public const string ROUTE_PX = "/core";
        public const string NAMESPACE = "com.a-cubic.core.config";
        public const int REDIS_NO = 11;
        public const int REDIS_EXPIRY_H = 1;
        public const int REDIS_EXPIRY_M = 0;
        public const int REDIS_EXPIRY_S = 0;
        public const string MQ_QUEUE = "Bus";

        public static void StartUp()
        {
            if (DatabaseOperationWeb.TYPE == null)
            {
                DatabaseOperationWeb.TYPE = new DBManager();
            }

            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = MQ_USER,
                Password = MQ_PASSWORD,
                HostName = MQ_HOST,
                Port = MQ_PORT
            };
            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) => {
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"Queue:{"Bus"}收到消息： {message}");
                channel.BasicAck(ea.DeliveryTag, false);
            };
            channel.BasicConsume(MQ_QUEUE, false, consumer);
        }

        public static string MQ_USER
        {
            get
            {
                var key = System.Environment.GetEnvironmentVariable("MQ_USER");
                return key;
            }
        }

        public static string MQ_PASSWORD
        {
            get
            {
                var key = System.Environment.GetEnvironmentVariable("MQ_PASSWORD");
                return key;
            }
        }

        public static string MQ_HOST
        {
            get
            {
                var key = System.Environment.GetEnvironmentVariable("MQ_HOST");
                return key;
            }
        }

        public static int MQ_PORT
        {
            get
            {
                var key = Convert.ToInt32(System.Environment.GetEnvironmentVariable("MQ_PORT"));
                return key;
            }
        }

    }
}

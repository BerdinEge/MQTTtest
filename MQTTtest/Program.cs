using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MQTTnet;
//using MQTTnet.Client.Options;
//using Newtonsoft.Json;
using System.Security.Authentication;
//using MQTTnet.Client;
//using MQTTnet.Formatter;
using System.Text.Json;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTtest
{
    class Program
    {
        static double TRY_TIME_GAP = 5;
        static string clientId = "mqtestcli";
        static void Main(string[] args)
        {
            MqttClient client = new MqttClient("localhost");

            client.MqttMsgPublishReceived += onMessageReceived;

            while (client.IsConnected == false)
            {
                try
                {
                    client.Connect(clientId);
                }
                catch
                {
                    Console.WriteLine("The MQTT client could not connect. Retrying...");
                }
                finally
                {
                    Task.Delay(TimeSpan.FromSeconds(TRY_TIME_GAP)).Wait();
                }
            }

            Console.WriteLine("The MQTT client connected.");

            client.Subscribe(new string[] { "application/1/device/+/event/up" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            Console.WriteLine("The MQTT client subscribed.");

            client.ConnectionClosed += onConnectionClosed;
        }

        private static void onMessageReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string message = Encoding.Default.GetString(e.Message);
            Console.WriteLine("message = " + message);
        }

        private static void onConnectionClosed(object sender, EventArgs e)
        {
            Console.WriteLine("The MQTT client connection lost!");

            var mqClient = sender as MqttClient;

            while (mqClient.IsConnected == false)
            {
                try
                {
                    mqClient.Connect(clientId);
                }
                catch
                {
                    Console.WriteLine("The MQTT client could not connect. Retrying...");
                }
                finally
                {
                    Task.Delay(TimeSpan.FromSeconds(TRY_TIME_GAP)).Wait();
                }
            }

            Console.WriteLine("The MQTT client connected again.");

            mqClient.Subscribe(new string[] { "application/1/device/+/event/up" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            Console.WriteLine("The MQTT client subscribed.");
        }

    }
}

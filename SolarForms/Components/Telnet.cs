using OpenTK;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using TentacleSoftware.Telnet;

namespace SolarForms.Components
{
    class Telnet
    {
        public ReturnObject RetVal;
        public bool Done;
        public TelnetClient telnetClient;
        public int Planet;
        public List<string> output = new List<string>();
        public ReturnObject Run(int planet)
        {
            Planet = planet;

            telnetClient = new TelnetClient("horizons.jpl.nasa.gov", 6775, TimeSpan.FromSeconds(3), default(CancellationToken));
            telnetClient.ConnectionClosed += HandleConnectionClosed;
            telnetClient.MessageReceived += HandleMessageReceived;
            telnetClient.Connect();
         //   Console.ReadLine();
            while (!Done)
            {
                continue;
            }
            return RetVal;
        }

        private void HandleConnectionClosed(object sender, EventArgs e)
        {
            string resp = "";
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i].Contains("$$SOE"))
                    resp = $"{output[i + 2]}\n{output[i + 3]}";
            }

            // Console.WriteLine(resp);
            Regex r = new Regex(" X = (.+) Y = (.+) Z =(.+)\n VX=(.+) VY= (.+) VZ= (.+)");
            var test = r.Match(resp).Groups;
            RetVal = new ReturnObject(test[1].Value, test[2].Value, test[3].Value, test[4].Value, test[5].Value, test[6].Value);
            Done = true;
        }
        private void HandleMessageReceived(object sender, string message)
        {
            output.Add(message);
            if (message.Contains("System news updated"))
            {
                telnetClient.Send(Planet.ToString());
                Thread.Sleep(100);
                telnetClient.Send("E");
                Thread.Sleep(100);
                telnetClient.Send("v");
                Thread.Sleep(100);
                telnetClient.Send("@sun");
                Thread.Sleep(100);
                telnetClient.Send("eclip");
                Thread.Sleep(100);
                telnetClient.Send("2018AD-Nov-11 00:00");
                Thread.Sleep(100);
                telnetClient.Send("2018AD-Nov-11 00:01");
                Thread.Sleep(100);
                telnetClient.Send("1d");
                Thread.Sleep(100);
                telnetClient.Send("y");
            }
            else if (message.Contains("$$EOE"))
            {
                telnetClient.Disconnect();
            }

        }
    }
    class ReturnObject
    {
        public Vector3 Position;
        public Vector3 Velocity;

        public ReturnObject(string posx, string posy, string posz, string vecx, string vecy, string vecz)
        {
            float px = float.Parse(posx);
            float py = float.Parse(posy);
            float pz = float.Parse(posz);
            float vx = float.Parse(vecx);
            float vy = float.Parse(vecy);
            float vz = float.Parse(vecz);
            Position = new Vector3(px, py, pz);
            Velocity = new Vector3(vx, vy, vz);

        }
    }
}

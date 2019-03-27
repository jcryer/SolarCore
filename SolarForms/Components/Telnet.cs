using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            // Creates a telnet connection to NASA's Horizons database, on port 6775.
            telnetClient = new TelnetClient("horizons.jpl.nasa.gov", 6775, TimeSpan.FromSeconds(5), default(CancellationToken));

            // Event handler methods are setup for the Telnet connection being closed and for a message being received.
            telnetClient.ConnectionClosed += HandleConnectionClosed;
            telnetClient.MessageReceived += HandleMessageReceived;

            // This starts the Telnet connection.
            telnetClient.Connect();

            // Wait until completed.
            while (!Done)
            {
                continue;
            }
            return RetVal;
        }

        // This method uses multiple different RegEx statements to parse the returned information from NASA's system and get the required information:
        // - Name of the object
        // - Mass of the object
        // - Radius of the object
        // - Position vector (x, y, z) at a specific point in time
        // - Velocity vector (x, y, z) at the same specific point in time
        private void HandleConnectionClosed(object sender, EventArgs e)
        {
            string ephemeris = "";
            string data = "";

            for (int i = 0; i < output.Count; i++)
            {
                if (output[i].Contains("*******************************************************************************"))
                {
                    for (int j = i; j < output.Count; j++)
                    {
                        data += $"{output[j+1]}\n";
                        if (output[j+2].Contains("*******************************************************************************"))
                        {
                            break;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine(data);
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i].Contains("$$SOE"))
                    ephemeris = $"{output[i + 2]}\n{output[i + 3]}";
            }

            Regex nameRegex = new Regex(" {2}(\\w+) +" + Planet);
            var nameMatches = nameRegex.Match(data).Groups;

            Regex massRegex = new Regex("Mass,* x*10\\^(.+) \\(*kg\\)* *= *~*([\\d.]+)[\n +-]");
            var massMatches = massRegex.Match(data).Groups;

            Regex radiusRegex = new Regex("Vol\\. [Mm]ean [Rr]adius,* \\(*km[\\)]* *= *([\\d.]+)[\n +-]");
            var radiusMatches = radiusRegex.Match(data).Groups;

            Regex ephemerisRegex = new Regex(" X {0,1}= {0,1}(.+) Y {0,1}= {0,1}(.+) Z {0,1}= {0,1}(.+)\n VX {0,1}= {0,1}(.+) VY {0,1}= {0,1}(.+) VZ {0,1}= {0,1}(.+)");
            var ephemerisMatches = ephemerisRegex.Match(ephemeris).Groups;
            RetVal = new ReturnObject(ephemerisMatches[1].Value, ephemerisMatches[2].Value, ephemerisMatches[3].Value, ephemerisMatches[4].Value, ephemerisMatches[5].Value, ephemerisMatches[6].Value, massMatches[2].Value, massMatches[1].Value, radiusMatches[1].Value, nameMatches[1].Value);
            Done = true;
        }


        // This method transmits a series of instructions to NASA's Horizons system, requesting the name, mass and radius values of a specific object
        // as well as the specific position and velocity vectors at a specific point in time.
        // This request is done in relation to the Sun, meaning that the Sun is at 0,0,0 in this co-ordinate system.
        private void HandleMessageReceived(object sender, string message)
        {
            Console.WriteLine(message);
            output.Add(message);
            if (message.Contains("System news updated"))
            {
                telnetClient.Send(Planet.ToString());
                Thread.Sleep(50);
                telnetClient.Send("E");
                Thread.Sleep(50);
                telnetClient.Send("v");
                Thread.Sleep(50);
                telnetClient.Send("@sun");
                Thread.Sleep(50);
                telnetClient.Send("eclip");
                Thread.Sleep(50);
                telnetClient.Send("2018AD-Nov-11 00:00");
                Thread.Sleep(50);
                telnetClient.Send("2018AD-Nov-11 00:01");
                Thread.Sleep(50);
                telnetClient.Send("1d");
                Thread.Sleep(50);
                telnetClient.Send("y");
            }
            else if (message.Contains("$$EOE"))
            {
                telnetClient.Disconnect();
            }
        }
    }

    // Simple object created to be able to return all values in a format that can then be worked with more easily later on.
    // It also contains methods that convert the six individual position/velocity values returned into a position Vector3 and a velocity Vector3.
    class ReturnObject
    {
        public string Name;
        public double Mass;
        public double Radius;

        private float px;
        private float py;
        private float pz;
        private float vx;
        private float vy;
        private float vz;

        public ReturnObject(string posx, string posy, string posz, string vecx, string vecy, string vecz, string mass, string power, string radius, string name)
        {
            px = float.Parse(posx) * 1.496e+11f;
            py = float.Parse(posy) * 1.496e+11f;
            pz = float.Parse(posz) * 1.496e+11f;
            vx = float.Parse(vecx) * 1731456.83681f;
            vy = float.Parse(vecy) * 1731456.83681f;
            vz = float.Parse(vecz) * 1731456.83681f;
            Mass = double.Parse($"{mass}E{power}");
            Radius = double.Parse(radius);
            Name = name;
        }

        public Vector3 GetPosition()
        {
            return new Vector3(px, py, pz);
        }

        public Vector3 GetVelocity()
        {
            return new Vector3(vx, vy, vz);
        }
    }
}
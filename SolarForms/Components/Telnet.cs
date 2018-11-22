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

            // Console.WriteLine(resp);
            // string ohGod = "Mass x10\^(.+) \(kg\) *= *([\d.]+)[\n +-]";

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

        private void HandleMessageReceived(object sender, string message)
        {
            output.Add(message);
            if (message.Contains("System news updated"))
            {
                telnetClient.Send(Planet.ToString());
                Thread.Sleep(10);
                telnetClient.Send("E");
                Thread.Sleep(10);
                telnetClient.Send("v");
                Thread.Sleep(10);
                telnetClient.Send("@sun");
                Thread.Sleep(10);
                telnetClient.Send("eclip");
                Thread.Sleep(10);
                telnetClient.Send("2018AD-Nov-11 00:00");
                Thread.Sleep(10);
                telnetClient.Send("2018AD-Nov-11 00:01");
                Thread.Sleep(10);
                telnetClient.Send("1d");
                Thread.Sleep(10);
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
        public string Name;
        public double Mass;
        public double Radius;

        private float px;
        private float py;
        private float pz;
        private float vx;
        private float vy;
        private float vz;

        [JsonConstructor]
        public ReturnObject(string name, double mass, double radius, float px, float py, float pz, float vx, float vy, float vz)
        {
            if (name != "")
                Name = name;
            else
            {
                Name = "unknown";
            }
            Mass = mass;
            Radius = radius;
            this.px = px;
            this.py = py;
            this.pz = pz;
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
        }

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
    public class PrivateContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(p => base.CreateProperty(p, memberSerialization))
                        .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                   .Select(f => base.CreateProperty(f, memberSerialization)))
                        .ToList();
            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        }
    }
}

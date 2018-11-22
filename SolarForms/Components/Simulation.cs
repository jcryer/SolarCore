using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    public class Simulation
    {
        public string Name;
        public List<string> NameOfObjects;
        public float SimScale;
        public float CameraRadiusModifier;
        public float TimeConstant;
        public bool FixedLocation = false;

        [JsonIgnore]
        public List<SimulationObject> Objects;

        [JsonIgnore]
        public List<SimulationObject> PreRenderedObjects;

        [JsonIgnore]
        public bool PreRenderComplete = false;

        public Simulation()
        {
            Objects = new List<SimulationObject>();
        }

        public void Add(SolarObject obj)
        {
            Objects.Add(new SimulationObject(obj));
        }

        public void Run(int frames, bool prerender = false)
        {
            if (!prerender)
            {
                foreach (var file in Directory.GetFiles("PlanetaryData"))
                {
                    if (NameOfObjects.Contains(file.Replace(".json", "").Replace("PlanetaryData\\", "")))
                    {
                        var obj = JsonConvert.DeserializeObject<SolarObject>(File.ReadAllText(file));
                        Objects.Add(new SimulationObject(obj));
                    }

                }
            }
            else
            {
              //   PreRenderedObjects.Add(new SimulationObject())
            }

            /*
            foreach (var x in testing)
            {
                Console.WriteLine("aaaa");
                var returnedValue = new Telnet().Run(x);

                File.WriteAllText($"testData/{returnedValue.Name}", JsonConvert.SerializeObject(returnedValue, settings));
                Controller.SimObject.Objects.Add(new SimulationObject(new SolarObject(returnedValue.Name, returnedValue.Mass, returnedValue.Radius, 0, 0, returnedValue.GetPosition(), returnedValue.GetVelocity(), Color4.Orange)));
            }*/

            while (Objects.First().Positions.Count < frames)
            {
                List<AggregateObject> response = new List<AggregateObject>();
                foreach (var obj in Objects.Select(x => x.Object))
                {
                    response.Add(GravityMethods.RecalculateValues(obj, Objects.Select(x => x.Object).Where(x => x != obj).ToList(), TimeConstant));
                }

                foreach (var x in response)
                {
                    var currentObject = Objects.First(y => y.Object == x.Object);
                    currentObject.Object.Velocity = x.Velocity;
                    currentObject.Object.Position = x.Position;
                    currentObject.Positions.Add(x.Position);
                }
            }
        }
    }

    public class SimulationObject
    {
        public SolarObject Object;

        [JsonIgnore]
        public List<Vector3> Positions;

        public SimulationObject(SolarObject @object)
        {
            Object = @object;
            Positions = new List<Vector3>();
        }
    }
}

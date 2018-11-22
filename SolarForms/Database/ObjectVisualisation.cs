using OpenTK.Graphics;

namespace SolarForms.Database
{
    class ObjectVisualisation
    {
        int SimulationID;
        int ObjectID;
        bool TrailsActive;
        int TrailLength;
        Color4 TrailColour;
        Color4 ObjectColour;

        public ObjectVisualisation(int simulationID, int objectID, bool trailsActive, int trailLength, Color4 trailColour, Color4 objectColour)
        {
            SimulationID = simulationID;
            ObjectID = objectID;
            TrailsActive = trailsActive;
            TrailLength = trailLength;
            TrailColour = trailColour;
            ObjectColour = objectColour;
        }

        public bool Get(int location)
        {
            return true;
        }
    }
}
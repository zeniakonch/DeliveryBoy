using System;

namespace TrafficLightScript
{
    public static class ColorsOperations
    {

        public static float GetColorTime(TrafficLightScriptableObject trafficLightSettings, Color color)
        {
            switch (color)
            {
                case Color.Green: return trafficLightSettings.timeGreen;
                
                case Color.Orange: return trafficLightSettings.timeOrange;
                
                case Color.Red: return trafficLightSettings.timeRed;
                
                default: throw new ArgumentException($"Color {color} doesn't exist");
            }
        }
        
        public static Color GetNextColor(Color color)
        {
            switch (color)
            {
                case Color.Green: return Color.Red;
                
                case Color.Red: return Color.Orange;
                
                case Color.Orange: return Color.Green;
                
                default: throw new ArgumentException($"Color {color} doesn't exist"); 
            }
        }
    }
}

using SampSharp.Entities.SAMP;

namespace OpenRP.GameMode.Data.Models
{
    public class Actor
    {
        public ulong Id { get; set; }
        public int Model { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Angle { get; set; }
    }
}
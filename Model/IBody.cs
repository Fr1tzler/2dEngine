using System;
using SFML.System;

namespace tempProject.Model
{
    public interface IBody
    {
        public bool CollidedWith(IBody other);
        public Tuple<Vector2f, Vector2f> BoundingBox { get; set; }
        public double Rotation { get; set; }
        public double RotationVelocity { get; set; }
        public double RotationAcceleration { get; set; }
        public Vector2f Position { get; set; }
        public Vector2f Velocity { get; set; }
        public Vector2f Acceleration { get; set; }
        
        public float EffectiveRadius { get; }
        public Vector2f MassCenter { get; }
        public void Update(float deltaTime);
    }
}
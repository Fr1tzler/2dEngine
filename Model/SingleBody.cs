using System;
using System.Collections.Generic;
using System.Linq;
using SFML.System;

namespace tempProject.Model
{
    public class SingleBody : IBody
    {
        public readonly List<Vector2f> Geometry;
        public double Rotation { get; set; }
        public double RotationVelocity { get; set; }
        public double RotationAcceleration { get; set; }
        public Vector2f Position { get; set; }
        public Vector2f Velocity { get; set; }
        public Vector2f Acceleration { get; set; }
        public Tuple<Vector2f, Vector2f> BoundingBox { get; set; }

        public Vector2f MassCenter { get; }

        public float Mass { get; set; }

        public bool CollidedWith(IBody other)
        {
            //var distance = MathModule.Hypot(Position - other.Position);
            //if (distance > EffectiveRadius + other.EffectiveRadius) 
            //    return false;
            return MathModule.BoxIntersected(BoundingBox, other.BoundingBox);
        }
        public float EffectiveRadius { get; }

        private void UpdateBoundingBox()
        {
            var points = Geometry
                .Select(elem => elem.RotatedBy(Rotation));
            var pointsX = points
                .Select(elem => elem.X);
            var pointsY = points
                .Select(elem => elem.Y);
            var from = new Vector2f(pointsX.Min(), pointsY.Min());
            var to = new Vector2f(pointsX.Max(), pointsY.Max());
            BoundingBox = new Tuple<Vector2f, Vector2f>(from, to);
        }
        
        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
            Velocity += Acceleration * deltaTime;
            Rotation += RotationVelocity * deltaTime;
            RotationVelocity += RotationAcceleration * deltaTime;
            UpdateBoundingBox();
        }
        
        public SingleBody(List<Vector2f> geometry, Vector2f position, Vector2f velocity, Vector2f acceleration)
        {
            Geometry = geometry;
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
            MassCenter = new Vector2f(0, 0);
            foreach (var vector2F in Geometry)
            {
                MassCenter += vector2F;
            }

            MassCenter *= 1f / Geometry.Count;
            Mass = 1;
            EffectiveRadius = Geometry
                .Select(elem => MathModule.Hypot(elem))
                .Max();
            UpdateBoundingBox();
        }
    }
}
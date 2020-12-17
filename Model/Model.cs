using System;
using System.Collections.Generic;
using SFML.System;

namespace tempProject.Model
{
    public class Model
    {
        public List<SingleBody> Bodies;

        public Model()
        {
            Bodies = new List<SingleBody>();
            var geo = new List<Vector2f>();
            geo.Add(new Vector2f(0, 0));
            geo.Add(new Vector2f(20, 20));
            geo.Add(new Vector2f(0, 20));
            Bodies.Add(new SingleBody(geo, new Vector2f(0, 0), new Vector2f(0.05f, 0.05f), new Vector2f(0.05f, 0.05f)));
            Bodies.Add(new SingleBody(geo, new Vector2f(0, 100), new Vector2f(0.05f, 0f), new Vector2f(0.05f, 0f)));
            geo = new List<Vector2f>();
            geo.Add(new Vector2f(0, 0));
            geo.Add(new Vector2f(0, 5));
            geo.Add(new Vector2f(800, 5));
            geo.Add(new Vector2f(800, 0));
            Bodies.Add(new SingleBody(geo, new Vector2f(0, 0), new Vector2f(0f, 0f), new Vector2f(0f, 0f)));

        }

        public void Update(float dt)
        {
            foreach (var singleBody in Bodies)
            {
                singleBody.Update(dt);
            }

            for (var bodyId = 1; bodyId < Bodies.Count; bodyId++)
            {
                for (var bodyId2 = 0; bodyId2 < bodyId; bodyId2++)
                {
                    if (Bodies[bodyId].CollidedWith(Bodies[bodyId2]))
                    {
                        Bodies[bodyId].Acceleration *= -1f;
                        Bodies[bodyId].Velocity *= -1f;
                        Bodies[bodyId2].Acceleration *= -1f;
                        Bodies[bodyId2].Velocity *= -1f;
                    } 
                }
            }
        }
    }
}
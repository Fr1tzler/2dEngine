using System.Collections.Generic;
using  SFML.Graphics;
using SFML.System;

namespace tempProject.View
{
    public class View : Drawable
    {
        private List<Shape> Shapes;
        public void Update(Model.Model model)
        {
            Shapes = new List<Shape>();
            foreach (var singleBody in model.Bodies)
            {
                var shape = new ConvexShape((uint)singleBody.Geometry.Count);
                shape.Position = singleBody.Position;
                shape.Rotation = (float)singleBody.Rotation;
                for (int i = 0; i < singleBody.Geometry.Count; i++)
                {
                    shape.SetPoint((uint)i, singleBody.Geometry[i]);
                }
                shape.FillColor = Color.White;
                Shapes.Add(shape);
                var bb = singleBody.BoundingBox;
                var foo = new RectangleShape(bb.Item2 - bb.Item1);
                foo.Position = singleBody.Position;
                foo.FillColor = new Color(250, 0, 0, 100);
                Shapes.Add(foo);
            }
        }

        public View()
        {
            
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var shape in Shapes)
            {
                target.Draw(shape);
            }
        }
    }
}
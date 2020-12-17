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
                for (int i = 0; i < singleBody.Geometry.Count; i++)
                {
                    shape.SetPoint((uint)i, singleBody.Geometry[i]);
                }
                shape.FillColor = Color.White;
                Shapes.Add(shape);
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
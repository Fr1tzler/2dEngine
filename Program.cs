 using System;
 using SFML.Graphics;
 using SFML.System;
 using SFML.Window;

 namespace tempProject
{
    class Program
    {
        private static RenderWindow _window;
        public static Model.Model model;
        public static View.View view;
        
        static void Main(string[] args)
        {
            _window = new RenderWindow(new VideoMode(800, 600), "test");
            _window.SetVerticalSyncEnabled(true);
            _window.Closed += WindowClosed;

            model = new Model.Model();
            view = new View.View();
            var currentTime = DateTime.Now;
            
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                
                model.Update((float)(DateTime.Now - currentTime).TotalMilliseconds / 10);
                view.Update(model);
                _window.Draw(view);
                currentTime = DateTime.Now;
                _window.Display();
            }
        }

        private static void WindowClosed(object sender, EventArgs e) => _window.Close();
    }
}
using Microsoft.Xna.Framework;

namespace SATTutorial.PhysicsEngine.Bodies
{
    public class Body
    {
        public Vector2 Location { get; set; }

        public Body(Vector2 location)
        {
            Location = location;
        }
    }
}

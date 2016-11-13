using Microsoft.Xna.Framework;

namespace SATTutorial.PhysicsEngine.Bodies
{
    public class Body
    {
        public Vector2 Location { get; set; }
        public Matrix RotationMatrix { get; set; }
        public Vector2 Velocity { get; set; }

        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;

                //setup the rotation matrix here once upon change
                RotationMatrix = Matrix.CreateRotationZ(value);
            }
        }

        private float rotation;

        public Body(Vector2 location)
        {
            Location = location;
            RotationMatrix = Matrix.Identity;
        }
    }
}

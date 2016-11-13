using SATTutorial.PhysicsEngine.Bodies;
using System.Collections.Generic;

namespace SATTutorial.PhysicsEngine
{
    public class PhysicsManager
    {
        private List<Body> bodies { get; set; }
        public Dictionary<Body, List<Body>> potentialCollisions { get; set; }

        public PhysicsManager()
        {
            bodies = new List<Body>();
            potentialCollisions = new Dictionary<Body, List<Body>>();
        }

        public void AddBody(Body newBody)
        {
            bodies.Add(newBody);
        }

        public void RemoveBody(Body body)
        {
            bodies.Remove(body);
        }

        public void Update(float elapsedTime)
        {
            foreach (Body body in bodies)
            {
                body.Location += body.Velocity * elapsedTime;
            }
        }
    }
}

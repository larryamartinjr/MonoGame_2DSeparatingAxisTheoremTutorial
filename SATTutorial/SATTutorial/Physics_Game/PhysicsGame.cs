using Microsoft.Xna.Framework;
using SATTutorial.Content;
using SATTutorial.Entities;
using SATTutorial.PhysicsEngine;
using SATTutorial.PhysicsEngine.Bodies;
using System.Collections.Generic;

namespace SATTutorial.Physics_Game
{
    public class PhysicsGame
    {
        public List<Drawable> Drawables { get; set; }
        public Drawable Player { get; set; }
        public float PhysicsTimer { get; set; }
        public float PhysicsDelay = 1 / 100f;
        public PhysicsManager Physics;

        public PhysicsGame()
        {
            Drawables = new List<Drawable>();
            Physics = new PhysicsManager();
        }

        public void Update(GameTime gameTime)
        {
            PhysicsTimer += gameTime.ElapsedGameTime.Milliseconds / 1000f;

            if (PhysicsTimer > PhysicsDelay)
            {
                Physics.Update(PhysicsDelay);
                PhysicsTimer -= PhysicsDelay;
            }
        }

        public void CreatePlayer()
        {
            Drawable player = new Drawable();
            player.texture = ContentStore.Player;
            player.body = new Body(new Vector2(200, 200));


            Drawables.Add(player);
            Physics.AddBody(player.body);

            Player = player;
        }
    }
}

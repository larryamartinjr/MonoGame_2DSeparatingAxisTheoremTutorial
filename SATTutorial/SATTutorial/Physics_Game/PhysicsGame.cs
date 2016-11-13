using Microsoft.Xna.Framework;
using SATTutorial.Content;
using SATTutorial.Entities;
using SATTutorial.PhysicsEngine.Bodies;
using System.Collections.Generic;

namespace SATTutorial.Physics_Game
{
    public class PhysicsGame
    {
        public List<Drawable> Drawables { get; set; }

        public PhysicsGame()
        {
            Drawables = new List<Drawable>();
        }

        public void CreatePlayer()
        {
            Drawable player = new Drawable();
            player.texture = ContentStore.Player;
            player.body = new Body(new Vector2(200, 200));


            Drawables.Add(player);
        }
    }
}

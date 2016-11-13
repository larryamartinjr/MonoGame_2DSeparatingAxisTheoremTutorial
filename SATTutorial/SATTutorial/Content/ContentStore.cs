using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SATTutorial.Content
{
    public class ContentStore
    {
        public static Texture2D Player;

        public static void LoadContent(ContentManager content)
        {
            Player = content.Load<Texture2D>("Player");
        }
    }
}

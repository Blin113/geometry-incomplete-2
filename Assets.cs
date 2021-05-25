using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    static class Assets
    {
        public static Texture2D Pixel { get; private set; }

        public static Texture2D PauseScreen { get; private set; }
        
        public static Texture2D Croshair { get; private set; }

        public static Texture2D PowerUp { get; private set; }

        public static Texture2D Player { get; private set; }

        public static Texture2D BulletTexture { get; private set; }

        public static Texture2D Enemy { get; private set; }

        public static SpriteFont MenuFont { get; private set; }

        public static void LoadAssets(ContentManager content, GraphicsDevice graphics)
        {
            Pixel = new Texture2D(graphics, 1, 1);
            Pixel.SetData(new Color[] { Color.White });

            MenuFont = content.Load<SpriteFont>("Menu");

            Croshair = content.Load<Texture2D>("croshair");

            PowerUp = content.Load<Texture2D>("PowerUp");

            PauseScreen = content.Load<Texture2D>("PauseScreen");

            BulletTexture = content.Load<Texture2D>("BulletTexture");

            Enemy = content.Load<Texture2D>("Enemy");

            Player = content.Load<Texture2D>("Player");
        }
    }
}

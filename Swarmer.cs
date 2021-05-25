using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Template
{
    class Swarmer : BaseObject
    {
        private float speed;

        public Swarmer(Texture2D texture, Vector2 texturePos, float angle) : base(texture, texturePos, angle)
        {
            hitBox.Size = new Point(15, 15);
            hitBox.Location = texturePos.ToPoint();
        }

        public override void Update(Camera camera)
        {
            angle = (float)Math.Atan2(texturePos.Y - Player.CurrentPlayerPos.Y, texturePos.X - Player.CurrentPlayerPos.X) + (float)(Math.PI);

            hitBox.Location = texturePos.ToPoint();

            SearchAndDestroy();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Enemy, new Rectangle((int)texturePos.X, (int)texturePos.Y, 15, 15), null, Color.White, angle, new Vector2(Assets.Player.Width / 2, Assets.Player.Height / 2), SpriteEffects.None, 0);
        }

        public void SearchAndDestroy()
        {
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            speed = 1.5f;
            texturePos += direction * speed;
        }
    }
}

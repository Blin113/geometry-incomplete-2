using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Template
{
    class WeaponPowerUp : BaseObject
    {
        private List<WeaponPowerUp> weaponPowerUps = new List<WeaponPowerUp>();

        public WeaponPowerUp(Texture2D texture, Vector2 texturePos, float angle) : base(texture, texturePos, angle)
        {
            hitBox.Size = new Point(15, 15);
        }

        public override void Update(Camera camera)
        {
            hitBox.Location = texturePos.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.PowerUp, new Rectangle((int)texturePos.X, (int)texturePos.Y, 15, 15), Color.White);
        }
    }
}

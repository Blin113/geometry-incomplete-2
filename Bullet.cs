using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Bullet : BaseClass
    {
        private Vector2 speed;
        private Point size = new Point(4, 4);

        private DamageOrigin damageOrigin;

        public DamageOrigin GetDamageOrigin
        {
            get => damageOrigin;
            set => damageOrigin = value;
        }

        public Bullet(Vector2 texturePos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin) : base(Assets.BulletTexture, texturePos, angle, mousePos)
        {
            this.damageOrigin = damageOrigin;
            this.speed = speed;

            hitBox.Size = this.size;
        }

        public override void Update(Camera camera)
        {
            texturePos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 5;

            hitBox.Location = texturePos.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.BulletTexture, HitBox, null, Color.White, angle, new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), SpriteEffects.None, 0);
        }
    }

    enum DamageOrigin
    {
        player,
        enemy
    }
}
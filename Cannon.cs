using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Cannon : BaseObject
    {
        private WeaponHandler weaponHandler;

        private Random rnd = new Random();

        private float speed;

        public Cannon(Texture2D texture, Vector2 texturePos, float angle, WeaponHandler weaponHandler) : base(texture, texturePos, angle)
        {
            this.weaponHandler = weaponHandler;
            hitBox.Size = new Point(30, 30);
        }

        public override void Update(Camera camera)
        {
            angle = (float)Math.Atan2(texturePos.Y - Player.CurrentPlayerPos.Y, texturePos.X - Player.CurrentPlayerPos.X) + (float)(Math.PI);

            

            if (rnd.Next(0, 100) < 100)
            {
                weaponHandler.Shoot(texturePos, angle, new Vector2(), new Point(), Player.CurrentPlayerPos, DamageOrigin.enemy, Trigger.Pressed);   //how do i handle the trigger here?
            }

            hitBox.Location = texturePos.ToPoint();

            while (texturePos.X >= Player.CurrentPlayerPos.X + 200 || texturePos.X <= Player.CurrentPlayerPos.X - 200 && texturePos.Y >= Player.CurrentPlayerPos.Y + 200 || texturePos.Y <= Player.CurrentPlayerPos.Y - 200)
            {
                SearchAndDestroy();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Enemy, new Rectangle((int)texturePos.X, (int)texturePos.Y, 30, 30), null, Color.White, angle, new Vector2(Assets.Enemy.Width / 2, Assets.Enemy.Height / 2), SpriteEffects.None, 0);
        }

        public void SearchAndDestroy()
        {
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            speed = 1.2f;
            texturePos += direction * speed;
        }

        public void SetEnemyWeaponHandler(WeaponHandler wH)
        {
            weaponHandler = wH;
        }
    }
}

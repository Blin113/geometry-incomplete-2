using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class SMG : IShoot
    {
        
        List<Bullet> bullets;

        private float coolDowm = 0.2f;
        private float timeLastShot= 0;
        public GameTime gameTime;

        public SMG(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }

        public float CoolDown
        {
            get { return coolDowm; }
        }

        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin, Trigger trigger)
        {
            float timeShot = (float)Game1.Time.TotalGameTime.TotalSeconds;
            
            if((timeShot-timeLastShot)>= coolDowm)
            {
                timeLastShot = timeShot;
                bullets.Add(new Bullet(playerPos, angle, speed, size, mousePos, damageOrigin));
            }
        }
    }
}

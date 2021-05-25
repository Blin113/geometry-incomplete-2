using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Shotgun : IShoot
    {
        private float coolDown = 0.8f;
        private float timeLastShot = 0;
        List<Bullet> bullets;
        float spread = 0;


        Random random = new Random();

        public Shotgun(List<Bullet> bullets)
        {
            this.bullets = bullets;
        }

        public float CoolDown
        {
            get { return coolDown; }
        }

        void IShoot.Shoot(Vector2 playerPos, float angle, Vector2 speed, Point size, Vector2 mousePos, DamageOrigin damageOrigin, Trigger trigger)
        {
            float timeShot = (float)Game1.Time.TotalGameTime.TotalSeconds;

            if (trigger != Trigger.Pressed)
            {
                return;
            }   
            else if ((timeShot - timeLastShot) >= coolDown)
            {
                if(damageOrigin == DamageOrigin.enemy)
                {

                }
                for (int i = 0; i < 6; i++)
                {
                    timeLastShot = timeShot;

                    float originalAngle = angle;

                    spread = random.Next(-50, 50);
                    spread /= 100;
                    angle = angle + spread;

                    bullets.Add(new Bullet(playerPos, angle, speed, size, mousePos, damageOrigin));

                    angle = originalAngle;
                }
            }
        }
    }
}

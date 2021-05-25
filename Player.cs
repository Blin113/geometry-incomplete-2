using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    enum Trigger
    {
        Pressed,
        Held
    }
    class Player : BaseClass, ICollision
    {
        private WeaponHandler weaponHandler;
        private Health health;

        private MouseState old;
        private MouseState current;

        private int speed;

        public static Vector2 CurrentPlayerPos;

        public Health Health
        {
            get => health;
        }

        public Player(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos) : base(texture, texturePos, angle, mousePos)
        {
            hitBox.Size = new Point(20, 20);
            health = new Health(10, 1);
        }

        public override void Update(Camera camera)
        {
            //border
            if (texturePos.X <= 0)
            {
                texturePos.X = 0;
            }
            if (texturePos.X >= 4000)
            {
                texturePos.X = 4000;
            }
            if (texturePos.Y <= 0)
            {
                texturePos.Y = 0;
            }
            if (texturePos.Y >= 4000)
            {
                texturePos.Y = 4000;
            }

            //shooting and rotation
            mousePos = Mouse.GetState().Position.ToVector2();

            KeyboardState kstate = Keyboard.GetState();

            angle = (float)Math.Atan2(mousePos.Y - camera.Bounds.Height/2 , mousePos.X - camera.Bounds.Width/2);

            hitBox.Location = texturePos.ToPoint();

            old = current;
            current = Mouse.GetState();
            
            if (current.LeftButton == ButtonState.Pressed)
            {
                Trigger trigger = Trigger.Pressed;
                if (old.LeftButton == ButtonState.Pressed && current.LeftButton == ButtonState.Pressed)
                {
                    trigger = Trigger.Held;
                }
                    
                weaponHandler.Shoot(texturePos, angle, new Vector2(), new Point(), mousePos, DamageOrigin.player, trigger);
            }

            old = Mouse.GetState();

            Move(kstate);

            CurrentPlayerPos = new Vector2(texturePos.X, texturePos.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Player, new Rectangle((int)texturePos.X, (int)texturePos.Y, 20, 20), null, Color.White, angle, new Vector2(Assets.Player.Width / 2,Assets.Player.Height / 2), SpriteEffects.None, 0);
            
        }

        public void SetWeaponHandler(WeaponHandler wH)
        {
            weaponHandler = wH;
        }

        public void Move(KeyboardState kstate)
        {
            //Player movement
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));

            if (kstate.IsKeyDown(Keys.LeftShift))
            {
                speed = 4;
            }
            else
            {
                speed = 2;
            }

            if (kstate.IsKeyDown(Keys.W))
            {
                texturePos += direction * speed;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                texturePos -= direction * speed * .75f;
            }
        }

        public void Collision(Swarmer swarmer_Collider, Bullet bullet_Collider)
        {
            if (swarmer_Collider is Swarmer || bullet_Collider is Bullet)
            {
                health.currentHP -= 2;
            }
        }

        public bool IsDead()
        {
            return health.currentHP <= 0;
        }
    }
}

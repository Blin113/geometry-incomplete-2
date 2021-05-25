using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    abstract class BaseObject
    {
        protected Texture2D texture;
        protected Vector2 texturePos;
        protected float angle = 0;
        protected Rectangle hitBox;

        public Vector2 Position
        {
            get => texturePos;
            set => texturePos = value;
        }

        public Rectangle HitBox
        {
            get => hitBox;
        }

        public BaseObject(Texture2D texture, Vector2 texturePos, float angle)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
        }

        public abstract void Update(Camera camera);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}

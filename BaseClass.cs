using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public abstract class BaseClass
    {
        protected Texture2D texture;
        protected Vector2 texturePos;
        protected float angle = 0;
        protected Vector2 mousePos;
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

        public BaseClass(Texture2D texture, Vector2 texturePos, float angle, Vector2 mousePos)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.mousePos = mousePos;
        }

        public abstract void Update(Camera camera);

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}

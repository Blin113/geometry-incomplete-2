using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Grid
    {
        int length = 20;
        int height = 20;
        int columns = 200;
        int rows = 200;
        Vector2 position = Vector2.Zero;

        public void Draw(SpriteBatch spriteBatch, Texture2D texture1px)
        {    
            for (float x = 0; x < columns+1; x++)
            {
                Rectangle rectangle = new Rectangle((int)(position.X + x * 20), (int)position.Y, 1, height*rows);
                spriteBatch.Draw(texture1px, rectangle, Color.Blue);
            }
            for (float y = 0; y < rows+1; y++)
            {
                Rectangle rectangle = new Rectangle((int)position.X, (int)(position.Y + y * 20), length*columns, 1);
                spriteBatch.Draw(texture1px, rectangle, Color.Blue);
            }
        }
    }
}

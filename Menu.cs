using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    //menu
    enum CurrentMenu
    {
        StartMenu,
        ColorMenu,
        PauseMenu,
        DeathMenu,
        None
    }

    class Menu
    {
        public CurrentMenu CurrentMenu { get { return currentMenu; } }

        CurrentMenu currentMenu = CurrentMenu.StartMenu;

        private Player player;


        public Menu(Player player)
        {
            this.player = player;
        }

        public void Update()
        {
            switch (currentMenu)
            {
                case CurrentMenu.StartMenu:
                    StartMenu();
                    break;

                case CurrentMenu.ColorMenu:
                    ColorMenu();
                    break;

                case CurrentMenu.PauseMenu:
                    PauseMenu();
                    break;

                case CurrentMenu.DeathMenu:
                    DeathMenu();
                    break;

                case CurrentMenu.None:
                    if(Keyboard.GetState().IsKeyDown(Keys.P))
                        currentMenu = CurrentMenu.PauseMenu;

                    if (player.IsDead())
                    {
                        currentMenu = CurrentMenu.DeathMenu;
                    }
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentMenu)
            {
                case CurrentMenu.StartMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.ColorMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.PauseMenu:
                    spriteBatch.Draw(Assets.PauseScreen, new Rectangle(0, 0, 800, 480), new Color(Color.White, 1));
                    spriteBatch.DrawString(Assets.MenuFont, "Press space to continue", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.DeathMenu:
                    spriteBatch.DrawString(Assets.MenuFont, "your score is:" + Game1.HighScore.ToString(), new Vector2(100, 100), Color.Purple);

                    string[] highscores = System.IO.File.ReadAllLines("scoreFile.txt");
                    for (int i = 0; i < highscores.Length; i++)
                    {
                        spriteBatch.DrawString(Assets.MenuFont, "Highscores:" + highscores[i] + "\n", new Vector2(200, 200), Color.Purple);
                    }

                    spriteBatch.DrawString(Assets.MenuFont, "Press SPACE to restart\n Press ESCAPE to exit", new Vector2(250, 300), Color.Purple);
                    break;

                case CurrentMenu.None:
                    break;

                default:
                    break;
            }
        }

        public void StartMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }

        public void ColorMenu()
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;
        }
        public void PauseMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.None;

            //if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit
        }

        public void DeathMenu()
        {
            string hscore = Game1.HighScore.ToString();
            string[] lines = { hscore };
            lines.ToList();

            List<string> highscores = System.IO.File.ReadAllLines("scoreFile.txt").ToList();
            highscores.Sort();

            for (int i = highscores.Count; i < 3; i++)
            {
                if (highscores[0] == "" || highscores[0] == "\n")
                {
                    highscores[0] = "0";
                }
                highscores.Add("0");
            }

            System.IO.File.WriteAllLines("scoreFile.txt", highscores);

            for (int i = 0; i < highscores.Count; i++)
            {
                if (highscores[0] == "0")
                {
                    highscores[i].Replace("0", hscore);
                    System.IO.File.WriteAllLines("scoreFile.txt", highscores);
                }

                if (int.Parse(highscores[i]) < int.Parse(hscore))
                {
                    highscores[i] = hscore;
                    System.IO.File.WriteAllLines("scoreFile.txt", highscores);
                }
                else
                {
                    break;
                }
            }

            

            /*
            for (int i = 0; i < highscores.Count; i++)
            {
                if(string.IsNullOrEmpty(highscores[i]))
                {
                    System.IO.File.WriteAllLines("scoreFile.txt", lines);
                }
                else if (int.Parse(lines[0]) > int.Parse(highscores[i]))
                {
                    string temp = highscores[i];

                    System.IO.File.WriteAllLines("scoreFile.txt", lines);

                    highscores[i + 1] = temp;

                    if (highscores.Count > 1)
                    {
                        highscores[i + 2] = highscores[i + 1];
                        highscores[i + 1] = temp;
                    }
                }

            }
            */
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                currentMenu = CurrentMenu.StartMenu;

            //ESC will exit regardless
        }

    }
}
///I den här klassen kollar vi vilken meny vi är i och vad som sak ske om vi är i den menyn
///
///Startmenu visar bara en text att du kan spela om du klickar mellanslag
///
///Colormenu är inte klar men bör vara till för att välja färg på spelaren
///
///Pausemenu är som startmenu men öppnas om du klickar P tangenten och stängs med mellanslag
///
///Deathmenu är inte heller klar men ska leda till en scoreboard och öppnas när man dör. Härifrån kan du spela om eller lämna.
/// 
///
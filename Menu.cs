using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public List<string> highscores = new List<string>();

        public Menu(Player player)
        {
            this.player = player;
        }

        public void Update()
        {
            if (!File.Exists("scoreFile.txt"))
            {
                StreamWriter sw = new StreamWriter("scoreFile.txt");

                for (int i = 0; i < 3; i++)
                {
                    sw.WriteLine("0");
                }

                sw.Close();
            }

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
                    
                    spriteBatch.DrawString(Assets.MenuFont, "Highscores:" + highscores, new Vector2(140, 140), Color.Purple);

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
            
            StreamReader sr = new StreamReader("scoreFile.txt");

            string lines = sr.ReadLine();

            sr.Close();

            List<string> line = lines.Split('\n').ToList();

            for(int i = 0; i < lines.Length; i++)
            {
                highscores.Add(lines[i].ToString());
            }

            highscores.Sort();

            StreamWriter sw = new StreamWriter("scoreFile.txt");

            sw.WriteLine(highscores);

            sw.Close();

            for (int i = 0; i < highscores.Count; i++)
            {
                if (highscores[0] == "0")
                {
                    highscores[0] = hscore;

                    StreamWriter sw1 = new StreamWriter("scoreFile.txt");

                    sw1.WriteLine(highscores);

                    sw1.Close();

                    break;
                }

                if (int.Parse(highscores[i]) < int.Parse(hscore))
                {
                    if(highscores.Count < 3)
                    {
                        highscores[i + 1] = highscores[i];
                    }

                    highscores[i] = hscore;

                    StreamWriter sw2 = new StreamWriter("scoreFile.txt");

                    sw2.WriteLine(highscores);

                    sw2.Close();
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //Game1.restart = true;
                currentMenu = CurrentMenu.StartMenu;
            }

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
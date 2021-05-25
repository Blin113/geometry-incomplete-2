using System.IO;

namespace Template
{
    class Score
    {
        public Score()
        {
        }

        public string[] LoadFromFile(string scoreFile)
        {
            string[] lines = File.ReadAllLines(@scoreFile);

            return lines;
        }
        /*
        public string[] WriteToFile(string scoreFile, string temp)
        {
            LoadFromFile(scoreFile);

            string hscore = Game1.HighScore.ToString() + "\n";
            string[] lines = { hscore };

            for (int i = 0; i < lines.Length; i++)
            {
                if(int.Parse(hscore) < int.Parse(lines[i]))
                {
                    i++;
                }
                else if (int.Parse(hscore) > int.Parse(lines[i]))
                {
                    temp = lines[i];

                    File.WriteAllLines(@"./scoreFile.txt", lines);

                    lines[i + 2] = lines[i + 1];
                    lines[i + 1] = temp;
                }
            }

            return lines;
        }*/
    }
}

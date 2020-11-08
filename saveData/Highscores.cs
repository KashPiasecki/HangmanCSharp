using System.IO;

namespace Hangman.gameLogic
{
	class Highscores
    {

        private readonly string filePath = @"..\..\highscores.txt";

        public void SaveToAFile(string name, string timeStamp, int playTime, int count, string wordToFind)
        {
            TextWriter tw = new StreamWriter(filePath, true);
            tw.WriteLine(name + " \\ " + timeStamp + " \\ " + playTime + " sec \\ " + count + " tries \\ " + wordToFind);
            tw.Close();
        }
    }
}

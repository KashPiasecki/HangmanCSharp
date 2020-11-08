using Hangman.bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.gameLogic
{
    public class Logic
	{

		List<string> capitals;
		List<string> countries;

		Highscores highscores = new Highscores();

		private readonly int VALUE_TO_LOSE = 0;
		private bool guessWholeWord;
		private string country;
		private int lives;
		private int playTime;
	
		private readonly Random random = new Random();
		private string wordToFind;
		private bool guessedRight;

		private char[] wordToFindHidden;

		private int count;

		private readonly List<string> lettersGuessed = new List<string>();
		private readonly List<string> notInAList = new List<string>();
		TimeCounter timeCounter;

		public void dataFrom()
		{
			Console.WriteLine("Enter \"1\" for European capitals");
			Console.WriteLine("Enter \"2\" for capitals from around the world");
			string dataLoad = Console.ReadLine();
			switch (dataLoad)
			{
				case "1":
					BootstrapData bootstrapData = new BootstrapData();
					capitals = bootstrapData.loadCapitals();
					countries = bootstrapData.loadCountries();
					break;
				case "2":
					FileDataLoader loadFromFile = new FileDataLoader();
					loadFromFile.readFile();
					capitals = loadFromFile.loadCapitals();
					countries = loadFromFile.loadCountries();
					break;
				default:
					Console.WriteLine("Wrong input");
					dataFrom();
					break;
			}
		}

		public void Start()
		{
			dataFrom();
			lives = 5;
			lettersGuessed.Clear();
			guessedRight = false;
			notInAList.Clear();
			count = 0;
			guessWholeWord = false;
			playTime = 0;
			timeCounter = new TimeCounter();
			int randomNumber = random.Next(capitals.Count);
			wordToFind = capitals[randomNumber];
			country = firstLetterUppercase(countries[randomNumber]);
			wordToFindHidden = new char[wordToFind.Length];
			Console.WriteLine("Lives: " + lives);
			fillWithUnderscores();
			game();
			goAgain();
		}

		private void fillWithUnderscores()
		{
			//Arrays.fill(wordToFindHidden, '_');
			wordToFindHidden = Enumerable.Repeat('_', wordToFindHidden.Length).ToArray();
		}

		private StringBuilder printWord()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < wordToFindHidden.Length; i++)
			{
				stringBuilder.Append(wordToFindHidden[i]);
				if (i < wordToFindHidden.Length - 1)
				{
					stringBuilder.Append(" ");
				}
			}
			return stringBuilder;
		}

		private bool wordGuessed()
		{
			return wordToFind.Equals(new string(wordToFindHidden));
		}

		private void enterChar(string c)
		{
			if (!lettersGuessed.Contains(c))
			{
				if (wordToFind.Contains(c))
				{
					int index = wordToFind.IndexOf(c);
					while (index >= 0)
					{
						wordToFindHidden[index] = c[0];
						//Looking if there are more letters in the word
						index = wordToFind.IndexOf(c, index + 1);
					}
				}
				else
				{
					notInAList.Add(c);
					lives--;
					printHangMan();
				}
				lettersGuessed.Add(c);
				count++;
			}
		}


		private void game()
		{
			while (lives > VALUE_TO_LOSE && !wordGuessed())
			{
				Console.WriteLine(printWord());
				Console.WriteLine("Would you like to guess a letter or the whole word? \"l\" - letter \"w\" - word");
				string wordOrLetter = Console.ReadLine();
				switch (wordOrLetter)
				{
					case "l":
						guessLetter();
						break;
					case "w":
					guessingWord();
						break;
					default:
						Console.WriteLine("Wrong input");
						break;
				}
			}
		}

		private void guessLetter()
		{
			Console.Write("Guess a letter: ");
			string input = Console.ReadLine();
			if (input.Length != 1)
			{
				Console.WriteLine("Not a single char");
			}
			else
			{
				enterChar(input.ToLower());
				Console.WriteLine(printWord());
				if (wordGuessed())
				{
					won();
				}
				else
				{
					if (lives == 1)
					{
						Console.WriteLine("The capital of " + country + ".");
					}
					else if (lives <= VALUE_TO_LOSE)
					{
						lost();
					}
					else
					{
						Console.WriteLine("Lives left: " + lives);
						Console.Write("Not in a word: ");
						notInAList.ForEach(item => Console.Write(item + ", "));
						Console.WriteLine();

					}
				}
			}
		}

		private void guessingWord()
		{
			Console.Write("Type a word: ");
			string word = Console.ReadLine();
			if (word.ToLower().Equals(wordToFind))
			{
				guessWholeWord = true;
				won();
			}
			else
			{
				lives -= 2;
				if (lives <= 0)
				{
					printHangMan();
					Console.WriteLine("Lives left: " + VALUE_TO_LOSE);
				}
				else
				{
					printHangMan();
					Console.WriteLine("Lives left: " + lives);
				}
			}
			if (lives == 1)
			{
				Console.WriteLine("The capital of " + country + ".");
			}
			if (lives <= VALUE_TO_LOSE)
			{
				lost();
			}
		}

		private void won()
		{
			guessedRight = true;
			Console.WriteLine("Congratulations, you win!");
			Console.WriteLine("Capital city of " + country + " is " + firstLetterUppercase(wordToFind));
			savePlayTime();
			saveHighScore();
		}

		private void lost()
		{
			Console.WriteLine("You get nothing. You lose. Good day sir.");
			savePlayTime();
		}

		private void goAgain()
		{
			Console.WriteLine("Enter \"0\" to start again, \"q\" to quit.");
			try
			{
				int input = Int32.Parse(Console.ReadLine());
				if (input == 0)
				{
					Start();
				}
				else
				{
					exit();
				}
			}
			catch (Exception e)
			{
				exit();
			}
		}

		private void saveHighScore()
		{
			Console.Write("What is you name? ");
			string name = Console.ReadLine();
			name = firstLetterUppercase(name).Trim();
			string timeStamp = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
			highscores.SaveToAFile(name, timeStamp, playTime, count, firstLetterUppercase(wordToFind));
			goAgain();
		}

		private String firstLetterUppercase(String s)
		{
			return s.Substring(0, 1).ToUpper() + s.Substring(1);
		}

		private void printHangMan()
		{
			string hangman = "";
			switch (lives)
			{
				case 5:
					hangman = "\n" + "\n|" + "\n|" + "\n|" + "\n|" + "\n|" + "\n|_______________________\n";
					break;
				case 4:
					hangman = "\n_________" + "\n|       |" + "\n|" + "\n|" + "\n|" + "\n|" + "\n|_______________________\n";
					break;
				case 3:
					hangman = "\n_________" + "\n|       |" + "\n|       O" + "\n|       |" + "\n|" + "\n|" + "\n|_______________________\n";
					break;
				case 2:
					hangman = "\n_________" + "\n|       |" + "\n|       O" + "\n|    ---|" + "\n|" + "\n|" + "\n|_______________________\n";
					break;
				case 1:
					hangman = "\n_________" + "\n|       |" + "\n|       O" + "\n|    ---|---" + "\n|" + "\n|" + "\n|_______________________\n";
					break;
				case 0:
					hangman = "\n_________" + "\n|        |" + "\n|       O" + "\n|    ---|---" + "\n|       /" + "\n|       /" + "\n|_______________________\n";
					break;
				default:
					hangman = "";
					break;
			};
			Console.WriteLine(hangman);
		}

		private void savePlayTime()
		{
			this.playTime = timeCounter.GetAgeInSeconds();
			if (guessedRight)
			{
				if (guessWholeWord)
				{
					int EXTRA_TIME_FOR_GUESSING_WORD = 10;
					playTime -= EXTRA_TIME_FOR_GUESSING_WORD;
					if (playTime < 0)
					{
						playTime = 0;
					}
				}
				Console.WriteLine("Guessed after: " + count + " letters. Spent: " + playTime + " seconds.");
			}
			else
			{
				Console.WriteLine("Spent: " + playTime + " seconds.");
			}
		}

		private void exit()
		{
			Environment.Exit(0);
		}

	}


}

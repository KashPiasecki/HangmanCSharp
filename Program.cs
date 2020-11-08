using Hangman.gameLogic;

namespace Hangman
{
	class Program
	{
		static void Main(string[] args)
		{
			var hangmanLogic = new Logic();
			hangmanLogic.Start();
		}
	}
}

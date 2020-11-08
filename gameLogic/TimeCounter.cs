using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.gameLogic
{
	public class TimeCounter
	{
		private readonly DateTime _createdDate = DateTime.Now;


		public int GetAgeInSeconds()
		{
			return (int)(DateTime.Now - _createdDate).TotalSeconds;
		}
	}
}

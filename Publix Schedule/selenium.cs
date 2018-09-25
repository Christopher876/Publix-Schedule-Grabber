using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text;
namespace WebDriver_basics
{
	public class PublixScheduleWebsite
	{
		private StringBuilder workWeek = new StringBuilder();
		private string username;
		private string password;

		public void FetchLogInInfo()
		{
			using(StreamReader logIn = new StreamReader(@"logInfo.txt"))
			{
				var line = logIn.ReadLine();
				string[] words = line.Split();

				foreach(string word in words)
				{
					if(word == "username")
					{
						username = words[2];
					}
				}

				line = logIn.ReadLine();
				words = line.Split();
				foreach (string word in words)
				{
					if (word == "password")
					{
						password = words[2];
						//Console.Read();
					}
				}
			}
		}

		public void FetchCurrentWorkWeek()
		{
			DateTime thisweek = DateTime.Now;
			DateTime findSaturday = new DateTime();

			for(int i = 0; i < 7; i++)
			{
				if (thisweek.DayOfWeek == DayOfWeek.Saturday)
				{
					//Console.WriteLine(thisweek.Date);
					break;
				}

				else if(findSaturday.DayOfWeek == DayOfWeek.Saturday)
				{
					Console.WriteLine(findSaturday.Date);
					if(findSaturday.Date.Month < 10)
					{
						workWeek.Append('0');
					}

					foreach(char c in findSaturday.Date.ToString())
					{
						if (c == '/')
						{
							workWeek.Append('-');
							continue;
						}

						if (c == ' ')
							break;
						workWeek.Append(c);
					}
					break;
				}

				else {
					findSaturday = thisweek.AddDays(i);
				}
			}
		}

		public void Access_publix_passport()
		{
			ChromeOptions option = new ChromeOptions();
			option.AddArgument("--headless");
			IWebDriver browser = new ChromeDriver(option);
			browser.Navigate().GoToUrl("https://passport-sso.publix.org/PASSPortMobile");

			IWebElement userNameBox = browser.FindElement(By.Id("userNameInput"));
			IWebElement passwordBox = browser.FindElement(By.Id("passwordInput"));

			//Console.WriteLine("Press enter to enter login info");
			//Console.ReadLine();
			userNameBox.Clear();
			userNameBox.SendKeys(username);
			passwordBox.Clear();
			passwordBox.SendKeys(password);
			browser.FindElement(By.Id("submitButton")).Click();

			browser.Navigate().GoToUrl("https://passport-sso.publix.org/PASSPortMobile/Schedule/Schedule/" + workWeek);
			var browserSource = browser.PageSource;

			using(StreamWriter File = new StreamWriter("schedule.html"))
			{
				File.Write(browserSource);
			};

			browser.Close();
		}
	}
}

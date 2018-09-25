using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using WebDriver_basics;
using GoogleDrive;
using System.Linq;

namespace Publix_Schedule
{
	public class CookieAwareWebClient : WebClient
	{
		private CookieContainer cookie = new CookieContainer();

		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest request = base.GetWebRequest(address);
			if (request is HttpWebRequest)
			{
				(request as HttpWebRequest).CookieContainer = cookie;
			}
			return request;
		}
	}

	class Program
	{
		public static StringBuilder sat_date = new StringBuilder();
		public static StringBuilder sat_time = new StringBuilder();

		public static StringBuilder sun_date = new StringBuilder();
		public static StringBuilder sun_time = new StringBuilder();

		public static StringBuilder mon_date = new StringBuilder();
		public static StringBuilder mon_time = new StringBuilder();

		public static StringBuilder tue_date = new StringBuilder();
		public static StringBuilder tue_time = new StringBuilder();

		public static StringBuilder wed_date = new StringBuilder();
		public static StringBuilder wed_time = new StringBuilder();

		public static StringBuilder thu_date = new StringBuilder();
		public static StringBuilder thu_time = new StringBuilder();

		public static StringBuilder fri_date = new StringBuilder();
		public static StringBuilder fri_time = new StringBuilder();

		public static StringBuilder[] start = new StringBuilder[15];
		public static StringBuilder[] end = new StringBuilder[15];

		public static StringBuilder[] hoursTillEnd = new StringBuilder[15];
		public static StringBuilder[] hoursStart = new StringBuilder[15];
		public static int[] hoursInStart = new int[15];
		public static int[] hoursInEnd = new int[15];

		public class Dates
		{
			public List<String>days = new List<string>();
			public List<string>times = new List<string>();
			public List<string>formattedTimes = new List<string>();
		}

		public class TimeAsInt
		{
			public int [] firstHour = new int[3];
			public int [] secondHour = new int [3];
			public int [] firstMinute = new int [3];
			public int [] secondMinute = new int[3];
		}

		public static void ExtractDays()
		{
			using (StreamReader File = new StreamReader("schedule.html"))
			{
				while (File.Peek() >= 0)
				{
					string line = File.ReadLine();
					string[] words = line.Split();
					foreach (string word in words)
					{
						if (word == "Sat</div>")
						{
							//get to date
							line = File.ReadLine();
							line = File.ReadLine();
							line = line.Trim();

							//Get date
							foreach (char c in line)
							{
								char d = c;
								if (c == '<')
								{
									break;
								}
								sat_date.Append(d);
								
							}
							//Console.WriteLine(sat_date);
							

							//get to time
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							
							

							line = line.Trim();
							bool found = false;
							foreach (char d in line)
							{
								if (d == '>' && found == false)
								{
									found = true;
								}

								if (d == '<' && found == true)
								{
									break;
								}

								else if (found && d != '>')
								{
									sat_time.Append(d);
								}

							}
							//Console.WriteLine(sat_time);
						}

						if (word == "Sun</div>")
						{
							////Console.WriteLine("Found it");
							////Console.Readline();

							//get to date
							line = File.ReadLine();
							line = File.ReadLine();
							line = line.Trim();

							////Console.WriteLine(line);
							//Get date
							foreach (char c in line)
							{
								char d = c;
								if (c == '<')
								{
									break;
								}
								sun_date.Append(d);
							}
							//Console.WriteLine(sun_date);
							////Console.Readline();

							//get to time
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							////Console.WriteLine(line);
							////Console.Readline();

							line = line.Trim();
							bool found = false;
							foreach (char d in line)
							{
								if (d == '>' && found == false)
								{
									////Console.WriteLine("Found schedule time");
									////Console.Readline();
									found = true;
								}

								if (d == '<' && found == true)
								{
									break;
								}

								else if (found && d != '>')
								{
									sun_time.Append(d);
								}

							}
							//Console.WriteLine(sun_time);
							////Console.Readline();
						}

						if (word == "Mon</div>")
						{
							////Console.WriteLine("Found it");
							////Console.Readline();

							//get to date
							line = File.ReadLine();
							line = File.ReadLine();
							line = line.Trim();

							////Console.WriteLine(line);
							//Get date
							foreach (char c in line)
							{
								char d = c;
								if (c == '<')
								{
									break;
								}
								mon_date.Append(d);
							}
							//Console.WriteLine(mon_date);
							////Console.Readline();

							//get to time
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							////Console.WriteLine(line);
							////Console.Readline();

							line = line.Trim();
							bool found = false;
							foreach (char d in line)
							{
								if (d == '>' && found == false)
								{
									////Console.WriteLine("Found schedule time");
									////Console.Readline();
									found = true;
								}

								if (d == '<' && found == true)
								{
									break;
								}

								else if (found && d != '>')
								{
									mon_time.Append(d);
								}

							}
							//Console.WriteLine(mon_time);
							////Console.Readline();
						}

						if (word == "Tue</div>")
						{
							////Console.WriteLine("Found it");
							////Console.Readline();

							//get to date
							line = File.ReadLine();
							line = File.ReadLine();
							line = line.Trim();

							////Console.WriteLine(line);
							//Get date
							foreach (char c in line)
							{
								char d = c;
								if (c == '<')
								{
									break;
								}
								tue_date.Append(d);
							}
							//Console.WriteLine(tue_date);
							////Console.Readline();

							//get to time
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							////Console.WriteLine(line);
							////Console.Readline();

							line = line.Trim();
							bool found = false;
							foreach (char d in line)
							{
								if (d == '>' && found == false)
								{
									////Console.WriteLine("Found schedule time");
									////Console.Readline();
									found = true;
								}

								if (d == '<' && found == true)
								{
									break;
								}

								else if (found && d != '>')
								{
									tue_time.Append(d);
								}

							}
							//Console.WriteLine(tue_time);
							////Console.Readline();
						}

						if (word == "Wed</div>")
						{
							////Console.WriteLine("Found it");
							////Console.Readline();

							//get to date
							line = File.ReadLine();
							line = File.ReadLine();
							line = line.Trim();

							////Console.WriteLine(line);
							//Get date
							foreach (char c in line)
							{
								char d = c;
								if (c == '<')
								{
									break;
								}
								wed_date.Append(d);
							}
							//Console.WriteLine(wed_date);
							////Console.Readline();

							//get to time
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							////Console.WriteLine(line);
							////Console.Readline();

							line = line.Trim();
							bool found = false;
							foreach(char d in line)
							{
								if(d == '>' && found == false)
								{
									////Console.WriteLine("Found schedule time");
									////Console.Readline();
									found = true;
								}

								if(d == '<' && found == true)
								{
									break;
								}

								else if (found && d != '>')
								{
									wed_time.Append(d);
								}
												
							}
							//Console.WriteLine(wed_time);
							////Console.Readline();
						}

						if (word == "Thu</div>")
						{
							////Console.WriteLine("Found it");
							////Console.Readline();

							//get to date
							line = File.ReadLine();
							line = File.ReadLine();
							line = line.Trim();

							////Console.WriteLine(line);
							//Get date
							foreach (char c in line)
							{
								char d = c;
								if (c == '<')
								{
									break;
								}
								thu_date.Append(d);
							}
							//Console.WriteLine(thu_date);
							////Console.Readline();

							//get to time
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							////Console.WriteLine(line);
							////Console.Readline();

							line = line.Trim();
							bool found = false;
							foreach (char d in line)
							{
								if (d == '>' && found == false)
								{
									////Console.WriteLine("Found schedule time");
									////Console.Readline();
									found = true;
								}

								if (d == '<' && found == true)
								{
									break;
								}

								else if (found && d != '>')
								{
									thu_time.Append(d);
								}

							}
							//Console.WriteLine(thu_time);
							////Console.Readline();
						}

						if (word == "Fri</div>")
						{
							////Console.WriteLine("Found it");
							////Console.Readline();

							//get to date
							line = File.ReadLine();
							line = File.ReadLine();
							line = line.Trim();

							////Console.WriteLine(line);
							//Get date
							foreach (char c in line)
							{
								char d = c;
								if (c == '<')
								{
									break;
								}
								fri_date.Append(d);
							}
							//Console.WriteLine(fri_date);
							////Console.Readline();

							//get to time
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							line = File.ReadLine();
							////Console.WriteLine(line);
							////Console.Readline();

							line = line.Trim();
							bool found = false;
							foreach (char d in line)
							{
								if (d == '>' && found == false)
								{
									////Console.WriteLine("Found schedule time");
									////Console.Readline();
									found = true;
								}

								if (d == '<' && found == true)
								{
									break;
								}

								else if (found && d != '>')
								{
									fri_time.Append(d);
								}

							}
							//Console.WriteLine(fri_time);
							////Console.Readline();
						}
					}
				}
			}
		}
			
		public static void PrepareDays(Dates dateTime)
		{
			DateTime now = DateTime.Now;
			var currentYear = now.Year;

			dateTime.days.Add(currentYear.ToString() + "/" + sat_date.ToString());
			dateTime.times.Add(sat_time.ToString());
			dateTime.days.Add(currentYear.ToString() + "/" + sun_date.ToString());
			dateTime.times.Add(sun_time.ToString());
			dateTime.days.Add(currentYear.ToString() + "/" + mon_date.ToString());
			dateTime.times.Add(mon_time.ToString());
			dateTime.days.Add(currentYear.ToString() + "/" + tue_date.ToString());
			dateTime.times.Add(tue_time.ToString());
			dateTime.days.Add(currentYear.ToString() + "/" + wed_date.ToString());
			dateTime.times.Add(wed_time.ToString());
			dateTime.days.Add(currentYear.ToString() + "/" + thu_date.ToString());
			dateTime.times.Add(thu_time.ToString());
			dateTime.days.Add(currentYear.ToString() + "/" + fri_date.ToString());
			dateTime.times.Add(fri_time.ToString());
		}

		//DateTime = year,month,day,hour,minute,seconds

		static void PrepareTime(Dates dateTime, TimeAsInt time)
		{
			StringBuilder fixedTimes = new StringBuilder();

			int j = 0;
			int k = 0;

			for (int i=0;i<dateTime.times.Count();i++)
			{
				start[j] = new StringBuilder();
				end[j] = new StringBuilder();
				bool phase1 = true;
				foreach(char c in dateTime.times[i])
				{
					if (dateTime.times[i] == "Not Scheduled")
					{
						start[j].Append("P");
						//Console.WriteLine(dateTime.times[i]);
						////Console.Readline();
						continue;
					}

					if(c == '-')
					{
						phase1 = false;
						continue;
					}
					if(c == ' ')
					{
						continue;
					}

					if (phase1)
						start[j].Append(c);
					if (!phase1)
						end[j].Append(c);
					k++;
				}
				try
				{
					end[j].Remove(1, 0);
				}
				catch
				{
					
				}

				//Console.WriteLine(start[j] + "," + end[j]);
				j++;
					
			}

				////Console.Readline();

		}

		static void GetTime(Dates dateTime)
		{
			int add1;
			int add2;
			for (int i = 0; i < start.Length; i++)
			{
				hoursStart[i] = new StringBuilder();
				hoursTillEnd[i] = new StringBuilder();

				try
				{
					foreach (char c in start[i].ToString())
					{
						if(c == 'P')
						{
							hoursStart[i].Append('P');
							//Console.WriteLine(hoursStart);
							////Console.Readline();
							continue;
						}
						if (c == ':')
							break;
						hoursStart[i].Append(c);
					}

					foreach (char c in end[i].ToString())
					{
						if (c == 'N')
						{
							//Console.WriteLine(end[i]);
							////Console.Readline();
							continue;
						}
						if (c == ':')
							break;
						hoursTillEnd[i].Append(c);
					}

					add1 = Int32.Parse(hoursStart[i].ToString());
					add2 = Int32.Parse(hoursTillEnd[i].ToString());
					hoursInEnd[i] = add2 - add1;
					if(hoursInEnd[i] <= 0)
					{
						hoursInEnd[i] = hoursInEnd[i] + 12;
					}
				}

				catch
				{
					//Console.WriteLine("Nothing else");
					//dateTime.days[i] = null;
				}
			}
			////Console.Readline();
		}

		static void Main(string[] args)
		{
			var publix_website = new PublixScheduleWebsite();
			publix_website.FetchLogInInfo();
			publix_website.FetchCurrentWorkWeek();
			publix_website.Access_publix_passport();
			Dates dateTime = new Dates();
			TimeAsInt time = new TimeAsInt();
			ExtractDays();
			PrepareDays(dateTime);
			PrepareTime(dateTime,time);
			GetTime(dateTime);
			var googleDrive = new googleDrive();
			googleDrive.modifyCalendar(dateTime);
			Console.WriteLine("Job Successful!");
			Environment.ExitCode = 1;
			Environment.Exit(1);
		}
	}
}

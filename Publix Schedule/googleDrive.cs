using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Publix_Schedule;
using static Publix_Schedule.Program;

namespace GoogleDrive
{
	class googleDrive
	{
		static string[] Scopes = { CalendarService.Scope.Calendar };
		static string ApplicationName = "Add Publix Work Days to Calendar";

		public static void modifyCalendar(Dates date)
		{
			UserCredential credential;

			using (var stream =
				new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
			{
				string credPath = "token.json";
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Scopes,
					"admin",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
				Console.WriteLine("Credential file saved to: " + credPath);
			}

			// Create Google Calendar API service.
			var service = new CalendarService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,
			});

			for (int i = 0; i < start.Length; i++)
			{
				try
				{
					DateTime workDate = Convert.ToDateTime(date.days[i]);
					DateTime workPeriod = Convert.ToDateTime(Program.start[i].ToString());
					DateTime custom = workDate.Date + workPeriod.TimeOfDay;

					Event workTime = new Event()
					{
						Summary = "Publix",
						Location = "2895 N Military Trl, West Palm Beach, FL 33409",
						Start = new EventDateTime { DateTime = custom },
						End = new EventDateTime { DateTime = custom + TimeSpan.FromHours(Program.hoursInEnd[i]) },
					};
					String calendarId = "primary";
					var insert = service.Events.Insert(workTime, calendarId).Execute();
				}
				catch
				{
					continue;
				}
			}

		}
	}
}

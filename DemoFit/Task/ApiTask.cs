using DemoFit.Interface;
using DemoFit.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoFit;

namespace DemoFit.Task
{
    public class ApiTask
    {
		
		public static async Task<List<User>> GetUserListAsync()
		{
			List<User> userlist = new List<User>();

			var myAPI = RestService.For<IMyAPI>(Settings.targetHostAddress);

			await myAPI.GetUserList().ContinueWith(ret =>
			{
				if (ret.IsCompleted == true
				 && ret.Status == TaskStatus.RanToCompletion)
				{
					userlist = ret.Result;
				}
			});

			return userlist;
		}

		//public static async Task<User> GetUserWIdAsync(int id)
		//{
		//	User user = new User();

		//	var myAPI = RestService.For<IMyAPI>(Settings.targetHostAddress);

		//	await myAPI.GetUserWId(id).ContinueWith(ret =>
		//	{
		//		if (ret.IsCompleted == true
		//		 && ret.Status == TaskStatus.RanToCompletion)
		//		{
		//			user = ret.Result;
		//			Console.WriteLine("result: " + ret.Result);
		//		}
		//		if (ret.Status == TaskStatus.Faulted)
		//		{
		//			user = null;
		//		}
		//	});

		//	return user;
		//}

		public static async Task<User> GetUserWNameAsync(string username)
		{
			User user = new User();

			var myAPI = RestService.For<IMyAPI>(Settings.targetHostAddress);

			await myAPI.GetUserWName(username).ContinueWith(ret =>
			{
				if (ret.IsCompleted == true
				 && ret.Status == TaskStatus.RanToCompletion)
				{
					user = ret.Result;
				}
				if(ret.Status== TaskStatus.Faulted) {
					user = null;
				}
			
			});

			return user;
		}

	
	}
}

using DemoFit.Model;
using DemoFit.Task;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace DemoFit.Data
{
	public class UserData
	{
		ApiTask apiTask = new ApiTask();
		public ObservableCollection<User> Users { get; private set; }
		public UserData()
		{
			Users = new ObservableCollection<User>();
			GetUsersAsync();
		}

		private async void GetUsersAsync()
		{
			List<User> user_list = await apiTask.GetUserListAsync();
			foreach (User user in user_list)
			{
				Users.Add(user);
				Console.WriteLine("" + user.Id);
				Debug.WriteLine("" + user.Id);
			}

		}


	}
}
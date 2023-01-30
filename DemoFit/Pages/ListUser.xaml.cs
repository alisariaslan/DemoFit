
using DemoFit.Model;
using DemoFit.Task;
using DevExpress.Maui.DataGrid;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace DemoFit.Pages;

public partial class ListUser : ContentPage
{
	public ListUser()
	{
		InitializeComponent();
	}

	private void datagridview_Tap(object sender, DataGridGestureEventArgs e)
	{
		if (e.Item != null)
		{
			var editForm = new EditFormPage(datagridview, datagridview.GetRowItem(e.RowHandle));
			Navigation.PushAsync(editForm);
		}
	}
}

public class UserData
{
	ApiTask apiTask = new ApiTask();
	private async void GetUsersAsync()
	{
		List<User> user_list = await apiTask.GetUserListAsync();
		foreach (User user in user_list)
		{
			Users.Add(user);
			Console.WriteLine(""+user.Id);
			Debug.WriteLine(""+user.Id);
		}

	}

	public ObservableCollection<User> Users { get; private set; }

	public UserData()
	{
		Users = new ObservableCollection<User>();
		GetUsersAsync();
	}
}

public class UserDataViewModel : INotifyPropertyChanged
{
	readonly UserData data;

	public event PropertyChangedEventHandler PropertyChanged;
	public IReadOnlyList<User> AllUser { get => data.Users; }

	public UserDataViewModel()
	{
		data = new UserData();
	}

	protected void RaisePropertyChanged(string name)
	{
		if (PropertyChanged != null)
			PropertyChanged(this, new PropertyChangedEventArgs(name));
	}
}
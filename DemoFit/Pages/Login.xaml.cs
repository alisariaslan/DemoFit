using DemoFit.Model;
using DemoFit.Task;
using System.Diagnostics;

namespace DemoFit.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
		
		if (DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
			contentpage_login.BackgroundImageSource = "login_background_win.jpg";
		else if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
			contentpage_login.BackgroundImageSource = "login_background_phone.jpg";

		frame_loginbackground.FadeTo(.95, 5000);
	}

	private void button_login_Clicked(object sender, EventArgs e)
	{
		if (editor_username.Text == null || editor_password.Text == null)
			return;
		log_in();
	}

	private async void log_in()
	{
		string username = editor_username.Text.Trim();
		string pass = editor_password.Text.Trim();
		if (username.Equals(null) || pass.Equals(null))
			return;

		User user = await ApiTask.GetUserWNameAsync(username);
		if (user != null)
		{
			Debug.WriteLine("Kullanýcý bulundu ->" + user.Username);
			if(username.Equals(user.Username) && pass.Equals(user.Password))
			{
				Debug.WriteLine("Login baþarýlý");
				//await Navigation.PushAsync(new MainPage());
				App.Current.MainPage = new NavigationPage(new AdminMenu());
			} else Debug.WriteLine("Hatalý bilgiler!");
		}
		else
		{
			Debug.WriteLine("Kullanýcý bulunamadý!");
		}
	}


}

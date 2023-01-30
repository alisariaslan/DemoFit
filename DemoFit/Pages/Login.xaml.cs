using DemoFit.Model;
using DemoFit.Task;
using System.Diagnostics;

namespace DemoFit.Pages;

public partial class Login : ContentPage
{
	ApiTask apiTask=new ApiTask();
	public Login()
	{
		InitializeComponent();
		
		if (DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
			contentpage_login.BackgroundImageSource = "login_background_win.jpg";
		else if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
			contentpage_login.BackgroundImageSource = "login_background_phone.jpg";

		frame_loginbackground.FadeTo(.95, 5000);

		editor_username.Text = Microsoft.Maui.Storage.Preferences.Get("remember_username", "");
		editor_password.Text = Microsoft.Maui.Storage.Preferences.Get("remember_password", "");
		if (!editor_username.Text.Equals(""))
			checkbox_remember_username.IsChecked = true;
		if(!editor_password.Text.Equals(""))
			checkbox_remember_pass.IsChecked = true;
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

		User user = await apiTask.GetUserWNameAsync(username);
		if (user != null)
		{
			Debug.WriteLine("Kullanýcý bulundu ->" + user.Username);
			if(username.Equals(user.Username) && pass.Equals(user.Password))
			{
				Debug.WriteLine("Login baþarýlý");
				//await Navigation.PushAsync(new MainPage());

				if (checkbox_remember_username.IsChecked)
					Microsoft.Maui.Storage.Preferences.Set("remember_username", editor_username.Text);
				if(checkbox_remember_pass.IsChecked)
					Microsoft.Maui.Storage.Preferences.Set("remember_password", editor_password.Text);

				App.Current.MainPage = new NavigationPage(new AdminMenu());
			} else
			{
				popup_label.Text = "Hata -> DATA NOT EQUAL";
				popup.IsOpen = true;
			}
		}
		else
		{
			popup_label.Text = "Hata -> DATA NULL";
			popup.IsOpen = true;
		}
	}

	private void checkbox_remember_username_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if(!e.Value)
		Microsoft.Maui.Storage.Preferences.Set("remember_username", "");
	}

	private void checkbox_remember_pass_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if(!e.Value)
		Microsoft.Maui.Storage.Preferences.Set("remember_password", "");
	}
}

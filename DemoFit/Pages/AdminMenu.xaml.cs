namespace DemoFit.Pages;

public partial class AdminMenu : ContentPage
{
	public AdminMenu()
	{
		InitializeComponent();

		if (DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
			contentpage_admin.BackgroundImageSource = "login_background_win.jpg";
		else if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
			contentpage_admin.BackgroundImageSource = "login_background_phone.jpg";
	}

	private void ImageButton_Pressed(object sender, EventArgs e)
	{
		imagebutton_userlist.ScaleTo(1.1, 100);
		label_userlist.ScaleTo(1.1, 100);
	}

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage());
	}

	private void ImageButton_Released(object sender, EventArgs e)
	{
		imagebutton_userlist.ScaleTo(1, 100);
		label_userlist.ScaleTo(1, 100);
	}

	private void ImageButton_Exit_Pressed(object sender, EventArgs e)
	{
		imagebutton_exit.ScaleTo(1.1, 100);
		label_exit.ScaleTo(1.1, 100);
	}

	private void ImageButton_Exit_Clicked(object sender, EventArgs e)
	{
		App.Current.MainPage = new NavigationPage(new Login());
	}

	private void ImageButton_Exit_Released(object sender, EventArgs e)
	{
		imagebutton_exit.ScaleTo(1, 100);
		label_exit.ScaleTo(1, 100);
	}
}
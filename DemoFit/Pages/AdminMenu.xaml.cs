using AndroidX.Lifecycle;
using DemoFit.Data;
using DemoFit.Task;

namespace DemoFit.Pages;

public partial class AdminMenu : ContentPage
{
	ApiTask apiTask = new ApiTask();

	public AdminMenu()
	{
		InitializeComponent();

		if (DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
			contentpage_admin.BackgroundImageSource = "login_background_win.jpg";
		else if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
			contentpage_admin.BackgroundImageSource = "login_background_phone.jpg";

		Load();
	}

	public async void Load()
	{
		ProductViewModel.FakeProducts = await apiTask.GetProductListAsync();
	}

	private void ImageButton_Pressed(object sender, EventArgs e)
	{
		imagebutton_userlist.ScaleTo(1.1, 100);
		label_userlist.ScaleTo(1.1, 100);
	}

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ListUser());
	}

	private void ImageButton_Released(object sender, EventArgs e)
	{
		imagebutton_userlist.ScaleTo(1, 100);
		label_userlist.ScaleTo(1, 100);
	}





	private void ImageButton_productlist_Pressed(object sender, EventArgs e)
	{
		imagebutton_productlist.ScaleTo(1.1, 100);
		label_productlist.ScaleTo(1.1, 100);
	}

	private void ImageButton_productlist_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ListProduct());
	}

	private void ImageButton_productlist_Released(object sender, EventArgs e)
	{
		imagebutton_productlist.ScaleTo(1, 100);
		label_productlist.ScaleTo(1, 100);
	}




	private void ImageButton_productstatics_Pressed(object sender, EventArgs e)
	{
		imagebutton_productstatics.ScaleTo(1.1, 100);
		label_productstatics.ScaleTo(1.1, 100);
	}

	private void ImageButton_productstatics_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ProductStatics());
	}

	private void ImageButton_productstatics_Released(object sender, EventArgs e)
	{
		imagebutton_productstatics.ScaleTo(1, 100);
		label_productstatics.ScaleTo(1, 100);
	}



	private void ImageButton_seller_Pressed(object sender, EventArgs e)
	{
		imagebutton_seller.ScaleTo(1.1, 100);
		label_seller.ScaleTo(1.1, 100);
	}

	private void ImageButton_seller_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new SellerPage());
	}

	private void ImageButton_seller_Released(object sender, EventArgs e)
	{
		imagebutton_seller.ScaleTo(1, 100);
		label_seller.ScaleTo(1, 100);
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
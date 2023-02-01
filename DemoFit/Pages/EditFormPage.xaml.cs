using DemoFit.Model;
using DemoFit.Task;
using DemoFit.Tools;
using DemoFit.View;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui.Platform;

namespace DemoFit.Pages;
public partial class EditFormPage : ContentPage
{
	private User user;
	ApiTask apiTask = new ApiTask();

	public EditFormPage(DataGridView dataGridView,object rowData)
	{
		InitializeComponent();
		this.user = (User) rowData;
		entry_edit_username.Text = user.Username;
		entry_edit_password.Text = user.Password;
	}

	private void button_edit_save_Clicked(object sender, EventArgs e)
	{
		string username = entry_edit_username.Text.Trim();
		string password = entry_edit_password.Text.Trim();
		if (username.Equals("") || password.Equals(""))
			Pop.Up(popup,popup_label,"Alanlar boþ olamaz!");
		else
		{
				user.Username = username;
				user.Password = password;
				SaveAsync(user);
		}
	}

	private async void SaveAsync(User user)
	{
		bool result = await apiTask.UpdateUser(user);
		if (result)
		{
			Pop.Up(popup, popup_label, "Güncelleme baþarýlý.\nLütfen önceki sayfayý yenileyin");
			Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
		}
		else
			Pop.Up(popup, popup_label, "Güncelleme baþarýsýz!");
	}
}


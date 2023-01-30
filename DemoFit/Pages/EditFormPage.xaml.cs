using DemoFit.Model;
using DevExpress.Maui.DataGrid;

namespace DemoFit.Pages;


public partial class EditFormPage : ContentPage
{
	private User user;
	public EditFormPage(DataGridView dataGridView,object rowData)
	{
		InitializeComponent();
		this.user = (User) rowData;

		Console.WriteLine(user.Username);
	}
}



	

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

	private void datagridview_PullToRefresh(object sender, EventArgs e)
	{

	}
}


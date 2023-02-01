using DemoFit.Data;
using DemoFit.Model;
using DemoFit.Task;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoFit.View
{
	public class UserDataViewModel: INotifyPropertyChanged
	{
		ObservableCollection<User> productCategories;
		public event PropertyChangedEventHandler PropertyChanged;
		bool isRefreshing = false;
		UserData data;

		public UserDataViewModel()
		{
			this.data = new UserData();
			ProductCategories = data.Users;
			PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
		}
		
		public bool IsRefreshing
		{
			get { return isRefreshing; }
			set
			{
				if (isRefreshing != value)
				{
					isRefreshing = value;
					OnPropertyChanged("IsRefreshing");
				}
			}
		}

		public ObservableCollection<User> ProductCategories
		{
			get { return productCategories; }
			set
			{
				if (productCategories != value)
				{
					productCategories = value;
					OnPropertyChanged("ProductCategories");
				}
			}
		}

		ICommand pullToRefreshCommand = null;
		public ICommand PullToRefreshCommand
		{
			get { return pullToRefreshCommand; }
			set
			{
				if (pullToRefreshCommand != value)
				{
					pullToRefreshCommand = value;
					OnPropertyChanged("PullToRefreshCommand");
				}
			}
		}

		void ExecutePullToRefreshCommand()
		{
			data.Refresh();
			ProductCategories = data.Users;
			PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
			IsRefreshing = false;

		}

		protected void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));

		}

	}
}

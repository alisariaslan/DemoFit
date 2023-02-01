using DemoFit.Data;
using DemoFit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFit.View
{
	public class UserDataViewModel: INotifyPropertyChanged
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
}

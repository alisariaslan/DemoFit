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
	public class ProductDataViewModel : INotifyPropertyChanged
	{
		readonly ProductData data;

		public event PropertyChangedEventHandler PropertyChanged;
		public IReadOnlyList<Product> AllProduct { get => data.Products; }

		public ProductDataViewModel()
		{
			data = new ProductData();
		}

		protected void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}
}

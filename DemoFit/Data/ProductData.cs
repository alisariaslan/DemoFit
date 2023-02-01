using DemoFit.Model;
using DemoFit.Task;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFit.Data
{
	public class ProductData
	{
		ApiTask apiTask = new ApiTask();
		public ObservableCollection<Product> Products { get; private set; }
		public ProductData()
		{
			Products = new ObservableCollection<Product>();
			GetProductsAsync();
		}

		private async void GetProductsAsync()
		{
			List<Product> product_list = await apiTask.GetProductListAsync();
			foreach (var product in product_list)
			{
				Products.Add(product);
				Console.WriteLine("" + product.Name);
			}
		}

	}


}

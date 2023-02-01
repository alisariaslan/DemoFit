using Android.Service.Notification;
using DemoFit.Model;
using DemoFit.Task;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace DemoFit.Data
{
	static class PaletteLoader
	{
		public static Color[] LoadPalette(params string[] values)
		{
			Color[] colors = new Color[values.Length];
			for (int i = 0; i < values.Length; i++)
				colors[i] = Color.FromArgb(values[i]);
			return colors;
		}
	}

	public class ProductViewModel
	{
		public IReadOnlyList<Product> Products { get; set; }
		public static List<Product> FakeProducts { get; set; }

		readonly Color[] palette;
		public Color[] Palette => palette;

		ApiTask apiTask = new ApiTask();
		public ProductViewModel()
		{
			Products = FakeProducts;
			palette = PaletteLoader.LoadPalette("#975ba5", "#03bfc1", "#f8c855", "#f45a4e",
											   "#496cbe", "#f58f35", "#d293fd", "#25a966");
		}



	}
}




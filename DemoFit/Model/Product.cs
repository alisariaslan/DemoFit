using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFit.Model
{
    public class Product
    {
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("price")]
		public double Price { get; set; }

		[JsonProperty("sellCount")]
		public double SellCount { get; set; }

		public Product(string name, double sellCount)
		{
			Name = name;
			SellCount = sellCount;
		}
	}
}

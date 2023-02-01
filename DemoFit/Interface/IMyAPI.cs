using DemoFit.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFit.Interface
{
	[Headers("Content-Type:application/json","Authorization:Basic ZGVtbzpkZW1v","User-Agent:ZGVtb3Byb2plY3Q=")]
	public interface IMyAPI
	{
		[Get("/User/all")] Task<List<User>> GetUserList();
		[Get("/Product/all")] Task<List<Product>> GetProductList();
		//[Get("/User/{id}")] Task<User> GetUserWId(int user);
		[Get("/User/name=/{username}")] Task<User> GetUserWName(string username);
		[Put("/User/LoggedUserid=/{id}")] Task<bool> PutLogeedInNotify(int id);
		[Put("/User/save")] Task<bool> UpdateUser(User user);
	}
}

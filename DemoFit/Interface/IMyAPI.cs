using DemoFit.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFit.Interface
{
	public interface IMyAPI
	{
		[Get("/User")]
		Task<List<User>> GetUserList();

		//[Get("/User/{id}")]
		//Task<User> GetUserWId(int user);

		[Headers("Content-Type:application/json",
		 "Authorization:Basic ZGVtbzpkZW1v", "User-Agent:ZGVtb3Byb2plY3Q=")]
		[Get("/User/{username}")]
		Task<User> GetUserWName(string username);
	}
}

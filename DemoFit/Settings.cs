using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFit
{
	public class Settings
	{
		//if enableDebugMode is true then these area will not work
		private string remoteHostAddress = "http://alisariaslan.duckdns.org:5288";

		//enable if you want do debug in your local machine
		private bool enableDebugMode = true;
		private string[] hostAddressList = {"http://localhost:5288", "http://10.0.2.2:5288"};

		public string TargetHostAddress
		{
			get
			{
				if (!enableDebugMode)
				{
					Debug.WriteLine("Target: " + remoteHostAddress);
					Console.WriteLine("Target: " + remoteHostAddress);
					return remoteHostAddress;
				}
				if (DeviceInfo.Platform == DevicePlatform.Android)
				{
					Debug.WriteLine("Target: " + hostAddressList[1]);
					Console.WriteLine("Target: " + hostAddressList[1]);
					return hostAddressList[1];
				}
				else
				{
					Debug.WriteLine("Target: " + hostAddressList[0]);
					Console.WriteLine("Target: " + hostAddressList[0]);
					return hostAddressList[0];
				}
			}
		}
	}
}

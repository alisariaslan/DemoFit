using DevExpress.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFit.Tools
{
    public class Pop
    {
		public static void Up(DXPopup dXPopup, Label label, string text )
		{
			label.Text = text;
			dXPopup.IsOpen = true;
		}
	}
}

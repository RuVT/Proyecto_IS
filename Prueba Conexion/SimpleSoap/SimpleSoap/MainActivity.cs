using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SimpleSoap
{
	[Activity (Label = "SimpleSoap", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {		
				HacerTest(button);
			};
		}

		public void HacerTest(Button button)
		{
			localhost.ServicioWCF servicio = new SimpleSoap.localhost.ServicioWCF ();
			button.Text=servicio.DoWork ();
			//System.Net.WebRequest request=new System.Net.WebRequest(http://tempuri.org/IServicioWCF/DoWork)
			
		}
	}
}



using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TMaker
{
	[Activity (Label = "T-Maker", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource, and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);

			Button BLogin = FindViewById<Button> (Resource.Id.btnLogin);
			Button BRegistro = FindViewById<Button> (Resource.Id.btnRegistro);
			
			BLogin.Click += delegate {
				SetContentView (Resource.Layout.g);
			};

			BRegistro.Click += delegate {
				SetContentView (Resource.Layout.Registro);
			};

		}

	}
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MrTMaker
{
	[Activity (Label = "Menu")]			
	public class Menu : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Menu);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.btnbuscar);
			Button perfil = FindViewById<Button> (Resource.Id.btnperfil);
//
			button.Click += delegate {
				var intent = new Intent(this, typeof(BuscarPersona));			
				StartActivity(intent);
			};

			perfil.Click += delegate {
				var intent = new Intent(this, typeof(Perfil));
				StartActivity(intent);
			};

			//btnperfil
		}
	}
}


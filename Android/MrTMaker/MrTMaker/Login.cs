
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
	[Activity (Label = "Login")]			
	public class Login : Activity
	{
		public static usuario.SQL_Usuario1 _usuario;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

			// Get our button from the layout resource, and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);

			Button BLogin = FindViewById<Button> (Resource.Id.btnLogin);
			Button BRegistro = FindViewById<Button> (Resource.Id.btnRegistro);

			BLogin.Click += delegate {
				HacerTest();
			};

			BRegistro.Click += delegate {
				var intent = new Intent(this, typeof(Registro));			
				StartActivity(intent);
			};

		}

		public void HacerTest()
		{
			usuario.SQL_Usuario usu = new usuario.SQL_Usuario ();
			EditText user = FindViewById<EditText> (Resource.Id.txtUsuario);
			EditText pas = FindViewById<EditText> (Resource.Id.txtPassword);
			bool exito = false;
			bool otro=false;
			usu.login (user.Text, pas.Text, out exito, out otro);
			if (exito) 
			{
				_usuario = usu.getUsuarioByName (user.Text);
				Toast.MakeText (this, "Login Exitoso", ToastLength.Long).Show();
				var intent = new Intent(this, typeof(Menu));			
				StartActivity(intent);
			}
			else
				Toast.MakeText (this, "Usuario o contraseña incorrectas", ToastLength.Long).Show();			
		}
	}
}


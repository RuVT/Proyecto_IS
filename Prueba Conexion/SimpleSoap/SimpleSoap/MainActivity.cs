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
			Usuario.SQL_Usuario usu = new SimpleSoap.Usuario.SQL_Usuario ();
			EditText user = FindViewById<EditText> (Resource.Id.txtUsuario);
			EditText pas = FindViewById<EditText> (Resource.Id.txtPassword);
			bool exito = false;
			bool otro=false;
			usu.login (user.Text, pas.Text, out exito, out otro);
			if (exito) 
			{
				Toast.MakeText (this, "Login Exitoso", ToastLength.Long).Show();
			}
			else
				Toast.MakeText (this, "Usuario o contraseña incorrectas", ToastLength.Long).Show();
//			//Creamos un objeto SQL_Atributo que contiene los metodos
//			Atributo.SQL_Atributo atr=new SimpleSoap.Atributo.SQL_Atributo();
//			//Ejecutamos un metodo guardamos los atributos en un Array de AQL_Atributos1 que contienen las variables 
//			Atributo.SQL_Atributo1 [] lista=atr.getAllAtributos ();
//			string nombresAtributo = "";
//			//Guardamos los nombres de cada atributo
//			foreach (Atributo.SQL_Atributo1 a in lista) 
//			{
//				nombresAtributo+=a.atr_drescription+"\n";				
//			}
//			//Los mostramos en la pantalla del andriod
//			Toast.MakeText (this, nombresAtributo, ToastLength.Long).Show();
		}
	}
}



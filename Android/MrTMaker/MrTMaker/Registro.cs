
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
using Android.Graphics;

namespace MrTMaker
{
	[Activity (Label = "Registro")]			
	public class Registro : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Registro);
			Button button = FindViewById<Button> (Resource.Id.OK);

			button.Click += delegate {
				Validar();
			};
		}

		protected void CrearUsuario(string user, string password,string password2)
		{
			usuario.SQL_Usuario us = new MrTMaker.usuario.SQL_Usuario ();
			bool existe = false, otro;
			us.userExist (user, out existe, out otro);
			if (!existe) {
				usuario.SQL_Usuario1 us2 = new MrTMaker.usuario.SQL_Usuario1 ();
				us2.name = user;
				us2.password = password;
				us2.ind_id = -1;
				us2.type = 1;
				bool operacion = true;
				us.createNewUsuarioInDB (us2,out us2.id,out operacion);
				us2.idSpecified = true;
				CrearIndividuo (us2);
				object [] obj=new object[] { us2 };
				us.updateUsuarioInDB (us2);
				Toast.MakeText (this, "Registro exitoso", ToastLength.Long);
				Intent inten = new Intent (this,typeof(Login));
				StartActivity (inten);
			} 
			else {
				Toast.MakeText (this, "El nombre de usuario ya existe, elija otro", ToastLength.Long);
			}
		}

		protected void Validar()
		{
			TextView name = FindViewById<TextView> (Resource.Id.Usuario);
			TextView pass = FindViewById<TextView> (Resource.Id.pass);
			TextView pass2 = FindViewById<TextView> (Resource.Id.pass_c);

			if (pass.Text == pass2.Text && name.Text!="") {
				CrearUsuario (name.Text, pass.Text, pass2.Text);
			}
		}

		protected void CrearIndividuo(usuario.SQL_Usuario1 usu)
		{
			TextView real = FindViewById<TextView> (Resource.Id.nombreReal);
			individuo.SQL_Individuo mensajero = new MrTMaker.individuo.SQL_Individuo ();
			individuo.SQL_Individuo1 ind = new MrTMaker.individuo.SQL_Individuo1 ();
			ind.name = real.Text;
			ind.last_name1 = "";
			ind.last_name2 = "";
			ind.email = "";
			ind.direction = "";
			ind.years = DateTime.Now;
			ind.yearsSpecified = true;
			bool operacion = true;
			mensajero.createNewIndividuoInDB (ind, out usu.ind_id, out operacion);
			ind.id = usu.ind_id;
			CrearImagen (ind);
			usu.ind_idSpecified = true;
		}

		protected void CrearImagen(individuo.SQL_Individuo1 ind)
		{
//			Bitmap bm=BitmapFactory.DecodeResource (Resources,Resource.Drawable.MrTMaker);
//
//			System.IO.MemoryStream stream = new System.IO.MemoryStream();
//			bm.Compress(Bitmap.CompressFormat.Png, 50, stream);
//			byte[] byteArray = stream.ToArray();

			imagen.SQL_Imagen mensajero = new MrTMaker.imagen.SQL_Imagen ();
			imagen.SQL_Imagen1 ima = new MrTMaker.imagen.SQL_Imagen1 ();
			ima.ind_id = ind.id;
			ima.ind_idSpecified = true;
			bool proceso = true;
//			ima.ima_dat = byteArray;
			mensajero.createNewImageInDB (ima, out ima.ima_id,out proceso);
		}
	}
}


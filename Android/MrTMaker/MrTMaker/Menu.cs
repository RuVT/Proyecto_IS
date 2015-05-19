
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
			Button buscar = FindViewById<Button> (Resource.Id.btnbuscar);
			Button perfil = FindViewById<Button> (Resource.Id.btnperfil);
			Button equi = FindViewById<Button> (Resource.Id.btnequipo);
			buscar.Click += delegate {
				var intent = new Intent(this, typeof(BuscarPersona));			
				StartActivity(intent);
			};

			perfil.Click += delegate {
				var intent = new Intent(this, typeof(Perfil));
				StartActivity(intent);
			};
			equi.Click += delegate {
				var intent = new Intent(this, typeof(Equipo));
				StartActivity(intent);
			};

			MostrarDatos ();
			//btnperfil
		}

		protected void MostrarDatos()
		{
			individuo.SQL_Individuo mensajero = new MrTMaker.individuo.SQL_Individuo ();
			individuo.SQL_Individuo1 ind=mensajero.getIndividuoFromDBbyID (Login._usuario.ind_id,true);
			TextView nombre = FindViewById<TextView> (Resource.Id.txtnombre);
			nombre.Text = ind.name;
			ImageView foto = FindViewById<ImageView> (Resource.Id.imagenUsuario);
			imagen.SQL_Imagen mensajero2 = new MrTMaker.imagen.SQL_Imagen ();
			imagen.SQL_Imagen1 img=mensajero2.getImagenFromIndividio (ind.id, true).First ();
			if (img.ima_dat != null) {
				Bitmap bm = BitmapFactory.DecodeByteArray (img.ima_dat, 0, img.ima_dat.Length);
				foto.SetImageBitmap (bm);
			}
		}
			
		protected override void  OnResume()
		{  // After a pause OR at startup
			base.OnResume();
			MostrarDatos ();
		}
	}
}


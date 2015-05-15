
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
			Bitmap bm=BitmapFactory.DecodeByteArray(img.ima_dat , 0, img.ima_dat.Length);
			foto.SetImageBitmap (bm);
		}
	}
}


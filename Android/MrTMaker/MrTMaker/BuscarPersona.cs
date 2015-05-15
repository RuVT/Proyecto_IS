
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
	[Activity (Label = "BuscarPersona")]			
	public class BuscarPersona : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.BuscarPersona);
			// Create your application here

			Button buscarPersona = FindViewById<Button>(Resource.Id.btnBuscarPersona);
			buscarPersona.Click+= delegate{ Buscar(); };
		}

		public void Buscar()
		{			
			EditText nombre = FindViewById<EditText> (Resource.Id.nombrePersonaBuscar);
			individuo.SQL_Individuo mensajero = new MrTMaker.individuo.SQL_Individuo ();
			individuo.SQL_Individuo1 [] datos = mensajero.searchIndividuoByName (nombre.Text);
			LinearLayout ll = FindViewById<LinearLayout>(Resource.Id.llContenedor);
			ll.RemoveViews (0, ll.ChildCount);
			foreach (individuo.SQL_Individuo1 ind in datos) {
				
				LayoutInflater layoutInflater = (LayoutInflater) BaseContext.GetSystemService(Context.LayoutInflaterService);
				View addView = layoutInflater.Inflate(Resource.Layout.viewResultados, null);
				Button b1 = addView.FindViewById<Button>(Resource.Id.btnPersona);
				b1.Text=ind.name + " " + ind.last_name1 + " " + ind.last_name2;

				ImageView foto = addView.FindViewById<ImageView> (Resource.Id.ivPersona);
				imagen.SQL_Imagen mensajero2 = new MrTMaker.imagen.SQL_Imagen ();
				try
				{
					imagen.SQL_Imagen1 img=mensajero2.getImagenFromIndividio (ind.id, true).First ();
					Bitmap bm=BitmapFactory.DecodeByteArray(img.ima_dat , 0, img.ima_dat.Length);
					foto.SetImageBitmap (bm);
				}
				catch(Exception){
				}
				ll.AddView (addView);

			}
		}
	}
}


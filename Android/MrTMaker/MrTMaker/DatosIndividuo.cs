
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
	[Activity (Label = "DatosIndividuo")]			
	public class DatosIndividuo : Activity
	{
		LinearLayout contenido;
		int indid;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.DatosIndividio);
			TextView nombre = FindViewById<TextView> (Resource.Id.tvNombreCompleto);
			ImageView foto=FindViewById<ImageView> (Resource.Id.ivFotoIndividuo);
			Button evaluar = FindViewById<Button> (Resource.Id.btnEvaluar);

			evaluar.Click+= delegate{ 
				Intent intent=new Intent(this,typeof(Evaluacion));
				intent.PutExtra("ind_id",Intent.GetIntExtra("ind_id",-1));
				StartActivity(intent);

			}; 

			individuo.SQL_Individuo mensajero_ind = new MrTMaker.individuo.SQL_Individuo ();
			individuo.SQL_Individuo1 ind=mensajero_ind.getIndividuoFromDBbyID (Intent.GetIntExtra("ind_id",-1), true);

			nombre.Text = ind.name + " " + ind.last_name1 + " " + ind.last_name2;

			imagen.SQL_Imagen mensajeo_ima = new MrTMaker.imagen.SQL_Imagen ();
			imagen.SQL_Imagen1 ima=mensajeo_ima.getImagenFromIndividio (ind.id, true).First();
			if (ima.ima_dat != null) {
				Bitmap bm = BitmapFactory.DecodeByteArray (ima.ima_dat, 0, ima.ima_dat.Length);
				//Bitmap bm = foto.GetDrawingCache ();
				foto.SetImageBitmap (bm);
			}
			contenido = FindViewById<LinearLayout> (Resource.Id.llContenidoHabilidades);
			indid = ind.id;
			LLenarHabiliaddes (ind.id);
			// Create your application here
		}

		private void LLenarHabiliaddes(int ind_id)
		{
			LayoutInflater layoutInflater = (LayoutInflater) BaseContext.GetSystemService(Context.LayoutInflaterService);	
			habilidad.SQL_Habilidad mensajero = new MrTMaker.habilidad.SQL_Habilidad ();
			habilidad.SQL_Habilidad1 [] habilidades=mensajero.getHabilidadByIndividuo (ind_id,true);
			contenido.RemoveViews (0, contenido.ChildCount);
			foreach (habilidad.SQL_Habilidad1 hab in habilidades) {
				View habEstatus=layoutInflater.Inflate(Resource.Layout.Estatus, null);
				TextView info = habEstatus.FindViewById<TextView> (Resource.Id.textEstatus);
				//info.Text;
				atributo.SQL_Atributo mensajero2=new MrTMaker.atributo.SQL_Atributo();
				atributo.SQL_Atributo1 atri=mensajero2.getAtributoByID (hab.atr_id, true);
				info.Text = "Atributo : " + atri.atr_name + "; Calificacion: " + hab.hab_FinalValue;
				contenido.AddView (habEstatus);
			}
		}
			
		protected override void OnResume()
		{  // After a pause OR at startup
			base.OnResume();
			LLenarHabiliaddes (indid);
			//Refresh your stuff here
		}
	}
}


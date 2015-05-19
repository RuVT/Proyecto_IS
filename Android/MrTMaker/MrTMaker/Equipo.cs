
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
	[Activity (Label = "Equipo")]			
	public class Equipo : Activity
	{
		LinearLayout contenedor;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.VistaEquipos);
			contenedor = FindViewById<LinearLayout> (Resource.Id.lvContenedor);
			LlenarEquipos ();
			// Create your application here
		}

		protected void LlenarEquipos()
		{
			participacionEquipo.SQL_ParticipacionEquipo mensajero_par = new MrTMaker.participacionEquipo.SQL_ParticipacionEquipo ();
			participacionEquipo.SQL_ParticipacionEquipo1[] par=mensajero_par.getParticipacionFromIndividuo (Login._usuario.ind_id, true);
			contenedor.RemoveViews (0, contenedor.ChildCount);
			foreach (participacionEquipo.SQL_ParticipacionEquipo1 p in par) {

				LayoutInflater layoutInflater = (LayoutInflater) BaseContext.GetSystemService(Context.LayoutInflaterService);
				View addView = layoutInflater.Inflate(Resource.Layout.viewResultados, null);
				Button b1 = addView.FindViewById<Button>(Resource.Id.btnPersona);

				equipo.SQL_Equipo mensjero_equi = new MrTMaker.equipo.SQL_Equipo ();
				equipo.SQL_Equipo1 equ = mensjero_equi.getEquipoByID (p.equ_id,true);
				b1.Text= equ.equ_name;

				b1.Click += delegate {
//					Intent intent=new Intent(this,typeof(DatosIndividuo));
//					intent.PutExtra("ind_id",ind.id);
//					StartActivity(intent);
				};

				ImageView foto = addView.FindViewById<ImageView> (Resource.Id.ivPersona);
				foto.Visibility = ViewStates.Gone;
				contenedor.AddView (addView);
			}


			
		}

		protected void CrearNuevoEquipo()
		{
			EditText nombre = FindViewById<EditText> (Resource.Id.NombreEquipo);
			if (nombre.Text != "") 
			{
				equipo.SQL_Equipo nuevo = new MrTMaker.equipo.SQL_Equipo ();

			}
		}
	}
}


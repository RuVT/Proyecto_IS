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
	[Activity (Label = "Evaluacion")]			
	public class Evaluacion : Activity
	{		
		int ind_id;
		LinearLayout contenedor;
		Dictionary<int, View> atributos = new Dictionary<int, View> ();
		habilidad.SQL_Habilidad1 [] hab;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Evaluacion);
			ind_id=Intent.GetIntExtra ("ind_id", -1);
			contenedor = FindViewById<LinearLayout> (Resource.Id.llContenidoEvaluacion);
			MostrarHabilidades ();
			Button guardar = FindViewById<Button> (Resource.Id.btnGuardarEvaluacion);
			guardar.Click += delegate {
				GuardarEvaluacion ();
			};
		}


		private void MostrarHabilidades()
		{
			LayoutInflater layoutInflater = (LayoutInflater) BaseContext.GetSystemService(Context.LayoutInflaterService);	
			atributo.SQL_Atributo mensajero_atr = new MrTMaker.atributo.SQL_Atributo ();
			atributo.SQL_Atributo1[] atri = mensajero_atr.getAllAtributos ();

			habilidad.SQL_Habilidad mensajero_hab = new MrTMaker.habilidad.SQL_Habilidad ();
			hab = mensajero_hab.getHabilidadByIndividuo (ind_id,true);

			foreach (atributo.SQL_Atributo1 at in atri) 
			{
				View habEva = layoutInflater.Inflate (Resource.Layout.HabilidadEvaluable, null);
				TextView nombre = habEva.FindViewById<TextView> (Resource.Id.tvNombreAtri); 
				SeekBar barra = habEva.FindViewById<SeekBar> (Resource.Id.sbBarraEvaluacion);
				TextView numero = habEva.FindViewById<TextView> (Resource.Id.tvNumeroBarra);

				nombre.Text = at.atr_name;
				numero.Text = barra.Progress.ToString();
				barra.ProgressChanged += delegate {					
					numero.Text = barra.Progress.ToString();
				};
				contenedor.AddView (habEva);
				atributos.Add (at.atr_id, habEva);
			}

			foreach (habilidad.SQL_Habilidad1 ha in hab) 
			{					 
				View habEva = atributos [ha.atr_id];
				SeekBar barra = habEva.FindViewById<SeekBar> (Resource.Id.sbBarraEvaluacion);
				TextView numero = habEva.FindViewById<TextView> (Resource.Id.tvNumeroBarra);
				barra.Progress = int.Parse(ha.hab_FinalValue.ToString());
			}
		}

		protected void GuardarEvaluacion()
		{
			foreach (var kvp in atributos) 
			{
				View habEva = kvp.Value;
				SeekBar barra = habEva.FindViewById<SeekBar> (Resource.Id.sbBarraEvaluacion);
				if(barra.Progress>0)
					ValiadarEvaluacionExiste (kvp.Key, barra.Progress);				
			}
		}

		protected void ValiadarEvaluacionExiste(int atrid,double valor)
		{
			evaluacion.SQL_Evaluacion mensajero_eva = new MrTMaker.evaluacion.SQL_Evaluacion ();
			evaluacion.SQL_Evaluacion1 eva=mensajero_eva.searchEvaluacionByIndividuoAtributo (Login._usuario.ind_id, true, ind_id, true, atrid, true);
			if (eva == null) 
			{
				eva = new MrTMaker.evaluacion.SQL_Evaluacion1 ();
				eva.atr_id = atrid;
				eva.atr_idSpecified = true;
				eva.ind_idExaminer = Login._usuario.ind_id;
				eva.ind_idExaminerSpecified = true;
				eva.ind_idExamined = ind_id;
				eva.ind_idExaminedSpecified = true;
				eva.eva_value = valor;
				eva.eva_valueSpecified = true;
				eva.eva_date = DateTime.Now;
				eva.eva_dateSpecified = true;
				bool proceso = true;
				mensajero_eva.createNewevaluacionInDB (eva, out eva.eva_id, out proceso);
			}
			else
			{				
				eva.atr_idSpecified = true;
				eva.ind_idExaminerSpecified = true;
				eva.ind_idExaminedSpecified = true;
				eva.eva_value = valor;
				eva.eva_valueSpecified = true;
				eva.eva_date = DateTime.Now;
				eva.eva_dateSpecified = true;
				mensajero_eva.updateEvaluacionInDB (eva);
			}

		}
	}
}


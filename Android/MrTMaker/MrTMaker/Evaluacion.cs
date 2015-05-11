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
		int v_compromiso = 0;
		int v_organizacion = 0;
		int v_tolerancia = 0;
		int v_iniciativa = 0;
		int v_puntualidad = 0;
		int v_nivel = 0;

		protected override void OnCreate (Bundle bundle)
		{

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Evaluacion);

			TextView tc = FindViewById<TextView> (Resource.Id.T_C);
			TextView to = FindViewById<TextView> (Resource.Id.T_O);
			TextView tt = FindViewById<TextView> (Resource.Id.T_T);
			TextView ti = FindViewById<TextView> (Resource.Id.T_I);
			TextView tp = FindViewById<TextView> (Resource.Id.T_P);
			TextView tn = FindViewById<TextView> (Resource.Id.T_N);
			SeekBar s1 = FindViewById<SeekBar> (Resource.Id.compromiso);
			SeekBar s2 = FindViewById<SeekBar> (Resource.Id.organización);
			SeekBar s3 = FindViewById<SeekBar> (Resource.Id.Tolerancia);
			SeekBar s4 = FindViewById<SeekBar> (Resource.Id.Iniciativa);
			SeekBar s5 = FindViewById<SeekBar> (Resource.Id.Puntualidad);
			SeekBar s6 = FindViewById<SeekBar> (Resource.Id.Nivel_C);
			Button boton = FindViewById<Button> (Resource.Id.Evaluar);


			s1.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					tc.Text = string.Format ("{0}" ,e.Progress);
					//v_compromiso = e.Progress;
				}
			};

			s2.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					to.Text = string.Format ("{0}" ,e.Progress);
					//v_organización = e.Progress;
				}
			};

			s3.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					tt.Text = string.Format ("{0}" ,e.Progress);
					//v_tolerancia = e.Progress;
				}
			};

			s4.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					ti.Text = string.Format ("{0}" ,e.Progress);
					//v_iniciativa = e.Progress;
				}
			};

			s5.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					tp.Text = string.Format ("{0}" ,e.Progress);
					//v_puntualidad = e.Progress;
				}
			};

			s6.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					tn.Text = string.Format ("{0}" ,e.Progress);
					//v_nivel = e.Progress;
				}
			};

			boton.Click += (sender, e) => {
				new AlertDialog.Builder(this)
					.SetMessage("Compromiso\nOrganización")
					.Show();
			};


			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);

			//button.Click += delegate {
			//button.Text = string.Format ("{0} clicks!", count++);
		}
	}
}


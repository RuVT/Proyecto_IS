
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
using Java.IO;
using System.Threading;

namespace MrTMaker
{
	[Activity (Label = "Perfil")]			
	public class Perfil : Activity
	{
		individuo.SQL_Individuo1 _individuo;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Perfil);
			Button buscar = FindViewById<Button> (Resource.Id.btnAbrirImagen);
			buscar.Click += delegate {                
				var imageIntent = new Intent ();
				imageIntent.SetType ("image/*");
				imageIntent.SetAction (Intent.ActionGetContent);
				StartActivityForResult (
					Intent.CreateChooser (imageIntent, "Select photo"), 0);
			} ;

			Button guardar = FindViewById<Button> (Resource.Id.btnGuardarIndividuo);
			guardar.Click += delegate { GuardarInformacion(); } ;

			LlenarCampos ();
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			if (resultCode == Result.Ok) {
				var imageView = 
					FindViewById<ImageView> (Resource.Id.imagaFotoPersonal);
				imageView.SetImageURI (data.Data);
			}
		}

		protected void GuardarInformacion()
		{
			EditText nombre = FindViewById<EditText> (Resource.Id.txtNombreReal);
			EditText apellidoPa = FindViewById<EditText> (Resource.Id.txtApellidoPaterno);
			EditText apellidoMa = FindViewById<EditText> (Resource.Id.txtApellidoMaterno);
			EditText mail = FindViewById<EditText> (Resource.Id.txtEmail);
			DatePicker fecha = FindViewById<DatePicker> (Resource.Id.dpFechaNacimiento);
			EditText telefono = FindViewById<EditText> (Resource.Id.txtTelefono);


			individuo.SQL_Individuo mensajero = new MrTMaker.individuo.SQL_Individuo ();
			individuo.SQL_Individuo1 ind = new MrTMaker.individuo.SQL_Individuo1 ();

			ind.id = Login._usuario.ind_id;
			ind.idSpecified = true;
			ind.name = nombre.Text;
			ind.last_name1 = apellidoPa.Text;
			ind.last_name2 = apellidoMa.Text;
			ind.direction = "";
			ind.email = mail.Text;
			ind.years = fecha.DateTime;
			ind.yearsSpecified = true;
			ind.telephone = int.Parse(telefono.Text);
			ind.telephoneSpecified = true;

			mensajero.updateIndividuoInDB (ind);
			Thread subir = new Thread (new ThreadStart (delegate {
				GuardarImagen (ind);
			}));
			subir.Start ();
			//GuardarImagen (ind);

		}

		protected void GuardarImagen(individuo.SQL_Individuo1 ind)
		{
			imagen.SQL_Imagen mensajero = new MrTMaker.imagen.SQL_Imagen ();
			ImageView foto = FindViewById<ImageView> (Resource.Id.imagaFotoPersonal);

			foto.SetWillNotCacheDrawing (false);
			foto.BuildDrawingCache ();
			Bitmap bm = foto.GetDrawingCache (false);

			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			bm.Compress(Bitmap.CompressFormat.Png, 50, stream);
			byte[] byteArray = stream.ToArray();

			imagen.SQL_Imagen1 img = mensajero.getImagenFromIndividio (ind.id, true).First();//mensajero.getImagenFromIndividio(ind.id,true).First();
			img.ima_idSpecified = true;
			img.ima_dat = byteArray;
			//int i;
			//bool ope = true;
			mensajero.updateImagenInDB (img);
			//mensajero.createNewImageInDB (img, out i, out ope);

		}

		protected void LlenarCampos()
		{
			EditText nombre = FindViewById<EditText> (Resource.Id.txtNombreReal);
			EditText apellidoPa = FindViewById<EditText> (Resource.Id.txtApellidoPaterno);
			EditText apellidoMa = FindViewById<EditText> (Resource.Id.txtApellidoMaterno);
			EditText mail = FindViewById<EditText> (Resource.Id.txtEmail);
			DatePicker fecha = FindViewById<DatePicker> (Resource.Id.dpFechaNacimiento);
			EditText telefono = FindViewById<EditText> (Resource.Id.txtTelefono);	
			ImageView foto = FindViewById<ImageView> (Resource.Id.imagaFotoPersonal);

			individuo.SQL_Individuo mensajero = new MrTMaker.individuo.SQL_Individuo ();
			_individuo=mensajero.getIndividuoFromDBbyID (Login._usuario.ind_id,true);
			nombre.Text = _individuo.name;
			apellidoPa.Text = _individuo.last_name1;
			apellidoMa.Text = _individuo.last_name2;
			mail.Text = _individuo.email;
			telefono.Text = _individuo.telephone.ToString();
			fecha.DateTime = _individuo.years;

			imagen.SQL_Imagen mensajero2 = new MrTMaker.imagen.SQL_Imagen ();
			imagen.SQL_Imagen1 ima=mensajero2.getImagenFromIndividio (_individuo.id,true).First();
			Bitmap bm=BitmapFactory.DecodeByteArray(ima.ima_dat , 0, ima.ima_dat.Length);
			//Bitmap bm = foto.GetDrawingCache ();
			foto.SetImageBitmap (bm);
		}
	}
}


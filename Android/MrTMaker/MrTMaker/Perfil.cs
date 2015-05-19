
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
using System.Globalization;
using Android.Provider;
using Android.Content.PM;

namespace MrTMaker
{
	[Activity (Label = "Perfil")]			
	public class Perfil : Activity
	{
		LinearLayout contenedor;
		View perfil;
		individuo.SQL_Individuo1 _individuo;
		private ImageView _imageView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			SetContentView (Resource.Layout.PerfilEstatus);

			LayoutInflater layoutInflater = (LayoutInflater) BaseContext.GetSystemService(Context.LayoutInflaterService);
			perfil = layoutInflater.Inflate(Resource.Layout.Perfil, null);

			contenedor = FindViewById<LinearLayout> (Resource.Id.lvContenedor);

			//-----------------------
			_imageView = perfil.FindViewById<ImageView>(Resource.Id.imagaFotoPersonal);
			Button buscar = perfil.FindViewById<Button> (Resource.Id.btnAbrirImagen);
			buscar.Click += delegate {                
				var imageIntent = new Intent ();
				imageIntent.SetType ("image/*");
				imageIntent.SetAction (Intent.ActionGetContent);
				StartActivityForResult (
					Intent.CreateChooser (imageIntent, "Select photo"), 0);
			} ;

			Button guardar = perfil.FindViewById<Button> (Resource.Id.btnGuardarIndividuo);
			guardar.Click += delegate { GuardarInformacion(); } ;
			LlenarPerfil();
			//-----------------------------

			ActionBar.Tab tab = ActionBar.NewTab();
			tab.SetText("Perfil");			;
			tab.TabSelected += (sender, args) => {
				contenedor.RemoveViews(0,contenedor.ChildCount);
				contenedor.AddView(perfil);
			};
				ActionBar.AddTab(tab);

			tab = ActionBar.NewTab();
			tab.SetText("Estatus");
			tab.TabSelected += (sender, args) => {
				contenedor.RemoveViews(0,contenedor.ChildCount);
				LlenarEstatus();
			};
				ActionBar.AddTab(tab);

		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			if (resultCode == Result.Ok) 
			{
				_imageView.SetImageURI (data.Data);
			}
		}

		protected void GuardarInformacion()
		{
			EditText nombre = perfil.FindViewById<EditText> (Resource.Id.txtNombreReal);
			EditText apellidoPa = perfil.FindViewById<EditText> (Resource.Id.txtApellidoPaterno);
			EditText apellidoMa = perfil.FindViewById<EditText> (Resource.Id.txtApellidoMaterno);
			EditText mail = perfil.FindViewById<EditText> (Resource.Id.txtEmail);
			DatePicker fecha = perfil.FindViewById<DatePicker> (Resource.Id.dpFechaNacimiento);
			EditText telefono = perfil.FindViewById<EditText> (Resource.Id.txtTelefono);


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
			ind.telephone = telefono.Text;			
			//int.TryParse(numero,out ind.telephone);
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
			ImageView foto = perfil.FindViewById<ImageView> (Resource.Id.imagaFotoPersonal);

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

		protected void LlenarPerfil()
		{
			EditText nombre = perfil.FindViewById<EditText> (Resource.Id.txtNombreReal);
			EditText apellidoPa = perfil.FindViewById<EditText> (Resource.Id.txtApellidoPaterno);
			EditText apellidoMa = perfil.FindViewById<EditText> (Resource.Id.txtApellidoMaterno);
			EditText mail = perfil.FindViewById<EditText> (Resource.Id.txtEmail);
			DatePicker fecha = perfil.FindViewById<DatePicker> (Resource.Id.dpFechaNacimiento);
			EditText telefono = perfil.FindViewById<EditText> (Resource.Id.txtTelefono);	
			ImageView foto = perfil.FindViewById<ImageView> (Resource.Id.imagaFotoPersonal);

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
			if (ima.ima_dat != null) {
				Bitmap bm = BitmapFactory.DecodeByteArray (ima.ima_dat, 0, ima.ima_dat.Length);
				//Bitmap bm = foto.GetDrawingCache ();
				foto.SetImageBitmap (bm);
			}
		}

		protected void LlenarEstatus()
		{
			LayoutInflater layoutInflater = (LayoutInflater) BaseContext.GetSystemService(Context.LayoutInflaterService);	
			habilidad.SQL_Habilidad mensajero = new MrTMaker.habilidad.SQL_Habilidad ();
			habilidad.SQL_Habilidad1 [] habilidades=mensajero.getHabilidadByIndividuo (Login._usuario.ind_id,true);
			foreach (habilidad.SQL_Habilidad1 hab in habilidades) {
				View habEstatus=layoutInflater.Inflate(Resource.Layout.Estatus, null);
				TextView info = habEstatus.FindViewById<TextView> (Resource.Id.textEstatus);
				//info.Text;
				atributo.SQL_Atributo mensajero2=new MrTMaker.atributo.SQL_Atributo();
				atributo.SQL_Atributo1 atri=mensajero2.getAtributoByID (hab.atr_id, true);
				info.Text = "Atributo : " + atri.atr_name + "; Calificacion: " + hab.hab_FinalValue;
				contenedor.AddView (habEstatus);
			}
		}

	}

}


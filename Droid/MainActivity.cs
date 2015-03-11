using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;
using System.IO;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace MediaPickerSample01.Droid
{
	[Activity (Label = "MediaPickerSample01.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			if (!Resolver.IsSet)
			{
				this.SetIoc();
			}
			else
			{
				var app = Resolver.Resolve<IXFormsApp>() as IXFormsApp<XFormsApplicationDroid>;
				app.AppContext = this;
			}

			Xamarin.Forms.Forms.Init(this, bundle);

			App.Init();

			Xamarin.Forms.Forms.ViewInitialized += (sender, e) =>
			{
				if (!string.IsNullOrWhiteSpace(e.View.StyleId))
				{
					e.NativeView.ContentDescription = e.View.StyleId;
				}
			};

			this.SetPage(App.GetMainPage());
		}

		/// <summary>
		/// Sets the IoC.
		/// </summary>
		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppDroid();

			app.Init(this);

			var documents = app.AppDataDirectory;
			var pathToDatabase = Path.Combine(documents, "xforms.db");

			resolverContainer.Register<IDevice> (t => AndroidDevice.CurrentDevice)
				.Register<IDisplay> (t => t.Resolve<IDevice> ().Display)
				.Register<IMediaPicker, MediaPickerSample01.Droid.MediaPicker>()				//MediaPicker>()
				//.Register<IJsonSerializer, Services.Serialization.ServiceStackV3.JsonSerializer>()
				.Register<IDependencyContainer> (resolverContainer)
				.Register<IXFormsApp> (app);
			//.Register<ISimpleCache>(
			//	t => new SQLiteSimpleCache(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(),
			//		new SQLite.Net.SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));


			Resolver.SetResolver(resolverContainer.GetResolver());
		}	
	}
}


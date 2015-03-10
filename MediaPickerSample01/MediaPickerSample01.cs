using System;

using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;
using XLabs.Forms.Mvvm;
using XLabs.Platform.Services;
using XLabs.Forms.Services;

namespace MediaPickerSample01
{
	public class App : Application
	{
		public App ()
		{
			Init ();
			// The root page of your application
			MainPage = GetMainPage ();
		}

		/// <summary>
		/// Initializes the application.
		/// </summary>
		public static void Init()
		{
			var app = Resolver.Resolve<IXFormsApp>();
			if (app == null)
			{
				return;
			}

			ViewFactory.Register<MyTestPage, MyTestViewModel>();
			ViewFactory.Register<MyTestPage, MyTest3ViewModel>();

		}

		/// <summary>
		/// Gets the main page.
		/// </summary>
		/// <returns>The Main Page.</returns>
		public static Page GetMainPage()
		{
			var mvvm = ViewFactory.CreatePage<MyTest3ViewModel, MyTestPage> ();

			var mainPage = new NavigationPage((Page)mvvm);

			Resolver.Resolve<IDependencyContainer>()
				.Register<INavigationService>(t => new NavigationService(mainPage.Navigation));

			return mainPage;
		}
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


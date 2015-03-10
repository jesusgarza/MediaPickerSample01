using System;
using XLabs.Forms.Mvvm;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Media.Plugin;

namespace MediaPickerSample01
{
	[ViewType(typeof(MyTestPage))]
	public class MyTest3ViewModel : XLabs.Forms.Mvvm.ViewModel
	{
		public MyTest3ViewModel ()
		{
		}

		private string _textMessage = "My Test";
		public string TextMessage
		{
			get
			{
				return _textMessage;
			}
			set
			{
				this.SetProperty(ref _textMessage, value);
			}
		}

		private Command _cmdToVerifyIsWorking;
		public Command CmdToVerifyIsWorking 
		{
			get
			{
				return _cmdToVerifyIsWorking ?? (_cmdToVerifyIsWorking = new Command(
					(m) => VerifyIsWoking(),
					(o) => true));
			}
		}

		private void VerifyIsWoking()
		{
			this.TextMessage = "YES! It seems to be working!!";
			return;
		}

		/*******************************************************************************************/

		private Command _cmdToUseMediaPicker;
		public Command CmdToUseMediaPicker 
		{
			get
			{
				return _cmdToUseMediaPicker ?? (_cmdToUseMediaPicker = new Command(
					async (m) => UseMediaPicker(),
					(o) => true));
			}
		}

		private async Task UseMediaPicker()
		{
			await SelectPicture ();

			return;
		}

		/// <summary>
		/// Selects the picture.
		/// </summary>
		/// <returns>Select Picture Task.</returns>
		private async Task SelectPicture()
		{
			try
			{
				if (!CrossMedia.Current.IsPickPhotoSupported)
				{
					Debug.WriteLine("IsPickPhotoSupported false");
					return;
				}

				var mediaFile = await CrossMedia.Current.PickPhotoAsync();

				Debug.WriteLine("SelectPicture.Path." + mediaFile.Path);

			}
			catch (System.Exception ex)
			{
				Debug.WriteLine ("SelectPicture.Exception. " + ex.Message);
			}
		}
	}
}


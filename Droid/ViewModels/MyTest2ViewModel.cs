using System;
using XLabs.Forms.Mvvm;
using Xamarin.Forms;

namespace MediaPickerSample01.Droid
{
	[ViewType(typeof(MyTestPage))]
	public class MyTest2ViewModel : XLabs.Forms.Mvvm.ViewModel, ITest2ViewModel
	{
		public MyTest2ViewModel ()
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

	}
}


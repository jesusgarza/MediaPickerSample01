using System;
using Xamarin.Forms;

namespace MediaPickerSample01
{
	public interface ITest2ViewModel
	{
		string TextMessage
		{
			get;
			set;
		}

		Command CmdToVerifyIsWorking
		{
			get;
		}
	}
}


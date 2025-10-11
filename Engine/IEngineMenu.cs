using System;

namespace LunyScratch
{
	public interface IEngineMenu : IEngineUI
	{
		event Action<string> OnButtonClicked;
	}
}

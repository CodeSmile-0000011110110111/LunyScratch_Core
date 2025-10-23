using System;

namespace LunyScratch
{
	public interface IEngineMenu : IEngineUI
	{
		event Action<string> OnButtonClicked;
		void RegisterEventHandler(String widgetName);
		void UnregisterEventHandler(String widgetName);
	}
}

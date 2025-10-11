using System;

namespace LunyScratch
{
	/// <summary>
	/// Event that becomes true once when a menu button with the given name is clicked.
	/// Uses the engine-agnostic IEngineMenu.OnButtonClicked event.
	/// </summary>
	public sealed class ButtonClickedEventBlock : EventBlock
	{
		private readonly string _buttonName;
		private bool _subscribed;
		private bool _matched;

		public ButtonClickedEventBlock(string buttonName)
		{
			_buttonName = buttonName;
		}

		private void EnsureSubscribed(IEngineMenu menu)
		{
			if (_subscribed || menu == null)
				return;
			menu.OnButtonClicked += OnMenuButtonClicked;
			_subscribed = true;
		}

		private void OnMenuButtonClicked(string name)
		{
			if (string.Equals(name, _buttonName, StringComparison.InvariantCulture))
				_matched = true;
		}

		internal override bool Evaluate(IScratchContext context)
		{
			var menu = context?.GetEngineMenu();
			EnsureSubscribed(menu);
			if (_matched)
			{
				_matched = false; // consume edge
				return true;
			}
			return false;
		}
	}
}

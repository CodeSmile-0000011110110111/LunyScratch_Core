using System;

namespace LunyScratch
{
	/// <summary>
	/// Hides the Menu via engine-agnostic UI.
	/// </summary>
	internal sealed class HideMenuBlock : IScratchBlock
	{
		public void OnEnter() {}
		public void OnExit() {}
		public Boolean IsComplete() => true;

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			var ui = context?.GetEngineMenu();
			ui?.Hide();
		}
	}
}

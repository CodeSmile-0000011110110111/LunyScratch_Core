using System;

namespace LunyScratch
{
	/// <summary>
	/// Hides the HUD via engine-agnostic UI.
	/// </summary>
	internal sealed class HideHUDBlock : IScratchBlock
	{
		public void OnEnter() {}
		public void OnExit() {}
		public bool IsComplete() => true;
		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			var ui = context?.GetEngineHUD();
			ui?.Hide();
		}
	}
}

using System;

namespace LunyScratch
{
	/// <summary>
	/// Shows the HUD via engine-agnostic UI.
	/// </summary>
	internal sealed class ShowHUDBlock : IScratchBlock
	{
		public void OnEnter() {}
		public void OnExit() {}
		public bool IsComplete() => true;
		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			var ui = context?.GetEngineHUD();
			ui?.Show();
		}
	}
}

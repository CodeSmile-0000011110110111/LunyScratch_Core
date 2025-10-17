using System;

namespace LunyScratch
{
	/// <summary>
	/// Engine-agnostic UI surface for common HUD/Menu controls.
	/// Implemented by engine adapters to map to actual UI.
	/// </summary>
	public interface IEngineUI
	{
		void Show();
		void Hide();
		void BindVariable(Variable variable);
	}
}

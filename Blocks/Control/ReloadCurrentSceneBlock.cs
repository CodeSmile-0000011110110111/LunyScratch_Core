using System;

namespace LunyScratch
{
	/// <summary>
	/// Reloads the current active scene immediately via engine actions.
	/// </summary>
	internal sealed class ReloadCurrentSceneBlock : IScratchBlock
	{
		public void OnEnter() {}
		public void OnExit() {}
		public bool IsComplete() => true;
		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			GameEngine.Actions.ReloadCurrentScene();
		}
	}

	/// <summary>
	/// Quits the application via engine actions; in the editor, exits play mode instead.
	/// </summary>
	internal sealed class QuitApplicationBlock : IScratchBlock
	{
		public void OnEnter() {}
		public void OnExit() {}
		public bool IsComplete() => true;
		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			GameEngine.Actions.QuitApplication();
		}
	}
}

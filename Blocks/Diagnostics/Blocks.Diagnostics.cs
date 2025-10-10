using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock Log(String message) => new ExecuteBlock(() => GameEngine.Actions.LogInfo(message));
		public static IScratchBlock LogWarn(String message) => new ExecuteBlock(() => GameEngine.Actions.LogWarn(message));
		public static IScratchBlock LogError(String message) => new ExecuteBlock(() => GameEngine.Actions.LogError(message));
	}
}

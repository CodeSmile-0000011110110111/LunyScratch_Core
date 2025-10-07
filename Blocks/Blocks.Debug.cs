using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock Log(String message) => new ExecuteBlock(() => GameEngine.Actions.Log(message));


		// KEYBOARD INPUT

		// MOUSE INPUT
	}
}

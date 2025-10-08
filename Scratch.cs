using System;

namespace LunyScratch
{
	/// <summary>
	/// Global static API for running Scratch blocks without GameObject context.
	/// All methods delegate to the global runtime instance.
	/// </summary>
	public static class Scratch
	{
		public static void Run(params IScratchBlock[] blocks) => GameEngine.Runtime.Run(blocks);

		public static void RunPhysics(params IScratchBlock[] blocks) => GameEngine.Runtime.RunPhysics(blocks);

		public static void RepeatForever(params IScratchBlock[] blocks) => GameEngine.Runtime.RepeatForever(blocks);

		public static void RepeatForever(Action block) => RepeatForever(new ExecuteBlock(block));

		public static void RepeatForeverPhysics(params IScratchBlock[] blocks) => GameEngine.Runtime.RepeatForeverPhysics(blocks);

		// public static void RepeatWhileTrue(Func<Boolean> condition, params IScratchBlock[] blocks) =>
		// 	GameEngine.Runtime.RepeatWhileTrue(condition, blocks);
		//
		// public static void RepeatUntilTrue(Func<Boolean> condition, params IScratchBlock[] blocks) =>
		// 	GameEngine.Runtime.RepeatUntilTrue(condition, blocks);

		public static void When(Func<Boolean> condition, params IScratchBlock[] blocks) =>
			GameEngine.Runtime.When(condition, blocks);
	}
}

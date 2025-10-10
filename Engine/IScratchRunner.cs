namespace LunyScratch
{
	/// <summary>
	/// Defines the contract for running Scratch blocks.
	/// Implemented by both static (global) and instance (local) contexts.
	/// </summary>
	public interface IScratchRunner
	{
		void Run(params IScratchBlock[] blocks);
		void RunPhysics(params IScratchBlock[] blocks);
		void RepeatForever(params IScratchBlock[] blocks);

		void RepeatForeverPhysics(params IScratchBlock[] blocks);

		// void RepeatWhileTrue(Func<Boolean> condition, params IScratchBlock[] blocks);
		// void RepeatUntilTrue(Func<Boolean> condition, params IScratchBlock[] blocks);
		// void When(Func<Boolean> condition, params IScratchBlock[] blocks);
		void When(EventBlock evt, params IScratchBlock[] blocks);

		Table Variables { get; }
	}
}

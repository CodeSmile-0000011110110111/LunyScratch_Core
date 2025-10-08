using System;
using System.Collections.Generic;

namespace LunyScratch
{
	/// <summary>
	/// Manages block execution with separate runners for regular and physics updates.
	/// </summary>
	public sealed class BlockRunner
	{
		private readonly List<IScratchBlock> _blocks = new();
		private readonly List<IScratchBlock> _physicsBlocks = new();

		public void ProcessUpdate(Double deltaTimeInSeconds) => ProcessBlocks(_blocks, deltaTimeInSeconds);

		public void ProcessPhysicsUpdate(Double fixedDeltaTimeInSeconds) => ProcessBlocks(_physicsBlocks, fixedDeltaTimeInSeconds);

		public void Dispose()
		{
			_blocks.Clear();
			_physicsBlocks.Clear();
		}

		// Execution methods
		public void Run(params IScratchBlock[] blocks) => AddBlock(new SequenceBlock(blocks));

		public void RunPhysics(params IScratchBlock[] blocks) => AddPhysicsBlock(new SequenceBlock(blocks));

		public void RepeatForever(params IScratchBlock[] blocks) => AddBlock(new RepeatForeverBlock(blocks));

		public void RepeatForeverPhysics(params IScratchBlock[] blocks) => AddPhysicsBlock(new RepeatForeverBlock(blocks));

		public void RepeatWhileTrue(Func<Boolean> condition, params IScratchBlock[] blocks) =>
			AddBlock(new RepeatWhileTrueBlock(condition, blocks));

		public void RepeatUntilTrue(Func<Boolean> condition, params IScratchBlock[] blocks) =>
			AddBlock(new RepeatUntilTrueBlock(condition, blocks));

		// Direct block adding (for IEngineRuntime interface)
		public void AddBlock(IScratchBlock block)
		{
			block.OnEnter();
			_blocks.Add(block);
		}

		public void AddPhysicsBlock(IScratchBlock block)
		{
			block.OnEnter();
			_physicsBlocks.Add(block);
		}

		private static void ProcessBlocks(List<IScratchBlock> blocks, Double deltaTimeInSeconds)
		{
			// Execute all active blocks
			for (var i = blocks.Count - 1; i >= 0; i--)
			{
				var block = blocks[i];
				block.Run(deltaTimeInSeconds);

				if (block.IsComplete())
				{
					block.OnExit();
					blocks.RemoveAt(i);
				}
			}
		}
	}
}

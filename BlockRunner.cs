using System;
using System.Collections.Generic;

namespace LunyScratch
{
	/// <summary>
	/// Manages block execution with separate runners for regular and physics updates.
	/// Injects context into blocks during execution.
	/// </summary>
	internal sealed class BlockRunner
	{
		private readonly IScratchContext _context;
		private readonly List<IScratchBlock> _blocks = new();
		private readonly List<IScratchBlock> _physicsBlocks = new();

		internal BlockRunner(IScratchContext context) => _context = context;

		internal void ProcessUpdate(Double deltaTimeInSeconds) => ProcessBlocks(_blocks, deltaTimeInSeconds);

		internal void ProcessPhysicsUpdate(Double fixedDeltaTimeInSeconds) => ProcessBlocks(_physicsBlocks, fixedDeltaTimeInSeconds);

		internal void Dispose()
		{
			_blocks.Clear();
			_physicsBlocks.Clear();
		}

		internal void AddBlock(IScratchBlock block)
		{
			block.OnEnter();
			_blocks.Add(block);
		}

		internal void AddPhysicsBlock(IScratchBlock block)
		{
			block.OnEnter();
			_physicsBlocks.Add(block);
		}

		private void ProcessBlocks(List<IScratchBlock> blocks, Double deltaTimeInSeconds)
		{
			// Execute all active blocks, injecting context
			for (var i = blocks.Count - 1; i >= 0; i--)
			{
				var block = blocks[i];
				block.Run(_context, deltaTimeInSeconds);

				if (block.IsComplete())
				{
					block.OnExit();
					blocks.RemoveAt(i);
				}
			}
		}
	}
}

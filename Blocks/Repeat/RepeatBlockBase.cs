using log4net.Appender;
using System;
using System.Collections.Generic;

namespace LunyScratch
{
	// Base class for repeating block sequences
	internal abstract class RepeatBlockBase : IScratchBlock
	{
		protected readonly List<IScratchBlock> _blocks;
		protected readonly ConditionBlock _conditionBlock;
		protected Int32 _currentIndex;
		protected Boolean _shouldExit;
		
		protected RepeatBlockBase(ConditionBlock conditionBlock, List<IScratchBlock> blocks)
		{
			_conditionBlock = conditionBlock;
			_blocks = blocks;
		}
		
		protected RepeatBlockBase(ConditionBlock conditionBlock, params IScratchBlock[] blocks)
		{
			_conditionBlock = conditionBlock;
			_blocks = new List<IScratchBlock>(blocks);
		}
		
		public void OnEnter()
		{
			_currentIndex = 0;
			_shouldExit = false;
			_entered = false;
			// Defer condition evaluation until Run where context is available
		}
		
		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			if (_shouldExit || _blocks.Count == 0) return;

			// At the start of each iteration (when entering first block), check exit condition
			if (_currentIndex == 0 && ShouldExitLoop(context))
			{
				_shouldExit = true;
				return;
			}
			
			// Process current block only; do not spin multiple iterations within the same frame.
			var currentBlock = _blocks[_currentIndex];
			
			// Ensure first enter for current block
			if (!_entered)
			{
				currentBlock.OnEnter();
				_entered = true;
			}
			
			currentBlock.Run(context, deltaTimeInSeconds);
			
			if (!currentBlock.IsComplete())
				return; // wait until next frame
			
			currentBlock.OnExit();
			_currentIndex++;
			
			// Completed all blocks in the sequence for this iteration
			if (_currentIndex >= _blocks.Count)
			{
				// Evaluate exit condition at the end of the iteration
				if (ShouldExitLoop(context))
				{
					_shouldExit = true;
					return;
				}
				
				// Loop back to the beginning but yield to next frame before continuing
				_currentIndex = 0;
				_entered = false;
				return;
			}
			
			// Prepare to enter the next block on the following Run
			_entered = false; // so that the next Run calls OnEnter for the new current block
		}
		
		public void OnExit()
		{
			if (_blocks.Count > 0 && _currentIndex < _blocks.Count && _entered)
				_blocks[_currentIndex].OnExit();
		}
		
		public Boolean IsComplete() => _shouldExit;
		
		// Override this to define when the loop should exit
		protected abstract Boolean ShouldExitLoop(IScratchContext context);
		protected Boolean EvaluateCondition(IScratchContext context) => _conditionBlock.Evaluate(context);
		
		private Boolean _entered;
	}
}

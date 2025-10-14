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
			
			var currentBlock = _blocks[_currentIndex];
			// Ensure OnEnter has been called for the first block
			if (deltaTimeInSeconds >= 0 && currentBlock != null && _currentIndex == 0 && !_entered)
			{
				currentBlock.OnEnter();
				_entered = true;
			}
			currentBlock.Run(context, deltaTimeInSeconds);
			
			if (currentBlock.IsComplete())
			{
				currentBlock.OnExit();
				_currentIndex++;
				
				// Check if we've completed all blocks in the sequence
				if (_currentIndex >= _blocks.Count)
				{
					// Check exit condition AFTER completing all blocks
					if (ShouldExitLoop(context))
					{
						_shouldExit = true;
						return;
					}
					
					// Loop back to the beginning
					_currentIndex = 0;
				}
				
				_blocks[_currentIndex].OnEnter();
			}
		}
		
		public void OnExit()
		{
			if (_blocks.Count > 0 && _currentIndex < _blocks.Count)
				_blocks[_currentIndex].OnExit();
		}
		
		public Boolean IsComplete() => _shouldExit;
		
		// Override this to define when the loop should exit
		protected abstract Boolean ShouldExitLoop(IScratchContext context);
		protected Boolean EvaluateCondition(IScratchContext context) => _conditionBlock.Evaluate(context);
		
		private Boolean _entered;
	}
}

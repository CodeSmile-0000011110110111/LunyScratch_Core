using System;
using System.Collections.Generic;

namespace LunyScratch
{
	public sealed class IfBlock : IScratchBlock
	{
		private readonly ConditionBlock _conditionBlock;
		private readonly List<IScratchBlock> _thenBlocks;
		private readonly List<IScratchBlock> _elseBlocks;
		private List<IScratchBlock> _currentBlocks;
		private Int32 _currentIndex;
		private Boolean _completed;

		public IfBlock(Func<Boolean> condition, List<IScratchBlock> thenBlocks)
		{
			_conditionBlock = new ConditionBlock(condition);
			_thenBlocks = thenBlocks;
			_elseBlocks = new List<IScratchBlock>();
			_currentIndex = 0;
			_completed = false;
		}

		public IfBlock(ConditionBlock condition, List<IScratchBlock> thenBlocks)
		{
			_conditionBlock = condition;
			_thenBlocks = thenBlocks;
			_elseBlocks = new List<IScratchBlock>();
			_currentIndex = 0;
			_completed = false;
		}

		public void OnEnter()
		{
			_currentIndex = 0;
			_completed = false;

			// Evaluate condition and choose which blocks to execute
			_currentBlocks = _conditionBlock.Evaluate() ? _thenBlocks : _elseBlocks;

			// If we have blocks to execute, enter the first one
			if (_currentBlocks.Count > 0)
				_currentBlocks[0].OnEnter();
			else
				_completed = true; // No blocks to execute
		}

		public void Run(Double deltaTimeInSeconds)
		{
			if (_completed || _currentBlocks.Count == 0) return;

			var currentBlock = _currentBlocks[_currentIndex];
			currentBlock.Run(deltaTimeInSeconds);

			if (currentBlock.IsComplete())
			{
				currentBlock.OnExit();
				_currentIndex++;

				// Check if we've completed all blocks
				if (_currentIndex >= _currentBlocks.Count)
				{
					_completed = true;
					return;
				}

				// Enter the next block
				_currentBlocks[_currentIndex].OnEnter();
			}
		}

		public void OnExit()
		{
			if (_currentBlocks != null && _currentIndex < _currentBlocks.Count)
				_currentBlocks[_currentIndex].OnExit();
		}

		public Boolean IsComplete() => _completed;

		public IfBlock Else(params IScratchBlock[] blocks)
		{
			_elseBlocks.AddRange(blocks);
			return this;
		}
	}
}

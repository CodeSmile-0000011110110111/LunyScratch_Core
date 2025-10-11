using System;
using System.Linq;

namespace LunyScratch
{
	public sealed class IfBlock : IScratchBlock
	{
		private readonly ConditionBlock _conditionBlock;
		private readonly IScratchBlock[] _thenBlocks;
		private IScratchBlock[] _elseBlocks;
		private IScratchBlock[] _currentBlocks;
		private Int32 _currentIndex;
		private Boolean _completed;

		public IfBlock(Func<Boolean> condition, params IScratchBlock[] thenBlocks)
		{
			_conditionBlock = new ConditionBlock(condition);
			_thenBlocks = thenBlocks ?? Array.Empty<IScratchBlock>();
			_elseBlocks = Array.Empty<IScratchBlock>();
			_currentIndex = 0;
			_completed = false;
		}

		public IfBlock(ConditionBlock condition, params IScratchBlock[] thenBlocks)
		{
			_conditionBlock = condition;
			_thenBlocks = thenBlocks ?? Array.Empty<IScratchBlock>();
			_elseBlocks = Array.Empty<IScratchBlock>();
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
			if (_currentBlocks.Length > 0)
				_currentBlocks[0].OnEnter();
			else
				_completed = true; // No blocks to execute
		}

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			if (_completed || _currentBlocks.Length == 0) return;

			var currentBlock = _currentBlocks[_currentIndex];
			currentBlock.Run(context, deltaTimeInSeconds);

			if (currentBlock.IsComplete())
			{
				currentBlock.OnExit();
				_currentIndex++;

				// Check if we've completed all blocks
				if (_currentIndex >= _currentBlocks.Length)
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
			if (_currentBlocks != null && _currentIndex < _currentBlocks.Length)
				_currentBlocks[_currentIndex].OnExit();
		}

		public Boolean IsComplete() => _completed;

		public IfBlock Else(params IScratchBlock[] blocks)
		{
			if (blocks == null || blocks.Length == 0) return this;
			_elseBlocks = _elseBlocks == null || _elseBlocks.Length == 0
				? blocks
				: _elseBlocks.Concat(blocks).ToArray();
			return this;
		}
	}
}

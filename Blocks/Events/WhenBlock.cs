using System;
using System.Collections.Generic;

namespace LunyScratch
{
	/// <summary>
	/// Event-like block that waits for a condition to become true once, then runs a sequence of blocks and completes.
	/// Edge-triggered, one-shot: it starts the sequence on the first frame the condition evaluates to true.
	/// </summary>
	internal sealed class WhenBlock : IScratchBlock
	{
		private readonly Func<Boolean> _condition;
		private readonly List<IScratchBlock> _blocks;
		private Boolean _triggered;
		private Boolean _completed;
		private SequenceBlock _sequence;

		public WhenBlock(Func<Boolean> condition, params IScratchBlock[] blocks)
		{
			_condition = condition ?? throw new ArgumentNullException(nameof(condition));
			_blocks = new List<IScratchBlock>(blocks ?? Array.Empty<IScratchBlock>());
			_triggered = false;
			_completed = false;
		}

		public void OnEnter()
		{
			_triggered = false;
			_completed = false;
			_sequence = null;
		}

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			if (_completed)
				return;

			if (!_triggered)
			{
				if (_condition())
				{
					_triggered = true;
					if (_blocks.Count == 0)
					{
						_completed = true;
						return;
					}

					_sequence = new SequenceBlock(_blocks);
					_sequence.OnEnter();
				}
				else
				{
					return;
				}
			}

			// Run the child sequence until completion
			_sequence?.Run(context, deltaTimeInSeconds);
			if (_sequence != null && _sequence.IsComplete())
			{
				_sequence.OnExit();
				_completed = true;
			}
		}

		public void OnExit()
		{
			if (_sequence != null && !_sequence.IsComplete())
			{
				_sequence.OnExit();
			}
		}

		public Boolean IsComplete() => _completed;
	}
}

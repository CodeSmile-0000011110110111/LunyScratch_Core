using System;
using System.Collections.Generic;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock Sequence(params IScratchBlock[] blocks) => new SequenceBlock(blocks);
		public static IScratchBlock Enable(String childName) => new EnableByNameBlock(childName);
		public static IScratchBlock Disable(String childName) => new DisableByNameBlock(childName);

		private sealed class EnableByNameBlock : IScratchBlock
		{
			private readonly String _childName;

			public EnableByNameBlock(String childName) => _childName = childName;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var child = context?.FindChild(_childName);
				child?.SetEnabled(true);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class DisableByNameBlock : IScratchBlock
		{
			private readonly String _childName;

			public DisableByNameBlock(String childName) => _childName = childName;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var child = context?.FindChild(_childName);
				child?.SetEnabled(false);
			}

			public Boolean IsComplete() => true;
		}

		// One-shot event block implementation lives here to keep Core engine-agnostic
		private sealed class WhenOnceBlock : IScratchBlock
		{
			private readonly Func<Boolean> _condition;
			private readonly List<IScratchBlock> _blocks;
			private Boolean _triggered;
			private Boolean _completed;
			private SequenceBlock _sequence;

			public WhenOnceBlock(Func<Boolean> condition, params IScratchBlock[] blocks)
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
}

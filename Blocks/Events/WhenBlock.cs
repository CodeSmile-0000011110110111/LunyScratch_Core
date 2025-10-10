using System;

namespace LunyScratch
{
	internal sealed class WhenBlock : IScratchBlock
	{
		private readonly EventBlock _event;
		private readonly SequenceBlock _sequence;
		private Boolean _triggered;

		public WhenBlock(EventBlock evt, params IScratchBlock[] blocks)
		{
			_event = evt ?? throw new ArgumentNullException(nameof(evt));
			_sequence = new SequenceBlock(blocks);
		}

		public void OnEnter()
		{
			_triggered = false;
			_event.OnEnter();
		}

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			// If we are not currently running the sequence, listen for the event
			if (!_triggered)
			{
				_event.Run(context, deltaTimeInSeconds);
				if (!_event.IsComplete())
					return;

				_triggered = true;
				_sequence.OnEnter(); // keep waiting for the event
			}

			// Run the active sequence
			_sequence.Run(context, deltaTimeInSeconds);
			if (_sequence.IsComplete())
			{
				_sequence.OnExit();
				// Re-arm for the next event occurrence
				_triggered = false;
				_event.OnEnter();
			}
		}

		public void OnExit()
		{
			if (!_sequence.IsComplete())
				_sequence.OnExit();
		}

		// This block never completes; it keeps listening for events and triggering the sequence
		public Boolean IsComplete() => false;
	}
}

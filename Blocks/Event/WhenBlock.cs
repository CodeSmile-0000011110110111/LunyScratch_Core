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
			
			// Run the active sequence and allow intra-frame progression while there is progress
			const Int32 MaxStepsPerFrame = 4096; // safety to avoid infinite tight loops within event sequence
			Int32 steps = 0;
			while (true)
			{
				var progressBefore = _sequence.ProgressVersion;
				_sequence.Run(context, deltaTimeInSeconds);
				var progressAfter = _sequence.ProgressVersion;
				
				if (_sequence.IsComplete())
				{
					_sequence.OnExit();
					// Re-arm for the next event occurrence
					_triggered = false;
					_event.OnEnter();
					return; // handled this event fully this frame
				}
				
				// If no progress was made, current inner block yielded; defer to next frame
				if (progressAfter == progressBefore)
					break;
				
				steps++;
				if (steps >= MaxStepsPerFrame)
				{
					GameEngine.Actions.LogWarn("When sequence exceeded maximum steps per frame");
					break;
				}
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

using System;

namespace LunyScratch
{
	/// <summary>
	/// Engine-agnostic event primitive similar to ConditionBlock, but evaluated against the execution context.
	/// Implementations should return true from Consume(context) exactly once per event occurrence and reset internally thereafter.
	/// </summary>
	public abstract class EventBlock : IScratchBlock
	{
		private Boolean _wasConsumed;

		public void OnEnter() => _wasConsumed = false;

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			if (_wasConsumed) return;

			_wasConsumed = Evaluate(context);
		}

		public Boolean IsComplete() => _wasConsumed;

		/// <summary>
		/// Checks if the event occurred and consumes it (edge). Should return true once per occurrence.
		/// </summary>
		internal abstract Boolean Evaluate(IScratchContext context);
	}
}

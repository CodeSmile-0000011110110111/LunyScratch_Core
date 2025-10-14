using System;

namespace LunyScratch
{
	// Conditional step (checks condition before proceeding)
	public class ConditionBlock : IScratchBlock
	{
		private readonly Func<IScratchContext, Boolean> _condition;
		private Boolean _result;

		public ConditionBlock(Func<Boolean> condition)
		{
			_condition = _ => condition();
			_result = false;
		}

		public ConditionBlock(Func<IScratchContext, Boolean> condition)
		{
			_condition = condition;
			_result = false;
		}

		public void Run(IScratchContext context, Double deltaTimeInSeconds) => _result = _condition(context);

		public Boolean IsComplete() => _result;

		internal Boolean Evaluate(IScratchContext context) => _condition(context);
	}
}

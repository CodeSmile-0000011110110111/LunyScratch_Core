using System;
using System.Collections.Generic;

namespace LunyScratch
{
	// Dedicated OR condition supporting short-circuit evaluation
	internal sealed class OrConditionBlock : ConditionBlock
	{
		private static Func<IScratchContext, Boolean> BuildEvaluator(List<ConditionBlock> conditions) => context =>
		{
			// Identity for empty set is false
			if (conditions == null || conditions.Count == 0)
				return false;

			for (var i = 0; i < conditions.Count; i++)
			{
				if (conditions[i].Evaluate(context))
					return true; // short-circuit on first true
			}
			return false;
		};

		public OrConditionBlock(List<ConditionBlock> conditions)
			: base(BuildEvaluator(conditions)) {}

		public OrConditionBlock(params ConditionBlock[] conditions)
			: base(BuildEvaluator(conditions != null ? new List<ConditionBlock>(conditions) : new List<ConditionBlock>())) {}
	}
}

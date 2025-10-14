using System;
using System.Collections.Generic;

namespace LunyScratch
{
	// Dedicated XOR condition: true if an odd number of conditions are true
	internal sealed class XorConditionBlock : ConditionBlock
	{
		private static Func<IScratchContext, Boolean> BuildEvaluator(List<ConditionBlock> conditions) => context =>
		{
			if (conditions == null || conditions.Count == 0)
				return false; // identity for XOR with no operands

			var result = false;
			for (var i = 0; i < conditions.Count; i++)
			{
				if (conditions[i].Evaluate(context))
					result = !result; // toggle on each true
			}
			return result;
		};

		public XorConditionBlock(List<ConditionBlock> conditions)
			: base(BuildEvaluator(conditions)) {}

		public XorConditionBlock(params ConditionBlock[] conditions)
			: base(BuildEvaluator(conditions != null ? new List<ConditionBlock>(conditions) : new List<ConditionBlock>())) {}
	}
}

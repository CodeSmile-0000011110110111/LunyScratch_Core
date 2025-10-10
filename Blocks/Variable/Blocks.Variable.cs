using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		/// <summary>
		/// Sets a variable by name to the provided value. Creates the variable if it does not exist.
		/// </summary>
		public static IScratchBlock SetVariable(String name, Variable value) => new SetVariableBlock(name, value);

		/// <summary>
		/// Increments a numeric variable by 1. Creates the variable if it does not exist.
		/// </summary>
		public static IScratchBlock IncrementVariable(String name) => new IncrementVariableBlock(name, new Variable(1.0));

		/// <summary>
		/// Increments a numeric variable by the provided value's numeric form. Creates the variable if it does not exist.
		/// </summary>
		public static IScratchBlock IncrementVariable(String name, Variable value) => new IncrementVariableBlock(name, value);

		/// <summary>
		/// Changes a numeric variable by the given delta. Creates the variable if it does not exist.
		/// </summary>
		public static IScratchBlock ChangeVariable(String name, Variable initialValue, Double changeValue) => new ChangeVariableBlock(name, initialValue, changeValue);
	}
}

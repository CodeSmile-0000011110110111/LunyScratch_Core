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
		/// Adds the specified amount to a named variable. Creates the variable if it does not exist.
		/// Uses Table.AddValue for numeric safety and logging.
		/// </summary>
		public static IScratchBlock AddVariable(String name, Double amount) => new AddVariableBlock(name, amount);

		/// <summary>
		/// Increments a numeric variable by 1. Creates the variable if it does not exist.
		/// </summary>
		public static IScratchBlock IncrementVariable(String name) => new AddVariableBlock(name, 1.0);

		/// <summary>
		/// Decrements a numeric variable by 1. Creates the variable if it does not exist.
		/// </summary>
		public static IScratchBlock DecrementVariable(String name) => new SubtractVariableBlock(name, 1.0);

	}
}

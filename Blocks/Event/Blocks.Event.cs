using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		/// <summary>
		/// Creates an event-style block that waits until the given condition becomes true, then runs the provided blocks once.
		/// One-shot edge-triggered.
		/// </summary>
		//public static IScratchBlock When(Func<Boolean> condition, params IScratchBlock[] blocks) => new WhenBlock(condition, blocks);

		/// <summary>
		/// Creates an event-style block that waits until the given event is consumed, then runs the provided blocks once.
		/// </summary>
		public static IScratchBlock When(EventBlock evt, params IScratchBlock[] blocks) => new WhenBlock(evt, blocks);

		/// <summary>
		/// Creates a CollisionEnter event provider.
		/// </summary>
		public static EventBlock CollisionEnter(String name = null, String tag = null) => new CollisionEnterEventBlock(name, tag);
		/// <summary>
		/// Creates a ButtonClicked event provider for a given menu button name.
		/// </summary>
		public static EventBlock ButtonClicked(String buttonName) => new ButtonClickedEventBlock(buttonName);
	}
}

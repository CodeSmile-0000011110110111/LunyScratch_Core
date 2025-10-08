namespace LunyScratch
{
	public static partial class Blocks
	{
		/// <summary>
		/// Returns a condition that checks if the key is held down.
		/// </summary>
		public static ConditionBlock IsKeyPressed(Key key) => new(() => GameEngine.Actions.IsKeyPressed(key));

		/// <summary>
		/// Returns a condition that checks if the key was just pressed this frame.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static ConditionBlock IsKeyJustPressed(Key key) => new(() => GameEngine.Actions.IsKeyJustPressed(key));

		/// <summary>
		/// Returns a condition that checks if the key was just released this frame.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static ConditionBlock IsKeyJustReleased(Key key) => new(() => GameEngine.Actions.IsKeyJustReleased(key));

		/// <summary>
		/// Returns a condition that checks if the mouse button is held down.
		/// </summary>
		public static ConditionBlock IsMouseButtonPressed(MouseButton button) => new(() => GameEngine.Actions.IsMouseButtonPressed(button));

		/// <summary>
		/// Returns a condition that checks if the mouse button was just pressed this frame.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static ConditionBlock IsMouseButtonJustPressed(MouseButton button) =>
			new(() => GameEngine.Actions.IsMouseButtonJustPressed(button));

		/// <summary>
		/// Returns a condition that checks if the mouse button was just released this frame.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static ConditionBlock IsMouseButtonJustReleased(MouseButton button) =>
			new(() => GameEngine.Actions.IsMouseButtonJustReleased(button));
	}
}

using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		/// <summary>
		/// Returns true while the key is held down.
		/// </summary>
		public static Boolean IsKeyPressed(Key key) => GameEngine.Actions.IsKeyPressed(key);

		/// <summary>
		/// Returns true on the frame the key was pressed down.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static Boolean IsKeyJustPressed(Key key) => GameEngine.Actions.IsKeyJustPressed(key);

		/// <summary>
		/// Returns true on the frame the key was released.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static Boolean IsKeyJustReleased(Key key) => GameEngine.Actions.IsKeyJustReleased(key);

		/// <summary>
		/// Returns true while the mouse button is held down.
		/// </summary>
		public static Boolean IsMouseButtonPressed(MouseButton button) => GameEngine.Actions.IsMouseButtonPressed(button);

		/// <summary>
		/// Returns true on the frame the mouse button was pressed down.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static Boolean IsMouseButtonJustPressed(MouseButton button) => GameEngine.Actions.IsMouseButtonJustPressed(button);

		/// <summary>
		/// Returns true on the frame the mouse button was released.
		/// </summary>
		/// <remarks>
		/// This will only be true for one frame. For this reason it should not be used in fixed step (physics) update.
		/// </remarks>
		public static Boolean IsMouseButtonJustReleased(MouseButton button) => GameEngine.Actions.IsMouseButtonJustReleased(button);
	}
}

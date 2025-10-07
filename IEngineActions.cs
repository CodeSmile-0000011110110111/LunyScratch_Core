using System;

namespace LunyScratch
{
	internal interface IEngineActions
	{
		// DEBUG
		void Log(String message);

		// LOOKS
		void ShowMessage(String message, Double duration);

		// SOUND
		void PlaySound(String soundName, Double volume);

		// TIME
		Double GetDeltaTimeInSeconds();
		Double GetCurrentTimeInSeconds();

		// INPUT - KEYBOARD
		Boolean IsKeyPressed(Key key);
		Boolean IsKeyJustPressed(Key key);
		Boolean IsKeyJustReleased(Key key);

		// INPUT - MOUSE
		Boolean IsMouseButtonPressed(MouseButton button);
		Boolean IsMouseButtonJustPressed(MouseButton button);
		Boolean IsMouseButtonJustReleased(MouseButton button);
	}
}

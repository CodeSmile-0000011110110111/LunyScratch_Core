using System;

namespace LunyScratch
{
	public interface IEngineObject
	{
		void SetEnabled(Boolean enabled);
		//void ScheduleDestroy(Double delayInSeconds);

		T GetEngineObject<T>() where T : class;
	}
}

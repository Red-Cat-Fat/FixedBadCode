using System;

namespace Infrastructure.Service.LoadLevels
{
	public interface ILoadLevelService
	{
		void Load(string name, Action onLoadLevel);
	}
}
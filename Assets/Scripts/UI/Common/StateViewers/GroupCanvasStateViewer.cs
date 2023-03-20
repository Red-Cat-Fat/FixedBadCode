using UnityEngine;

namespace UI.Common.StateViewers
{
	public class GroupCanvasStateViewer : MonoBehaviour, IStateViewer
	{
		public CanvasGroup Group;

		public void Enable()
		{
			Group.alpha = 1;
		}

		public void Disable()
		{
			Group.alpha = 0;
		}
	}
}
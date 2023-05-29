using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Level
{
	public class LevelManager : MonoBehaviour
	{
		[SerializeField] private Level[] _levels;
		[SerializeField] private LevelButton[] _levelButtons;

		
		[Button]
		public void FindButtons()
		{
			_levelButtons = FindObjectsOfType<LevelButton>();
		}
	}
}
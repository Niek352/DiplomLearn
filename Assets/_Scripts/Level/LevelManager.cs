using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Level
{
	public class LevelManager : MonoBehaviour
	{
		[SerializeField] private LevelButton _levelButtonPrefab;
		[SerializeField] private Level[] _levels;
		[SerializeField] private LevelButton[] _levelButtons;
		[SerializeField] private List<Transform> _buttonSocket;
		
 		private void Awake()
        {
	        _levelButtons = new LevelButton[_levels.Length];
	        for (var i = 0; i < _levels.Length; i++)
	        {
		        var level = _levels[i];
		        var button = Instantiate(_levelButtonPrefab, _buttonSocket[i]);
		        _levelButtons[i] = button;
		        button.SetUp(level, i + 1, null);
	        }
        }

		[Button]
		public void FindButtons()
		{
			_levelButtons = FindObjectsOfType<LevelButton>();
		}

		[Button]
		public void Sort()
		{
			var sorted = _buttonSocket.OrderBy(transform1 => transform1.position.y).ToList();
			for (int i = 0; i < sorted.Count; i++)
			{
				sorted[i].SetSiblingIndex(i);
			}
			_buttonSocket = sorted;
		}
	}
}
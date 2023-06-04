using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Level
{
	public class LevelManager : MonoBehaviour
	{
		[SerializeField] private LevelController _levelController;
		[SerializeField] private LevelButton _levelButtonPrefab;
		[SerializeField, AssetList] private Level[] _levels;
		[SerializeField] private LevelButton[] _levelButtons;
		[SerializeField] private List<Transform> _buttonSocket;
		
		[Button]
		public void SetCompletedCount(int c)
		{
			PlayerPrefs.SetInt(COMPLETED_LEVEL_COUNT_KEY, c);
		}
		
		public const string COMPLETED_LEVEL_COUNT_KEY = "COMPLETED_LEVEL_COUNT";
 		private void Awake()
        {
	        _levelButtons = new LevelButton[_levels.Length];
	        var completedLevelCount = PlayerPrefs.GetInt(COMPLETED_LEVEL_COUNT_KEY, 0);
	        
	        for (var i = 0; i < _levels.Length; i++)
	        {
		        var level = _levels[i];
		        var button = Instantiate(_levelButtonPrefab, _buttonSocket[i]);
		        _levelButtons[i] = button;
		        button.SetUp(level, i + 1, _levelController, completedLevelCount >= i);
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
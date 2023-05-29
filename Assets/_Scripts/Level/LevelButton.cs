using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Level
{
	public class LevelButton : MonoBehaviour
	{
		public Button Button;
		[ReadOnly] public int LevelNumber;
		[ReadOnly] public Level Level;
		private LevelController _levelController;

		public void SetUp(
			Level level,
			int levelNumber,
			LevelController levelController)
		{
			_levelController = levelController;
			Level = level;
			LevelNumber = levelNumber;
		}
		
		private void Start()
		{
			Button.onClick.AddListener(Open);
		}

		public void Open()
		{
			_levelController.StartLevel(Level);
		}
	}

}
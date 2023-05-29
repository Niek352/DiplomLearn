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
		private LevelPanel _levelPanel;

		public void SetUp(
			Level level,
			int levelNumber,
			LevelPanel levelPanel)
		{
			_levelPanel = levelPanel;
			Level = level;
			LevelNumber = levelNumber;
		}
		
		private void Start()
		{
			Button.onClick.AddListener(Open);
		}

		public void Open()
		{
			_levelPanel.Show(LevelNumber);
		}
	}

}
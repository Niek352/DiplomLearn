using _Scripts.Sound;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Level
{
	public class LevelButton : MonoBehaviour
	{
		public Button Button;
		[ReadOnly] public int LevelNumber;
		[ReadOnly] public Level Level;
		[SerializeField] private TextMeshProUGUI _levelNumber;
		[SerializeField] private string _soundName;
		private LevelController _levelController;

		public void SetUp(
			Level level,
			int levelNumber,
			LevelController levelController)
		{
			_levelController = levelController;
			Level = level;
			LevelNumber = levelNumber;
			_levelNumber.text = levelNumber.ToString();
		}
		
		private void Start()
		{
			Button.onClick.AddListener(Open);
		}

		public void Open()
		{
			SoundManager.Instance.Play(_soundName);
			_levelController.StartLevel(Level);
		}
	}

}
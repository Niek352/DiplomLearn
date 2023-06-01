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
		[SerializeField] private bool _isUnlocked;
		[SerializeField] private GameObject _unlocked;
		[SerializeField] private GameObject _locked;
		
		private LevelController _levelController;

		public void SetUp(
			Level level,
			int levelNumber,
			LevelController levelController,
			bool isUnlocked)
		{
			_isUnlocked = isUnlocked;
			_levelController = levelController;
			Level = level;
			LevelNumber = levelNumber;
			_levelNumber.text = levelNumber.ToString();
			if (isUnlocked)
			{
				Unlock();
			}
			else
			{
				Lock();
			}
		}
		
		private void Start()
		{
			Button.onClick.AddListener(Open);
		}

		public void Unlock()
		{
			_isUnlocked = true;
			_locked.SetActive(false);
			_unlocked.SetActive(true);
		}

		public void Lock()
		{
			_isUnlocked = false;
			_unlocked.SetActive(false);
			_locked.SetActive(true);
		}
		
		public void Open()
		{
			if (!_isUnlocked)
			{
				return;
			}
			SoundManager.Instance.Play(_soundName);
			_levelController.StartLevel(Level);
		}
	}

}
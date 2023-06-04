using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Level
{
	public class EndLevelPopup : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private Button _nextLevel;
		[SerializeField] private Button _levels;

		private void Start()
		{
			_levels.onClick.AddListener(BackToLevels);
		}
		
		private void BackToLevels()
		{
			SceneManager.LoadScene("Scenes/Levels");
		}

		public void Show(bool isCorrect, string level)
		{
			gameObject.SetActive(true);
			if (isCorrect)
			{
				_text.text = string.Format(_text.text, level);
			}
		}
	}
}
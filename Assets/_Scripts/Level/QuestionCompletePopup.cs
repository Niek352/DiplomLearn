using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Level
{
	public class QuestionCompletePopup : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _completeQuest;
		[SerializeField] private Button _nextQuestion;
		[SerializeField] private Button _restart;
		[SerializeField] private Button _toMenu;
		[SerializeField] private Button _info;
		
		private LevelController _levelController;
		private string _url;
		
		public void SetUp(LevelController levelController)
		{
			_levelController = levelController;
			_info.onClick.AddListener(OpenInfo);
			_nextQuestion.onClick.AddListener(NextQuestion);
			_restart.onClick.AddListener(RestartLevel);
			_toMenu.onClick.AddListener(ToMenu);
		}
		
		private void ToMenu()
		{
			SceneManager.LoadScene("Scenes/Levels");
		}

		private void RestartLevel()
		{
			_levelController.RestartLevel();
			gameObject.SetActive(false);
		}

		private void NextQuestion()
		{
			_levelController.NextQuestion();
			gameObject.SetActive(false);
		}

		private void OpenInfo()
		{
			Application.OpenURL(_url);
		}

		public void Show(string url, bool isCorrect)
		{
			gameObject.SetActive(true);
			_info.gameObject.SetActive(true);
			_toMenu.gameObject.SetActive(true);
			
			_url = url;
			
			if (isCorrect)
			{
				_restart.gameObject.SetActive(false);
				_nextQuestion.gameObject.SetActive(true);
				_completeQuest.text = "Правильно";
			}
			else
			{
				_restart.gameObject.SetActive(true);
				_nextQuestion.gameObject.SetActive(false);
				_completeQuest.text = "Не правильно";
			}
		}
	}
}
using System;
using System.Collections.Generic;
using _Scripts.Factories;
using _Scripts.Level._Question;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Level
{
	public class LevelController : MonoBehaviour
	{
		[SerializeField] private Transform _levelViewHolder;
		[SerializeField] private AnswerViewFactory _answerViewFactory;
		[SerializeField] private QuestionViewFactory _questionViewFactory;
		[SerializeField] private Image _bg;
		[SerializeField] private EndLevelPopup _levelPopup;
		[SerializeField] private QuestionCompletePopup _questionCompletePopup;
		[SerializeField] [DisplayAsString] [GUIColor("green")] private string _answer;

		private readonly Queue<Question> _questions = new Queue<Question>();
		private QuestionView _questionView;
		private Level _currentLevel;
		private int _levelNumber;
		private Question _currentQuestion;

		private void Awake()
		{
			_questionCompletePopup.SetUp(this);
		}

		public void RestartLevel()
		{
			StartLevel(_currentLevel, _levelNumber);
		}

		public void StartLevel(Level level, int levelNumber)
		{
			_levelNumber = levelNumber;
			if (_questionView)
				Destroy(_questionView);
			
			_currentLevel = level;
			_bg.enabled = true;
			_questions.Clear();
			foreach (var question in level.Questions)
			{
				_questions.Enqueue(question);
			}
			
			StartQuestion(_questions.Dequeue());
		}
		
		public void StartQuestion(Question question)
		{
			_currentQuestion = question;
			_questionView = _questionViewFactory.Create(_levelViewHolder, question);
			var answerView = _answerViewFactory.Create(_questionView.AnswerRoot, question);
			_answer = question.Answer.Answer;
			_questionView.SetUp(question, answerView);
			answerView.CheckAnswer += CheckAnswer;
		}
		
		public void NextQuestion()
		{
			StartQuestion(_questions.Dequeue());
		}
		
		private void CheckAnswer(string obj)
		{
			var isCorrect = string.Equals(obj, _questionView.Question.Answer.Answer, StringComparison.CurrentCultureIgnoreCase);
			Debug.Log($"Your answer is {obj}, true ans is {_questionView.Question.Answer.Answer} is {isCorrect.ToString()}");
			
			_questionView.AnswerView.CheckAnswer -= CheckAnswer;
			Destroy(_questionView.gameObject);
			if (_questions.TryPeek(out var result))
			{
				_questionCompletePopup.Show(_currentQuestion.Url, isCorrect);
			}
			else
			{
				EndLevel();
			}
		}
		
		private void EndLevel()
		{
			OnEndLevel();
			_levelPopup.Show(true, _levelNumber.ToString());
		}
		
		private void OnEndLevel()
		{
			if (PlayerPrefs.GetInt(LevelManager.COMPLETED_LEVEL_COUNT_KEY, 0) < _levelNumber)
			{
				PlayerPrefs.SetInt(LevelManager.COMPLETED_LEVEL_COUNT_KEY, _levelNumber);
			}
		}
	}
}
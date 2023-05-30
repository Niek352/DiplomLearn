using System.Collections.Generic;
using _Scripts.Answer.View;
using _Scripts.Factories;
using _Scripts.Level._Question;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Level
{
	public class LevelController : MonoBehaviour
	{
		[SerializeField] private QuestionView _questionViewPrefab;
		[SerializeField] private Transform _levelViewHolder;
		[SerializeField] private AnswerViewFactory _answerViewFactory;
		[SerializeField] private QuestionViewFactory _questionViewFactory;
		[SerializeField] private Image _bg;
		private readonly Queue<Question> _questions = new Queue<Question>();

		private QuestionView _questionView;
		
		[SerializeField] [DisplayAsString] [GUIColor("green")] private string _answer;
		
		public void StartLevel(Level level)
		{
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
			_questionView = _questionViewFactory.Create(_levelViewHolder, question);
			var answerView = _answerViewFactory.Create(_questionView.AnswerRoot, question);
			_answer = question.Answer.Answer;
			_questionView.SetUp(question, answerView);
			answerView.CheckAnswer += CheckAnswer;
		}
		
		private void CheckAnswer(string obj)
		{
			var isCorrect = obj == _questionView.Question.Answer.Answer;
			Debug.Log($"Your answer is {obj}, true ans is {_questionView.Question.Answer.Answer} is {isCorrect.ToString()}");
			
			_questionView.AnswerView.CheckAnswer -= CheckAnswer;
			Destroy(_questionView.gameObject);
			if (_questions.TryDequeue(out var result))
			{
				StartQuestion(result);
			}
			else
			{
				EndLevel();
			}
		}
		
		private void EndLevel()
		{
			_bg.enabled = false;
		}
	}
}
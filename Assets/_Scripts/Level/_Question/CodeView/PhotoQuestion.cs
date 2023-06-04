using _Scripts.Answer.View;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Level._Question.CodeView
{
	public class PhotoQuestion : QuestionView
	{
		[SerializeField] private Image _prefab;
		[SerializeField] private Transform _content;

		protected override void OnSetUp(AbstractAnswerView answerView, Question question)
		{
			Init();
		}
		
		private void Init()
		{
			foreach (var sp in Question.Ico)
			{
				var c = Instantiate(_prefab, _content);
				c.sprite = sp;
			}
		}
	}
}
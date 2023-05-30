using _Scripts.Answer.View;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _Scripts.Level._Question
{
	public class QuestionView : SerializedMonoBehaviour
	{
		public TextMeshProUGUI QuestionText;
		public Transform AnswerRoot;
		[ReadOnly] public AbstractAnswerView AnswerView;
		[ReadOnly] public Question Question;

		public void SetUp(Question question, AbstractAnswerView abstractAnswerView)
		{
			Question = question;
			AnswerView = abstractAnswerView;
			QuestionText.text = question.Text;
			OnSetUp(AnswerView, Question);
		}
		protected virtual void OnSetUp(AbstractAnswerView answerView, Question question)
		{
		}
	}
}
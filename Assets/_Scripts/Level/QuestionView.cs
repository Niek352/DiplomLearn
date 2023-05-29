using _Scripts.Answer.View;
using TMPro;
using UnityEngine;

namespace _Scripts.Level
{
	public class QuestionView : MonoBehaviour
	{
		public TextMeshProUGUI QuestionText;
		public Transform AnswerRoot;
		public AbstractAnswerView AnswerView;
		public Question Question;

		public void SetUp(Question question, AbstractAnswerView abstractAnswerView)
		{
			Question = question;
			AnswerView = abstractAnswerView;
			QuestionText.text = question.Text;
		}
	}
}
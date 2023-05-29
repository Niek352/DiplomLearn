using _Scripts.Level;
using UnityEngine;

namespace _Scripts.Answer.View
{
	public class AnswerViewFactory : MonoBehaviour
	{
		[SerializeField] private InputAnswerView _inputAnswerViewPrefab;
		[SerializeField] private AnswerVariantsView _answerVariantsView;
		
		public AbstractAnswerView Create(Transform transf, Question question)
		{
			switch (question.Answer)
			{
				case InputAnswer inputAnswer:
					return Instantiate(_inputAnswerViewPrefab, transf);
				case AnswerVariants answerVariants:
					var ans = Instantiate(_answerVariantsView, transf);
					ans.SetUp(answerVariants);
					return ans;
				default:
					return null;
			}
		}
	}
}
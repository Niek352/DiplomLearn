using _Scripts.Answer;
using _Scripts.Level._Question;
using UnityEngine;

namespace _Scripts.Factories
{
	public class QuestionViewFactory : MonoBehaviour
	{
		[SerializeField] private QuestionView _questionView;
		[SerializeField] private TableQuestionView _tableQuestion;
		[SerializeField] private MiniTableQuestionView _miniTableQuestion;
		[SerializeField] private DragNDropView _dragNDropView;
		
		public QuestionView Create(Transform transf, Question question)
		{
			return question.Answer switch
			{
				TableAnswer inputAnswer => Instantiate(_tableQuestion, transf),
				MiniTable => Instantiate(_miniTableQuestion, transf),
				DragNDropVariants dragNDrop => Instantiate(_dragNDropView, transf),
				_ => Instantiate(_questionView, transf)
			};
		}
	}
}
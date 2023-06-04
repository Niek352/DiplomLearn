﻿using _Scripts.Answer;
using _Scripts.Level._Question;
using _Scripts.Level._Question.CodeView;
using UnityEngine;

namespace _Scripts.Factories
{
	public class QuestionViewFactory : MonoBehaviour
	{
		[SerializeField] private QuestionView _questionView;
		[SerializeField] private TableQuestionView _tableQuestion;
		[SerializeField] private MiniTableQuestionView _miniTableQuestion;
		[SerializeField] private DragNDropView _dragNDropView;
		[SerializeField] private CodeView _codeView;
		
		public QuestionView Create(Transform transf, Question question)
		{
			return question.Answer switch
			{
				TableAnswer inputAnswer => Instantiate(_tableQuestion, transf),
				MiniTable => Instantiate(_miniTableQuestion, transf),
				DragNDropVariants dragNDrop => Instantiate(_dragNDropView, transf),
				CodeAnswer => Instantiate(_codeView, transf),
				_ => Instantiate(_questionView, transf)
			};
		}
	}
}
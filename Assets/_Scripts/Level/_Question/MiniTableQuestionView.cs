using _Scripts.Answer;
using _Scripts.Answer.View;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Level._Question
{
	public class MiniTableQuestionView : QuestionView
	{
		[SerializeField] private HorizontalLayoutGroup _horizontalPrefab;
		[SerializeField] private GridButton _gridButtonPrefab;
		[SerializeField] private Transform _horHolder;
		[SerializeField] private GridButton[,] _grid = new GridButton[,]
		{
			{null, null,null, null,null, null},
			{null, null,null, null,null, null},
			{null, null,null, null,null, null},
			{null, null,null, null,null, null},
			{null, null,null, null,null, null},
			{null, null,null, null,null, null},
			{null, null,null, null,null, null},
		};
		
		private MiniTable _tableAnswer;

		protected override void OnSetUp(AbstractAnswerView answerView, Question question)
		{
			_tableAnswer = (MiniTable)question.Answer;
			InitTable();
		}
		
		private void InitTable()
		{
			_grid = new GridButton[_tableAnswer.Matrix.GetLength(0), _tableAnswer.Matrix.GetLength(1)];
			for (int i = 0; i < _grid.GetLength(1); i++)
			{
				var horizontal = Instantiate(_horizontalPrefab, _horHolder);
				for (int j = 0; j < _grid.GetLength(0); j++)
				{
					var button = Instantiate(_gridButtonPrefab, horizontal.transform);
					button.Text.text = _tableAnswer.Matrix[j, i];
					//_grid[i, j] = button;
				}
			}
		}
	}
}
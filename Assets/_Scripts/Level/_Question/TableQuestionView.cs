using _Scripts.Answer;
using _Scripts.Answer.View;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Level._Question
{
	public class TableQuestionView : QuestionView
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
		
		private TableAnswer _tableAnswer;

		protected override void OnSetUp(AbstractAnswerView answerView, Question question)
		{
			_tableAnswer = (TableAnswer)question.Answer;
			InitTable();
			FillGrid();
		}
		
		private void InitTable()
		{
			_grid = new GridButton[_tableAnswer.Matrix.GetLength(0) + 1, _tableAnswer.Matrix.GetLength(1) + 1];
			for (int i = 0; i < _grid.GetLength(0); i++)
			{
				var horizontal = Instantiate(_horizontalPrefab, _horHolder);
				for (int j = 0; j < _grid.GetLength(1); j++)
				{
					var button = Instantiate(_gridButtonPrefab, horizontal.transform);
					button.Text.text = $"{i}:{j}";
					_grid[i, j] = button;
				}
			}
		}

		private void FillGrid()
		{
			for (int i = 1; i < _grid.GetLength(0); i++)
			{
				_grid[i, 0].Text.text = _tableAnswer.Names[i - 1];
				_grid[0, i].Text.text = _tableAnswer.Names[i - 1];
			}
			
			for (int i = 0; i < _grid.GetLength(0); i++)
			{
				var gridButton = _grid[i, i];
				gridButton.Text.text = "";
				gridButton.Img.color = Color.gray;
				gridButton.Button.interactable = false;
			}
			
			for (int i = 1; i < _grid.GetLength(0); i++)
			{
				for (int j = 1; j < _grid.GetLength(1); j++)
				{
					if (i == j)
						continue;
					var num = _tableAnswer.Matrix[i - 1, j - 1];
					_grid[i, j].Text.text = num == 0 ? "" : num.ToString();
					_grid[i, j].Button.interactable = num != 0;
					var buttonColors = _grid[i, j].Button.colors;
					buttonColors.disabledColor = Color.white;
					_grid[i, j].Button.colors = buttonColors;
				}
			}
		}
	}

}
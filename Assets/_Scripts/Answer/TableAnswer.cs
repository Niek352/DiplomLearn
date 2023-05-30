using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Answer
{
	[CreateAssetMenu(menuName = "Answer/" + nameof(TableAnswer), fileName = nameof(TableAnswer))]
	public class TableAnswer : AbstractAnswer
	{
		public string[] Names = new string[4];
		
		[TableList(DefaultMinColumnWidth = 10)] public int[,] Matrix = new int[,]
		{
			{0,10,0,0},
			{0,10,0,0},
			{0,10,0,0},
			{0,10,0,0},
		};
		

		private void OnValidate()
		{
			for (int i = 0; i < Matrix.GetLength(0); i++)
			{
				Matrix[i, i] = 9999;
			}
			for (int i = 0; i < Matrix.GetLength(0); i++)
			{
				for (int j = 0; j < Matrix.GetLength(1); j++)
				{
					Matrix[i, j] = Matrix[j, i];
				}
			}
		}

		[Button]
		public void CreateTable(int height, int width)
		{
			Matrix = new int[width, height];
		}
	}
}

using Sirenix.OdinInspector;

namespace _Scripts.Answer
{
	public class MiniTable : AbstractAnswer
	{
		[TableList(DefaultMinColumnWidth = 10)] public string[,] Matrix = new string[,]
		{
			
		};
		
		[Button]
		public void CreateTable(int height, int width)
		{
			Matrix = new string[width, height];
		}
	}
}
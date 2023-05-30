using _Scripts.Level._Question;
using UnityEngine;

namespace _Scripts.Level
{
	
	[CreateAssetMenu(menuName = "Data/" + nameof(Level), fileName = nameof(Level))]
	public class Level : ScriptableObject
	{
		public Question[] Questions;
	}
}
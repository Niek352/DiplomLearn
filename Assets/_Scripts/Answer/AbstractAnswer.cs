using Sirenix.OdinInspector;

namespace _Scripts.Answer
{
	public abstract class AbstractAnswer : SerializedScriptableObject
	{
		public string Answer;
		public virtual bool IsValid(string answer)
		{
			return answer == Answer;
		}
	}
}
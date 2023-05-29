using System;
using UnityEngine;

namespace _Scripts.Answer.View
{
	public abstract class AbstractAnswerView : MonoBehaviour
	{
		public abstract event Action<string> CheckAnswer;
	}
}
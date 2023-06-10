using TMPro;
using Unity.Services.Authentication;
using UnityEngine;

namespace _Scripts.Menu
{
	public class DisplayName : MonoBehaviour
	{
		public TextMeshProUGUI Text;

		private void Start()
		{
			UpdateName();
		}
		
		public void UpdateName()
		{
			Text.text = AuthenticationService.Instance.PlayerName;
		}
	}
}
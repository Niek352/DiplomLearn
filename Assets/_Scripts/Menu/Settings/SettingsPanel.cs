using _Scripts.Sound;
using UnityEngine;

namespace _Scripts.Menu.Settings
{
	public class SettingsPanel : MonoBehaviour
	{
		[SerializeField] private SoundSwitch[] _switches;
		[SerializeField] private GameObject _target;
		
		private void Start()
		{
			foreach (var sw in _switches)
			{
				sw.Enable();
			}
		}
		
		public void Show()
		{
			_target.SetActive(true);
		}

		public void Hide()
		{
			_target.SetActive(false);			
			SoundManager.Instance.Play("Button");
		}
	}

}
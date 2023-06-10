using _Scripts.Sound;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Menu
{
	public class ProfilePanel : MonoBehaviour
	{
		[SerializeField] private TMP_InputField _nameInputField;
		[SerializeField] private DisplayName _displayName;
		[SerializeField] private TextMeshProUGUI _xpCount;
		[SerializeField] private Button _submitName;
		[SerializeField] private GameObject _target;
		
		private void Start()
		{
			_submitName.onClick.AddListener(SubmitNewName);
		}
		
		private void SubmitNewName()
		{
			var newName = _nameInputField.text;
			if(string.IsNullOrEmpty(newName))
			{
				Debug.LogError("Имя пустое");
				return;
			}
			if (newName.Length > 15)
			{
				Debug.LogError("Имя слишком длинное");
				return;
			}
			
			UpdateName(newName).Forget();
		}
		
		private async UniTaskVoid UpdateName(string newName)
		{
			_submitName.gameObject.SetActive(false);
			await AuthenticationService.Instance.UpdatePlayerNameAsync(newName).AsUniTask();
			_displayName.UpdateName();
		}

		public void Show()
		{
			_xpCount.text = PlayerPrefs.GetInt("XP_COUNT", 0).ToString();
			_nameInputField.text = AuthenticationService.Instance.PlayerName;
			_target.SetActive(true);
		}

		public void Hide()
		{
			SoundManager.Instance.Play("Button");
			_target.SetActive(false);
		}
	}
}
using System;
using _Scripts.Utils;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.PlayerServices
{
	public class GameManager : Singleton<GameManager>
	{
		[SerializeField] private GameObject _canvas;
		[SerializeField] private Image _loading;
		
		private TweenerCore<Quaternion, Vector3, QuaternionOptions> _tween;

		private async UniTaskVoid Start()
		{
			DontDestroyOnLoad(gameObject);

			await UnityServices.InitializeAsync().AsUniTask();
			await SignInAnonymouslyAsync();
			
			LoadScene("Scenes/Menu").Forget();
		}

		public async UniTaskVoid LoadScene(string sceneName)
		{
			_canvas.gameObject.SetActive(true);
			_tween = _loading.transform
				.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360)
				.SetEase(Ease.Linear)
				.SetUpdate(UpdateType.Late)
				.SetLoops(-1);
			
			await SceneManager.LoadSceneAsync(sceneName);
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			_canvas.gameObject.SetActive(false);
			_tween.Kill();
		}

		private void OnDisable()
		{
			_tween.Kill();
		}

		private async UniTask SignInAnonymouslyAsync()
		{
			try
			{
				await AuthenticationService.Instance.SignInAnonymouslyAsync().AsUniTask();
				Debug.Log("Sign in anonymously succeeded!");
        
				// Shows how to get the playerID
				Debug.Log($"PlayerID: { AuthenticationService.Instance.PlayerId }"); 

			}
			catch (AuthenticationException ex)
			{
				// Compare error code to AuthenticationErrorCodes
				// Notify the player with the proper error message
				Debug.LogException(ex);
			}
			catch (RequestFailedException ex)
			{
				// Compare error code to CommonErrorCodes
				// Notify the player with the proper error message
				Debug.LogException(ex);
			}
		}
	}
}
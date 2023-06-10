using System.Collections.Generic;
using System.Globalization;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Services.Leaderboards;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using SoundManager = _Scripts.Sound.SoundManager;

namespace _Scripts.Ranking
{
	public class RankingPanel : MonoBehaviour
	{
		[SerializeField] private RankingItem _rankingItem;
		[SerializeField] private List<RankingItem> _rankingItems;
		[SerializeField] private GameObject _target;
		[SerializeField] private Image _loadingImage;
		[SerializeField] private Transform _content;
		private TweenerCore<Quaternion, Vector3, QuaternionOptions> _tween;
		private bool _needUpdate = true;
		
		public void Show()
		{
			_target.gameObject.SetActive(true);
			if (_needUpdate)
			{
				ShowLeaderBoard().Forget();
			}
		}

		public void Hide()
		{
			_target.gameObject.SetActive(false);
			SoundManager.Instance.Play("Button");
		}

		private void Clear()
		{
			foreach (var item in _rankingItems)
			{
				Destroy(item.gameObject);
			}
			_rankingItems.Clear();
		}

		private async UniTaskVoid ShowLeaderBoard()
		{
			_needUpdate = false;
			_loadingImage.enabled = true;
			_tween = _loadingImage.transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetLoops(-1);
			_content.gameObject.SetActive(false);
			Clear();
			
			var scores = await LeaderboardsService.Instance.GetScoresAsync("XP_LEADERBOARD", new GetScoresOptions()
			{
				Limit = 20
			});
			
			foreach (var entry in scores.Results)
			{
				var item = Instantiate(_rankingItem, _content);
				item.SetUp(entry.PlayerName, entry.Score.ToString(CultureInfo.InvariantCulture), (entry.Rank + 1).ToString());
				_rankingItems.Add(item);
			}
			
			_tween.Kill();
			_loadingImage.enabled = false;
			_content.gameObject.SetActive(true);
		}
	}

}
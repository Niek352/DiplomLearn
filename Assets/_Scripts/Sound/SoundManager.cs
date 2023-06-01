using System;
using System.Collections.Generic;
using _Scripts.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace _Scripts.Sound
{
	public class SoundManager : Singleton<SoundManager>
	{
		[SerializeField] private Dictionary<string, AudioClip> _audioClips;
		[SerializeField] private AudioSource _audioSourcePrefab;
		[SerializeField] private AudioSource _bgMusic;
		private ObjectPool<AudioSource> _audioPool;

		protected override void AwakeSingleton()
		{
			DontDestroyOnLoad(gameObject);
			_audioPool = new ObjectPool<AudioSource>(CreateFunc);
		}
		
		private AudioSource CreateFunc()
		{
			return Instantiate(_audioSourcePrefab, transform);
		}

		public void Play(string clipName)
		{
			var audioClip = _audioClips[clipName];
			var source = _audioPool.Get();
			source.clip = audioClip;
			source.Play();
			AwaitRelease(source).Forget();
		}

		public async UniTaskVoid AwaitRelease(AudioSource target)
		{
			var ct = this.GetCancellationTokenOnDestroy();
			await UniTask.Delay(TimeSpan.FromSeconds(target.clip.length), cancellationToken: ct);
			_audioPool.Release(target);
		} 
	}
}
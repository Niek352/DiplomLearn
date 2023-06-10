using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Scripts.Menu.Settings
{
	[Serializable]
	public class SoundSwitch
	{
		public AudioMixerGroup Mixer;
		public Slider Slider;
		public string Name;
		
		public void Enable()
		{
			Slider.onValueChanged.AddListener(OnValue);
			var savedValue = PlayerPrefs.GetFloat(Name, 0);
			Slider.value = savedValue;
		}
		
		private void OnValue(float arg0)
		{
			PlayerPrefs.SetFloat(Name, arg0);
			Mixer.audioMixer.SetFloat(Name, arg0 >= 0.9f ? 0 : -80);
		}
	}
}
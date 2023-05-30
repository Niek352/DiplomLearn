﻿using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Utils
{
	public class Singleton<T> : SerializedMonoBehaviour where T : Singleton<T>
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = FindObjectOfType<T>();
					if (!_instance)
					{
						Debug.LogError($"Singleton of type {typeof(T)} not contains in scene");
						return null;
					}

					_instance.AwakeSingleton();
				}
            
				return _instance;
			}
		}

		public static bool InstanceIsNotNull => _instance;

		private void Awake()
		{
			if (!_instance)
			{
				_instance = GetComponent<T>();
				AwakeSingleton();
			}
			else if (_instance != this)
				Debug.LogError($"Dublicated singleton instance {nameof(T)}", this);
		}  

		/// <summary>
		/// Aka default <see cref="Awake"/>
		/// </summary>
		protected virtual void AwakeSingleton() { }
	}
}
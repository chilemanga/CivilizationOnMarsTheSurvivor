using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> : MonoBehaviour where T: class {
	protected static T _instance = null;
	public static T instance {
		get {
			if( _instance == null ) {
				_instance = SingletonManager.gameObject.AddComponent(typeof(T)) as T;
			}
			return _instance;
		}
	}
	
	public static void Instantiate() {
		_instance = instance;
	}

	public Singleton() {
		_instance = this as T;
	}
	
	public void ExecuteAfterCoroutine(IEnumerator coroutine, System.Action action) {
		StartCoroutine(ExecuteAfterCoroutineActual(coroutine, action));
	}
				
	private IEnumerator ExecuteAfterCoroutineActual(IEnumerator coroutine, System.Action action) {
		yield return StartCoroutine(coroutine);
		if (action != null)
			action();
	}
}

public class SingletonManager {

	public static Dictionary<string,Object> disposableSingletons {get;private set;}

	public static void AddDisposableSingleton(Object disposableSingleton) {
		if (disposableSingletons == null) {
			disposableSingletons = new Dictionary<string, Object>();
		}
		
		disposableSingletons[disposableSingleton.ToString()] = disposableSingleton;
	}
	public static void RemoveDisposableSingleton(string disposableSingletonName, bool destroy) {

		if (disposableSingletons == null) {
			Log.Warning("Unable to remove: {0}, because list of singletons is empty",disposableSingletonName);
			return;				
		}

		if (disposableSingletons.ContainsKey(disposableSingletonName)) {
			if (destroy) {
				GameObject.DestroyImmediate(disposableSingletons[disposableSingletonName]); // destroy singleton
				Log.Debug("Deleted instance of: {0}",disposableSingletonName);
			}
			disposableSingletons.Remove(disposableSingletonName);
		}
	}

	private static GameObject _gameObject = null;
	public static GameObject gameObject {
		get {
			if(_gameObject == null) {
				// note that this object name is used by iOS native code to find Singletons.
				// If you change it, be sure to change references in native code too!
				_gameObject = new GameObject("-SingletonManager");
				Object.DontDestroyOnLoad(_gameObject);
				//_gameObject.AddComponent<DeleteOnEdit>();
			}
			return _gameObject;
		}
	}
}
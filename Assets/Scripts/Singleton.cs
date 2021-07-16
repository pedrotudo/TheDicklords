using UnityEngine;
using System.Collections;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
		
	private static T s_Instance;

    public static T Instance
	{ 
		get {
			return s_Instance;
		}
	}
		
	public virtual void Awake ()
	{
		s_Instance = (T)(object)this;
	}
}
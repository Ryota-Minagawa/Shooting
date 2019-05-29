using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStage : MonoBehaviour
{

	public static GameObject _stageInstance;

	// Use this for initialization
	void Awake()
	{
		if (_stageInstance == null)
		{
			GameObject stage = (GameObject) Resources.Load("UpperStage", typeof(GameObject));
			_stageInstance = Instantiate(stage);
			DontDestroyOnLoad(_stageInstance);
		}
	}
}


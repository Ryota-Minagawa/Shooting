using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{

	private ObjectPool<Enemy> ObjectPool;

	// Use this for initialization
	void Start()
	{
		if (ObjectPool<Enemy>._instance == null)
		{
			ObjectPool = new ObjectPool<Enemy>(5, PrimitiveType.Cube);
			ObjectPool<Enemy>._instance = ObjectPool;
			ObjectPool<Enemy>._instance._objectLimit = 5;
		}
		
	}

	void Update()
	{
	    ObjectPool<Enemy>._instance.GetObject();
		for (int i = 0; i < ObjectPool<Enemy>._instance._objectList.Count; i++)
		{
			DontDestroyOnLoad(ObjectPool<Enemy>._instance._objectList[i]);
		}
	}
	
	
}

		
		
		
		
		
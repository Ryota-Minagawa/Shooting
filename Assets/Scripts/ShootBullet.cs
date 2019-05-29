using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{

	private ObjectPool<Bullet> ObjectPool;

	// Use this for initialization
	void Start () 
	{
		if (ObjectPool<Bullet>._instance == null)
		{
			ObjectPool = new ObjectPool<Bullet>(10, PrimitiveType.Sphere);
			ObjectPool<Bullet>._instance = this.ObjectPool;
			ObjectPool<Bullet>._instance._objectLimit = 20;
			for (int i = 0; i < ObjectPool<Bullet>._instance._objectList.Count; i++)
			{
				DontDestroyOnLoad(ObjectPool<Bullet>._instance._objectList[i]);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButton(0))
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 direction = rayOrigin.direction;
			GameObject bullet = ObjectPool<Bullet>._instance.GetObject();
			if (bullet != null) bullet.GetComponent<Rigidbody>().velocity = direction * 20;
			for (int i = 0; i < ObjectPool<Bullet>._instance._objectList.Count; i++)
			{
				DontDestroyOnLoad(ObjectPool<Bullet>._instance._objectList[i]);
			}
		}
	}
}

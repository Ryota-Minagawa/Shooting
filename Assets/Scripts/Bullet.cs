using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
	
	private float activeTime = 0;

	// Update is called once per frame

	private void Start()
	{
		gameObject.GetComponent<SphereCollider>().isTrigger = true;
	}

	void Update () {

		if (gameObject.activeInHierarchy) {
			activeTime += Time.deltaTime;
		}

		if (activeTime > 1.0f)
		{
			gameObject.SetActive(false);
			gameObject.transform.position=new Vector3(0,0,0);
			activeTime = 0;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			gameObject.SetActive(false);
			gameObject.transform.position=new Vector3(0,0,0);
		}
	}

}


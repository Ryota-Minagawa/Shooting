
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	void Update () {
		if (Input.GetKey(KeyCode.Y))
		{
			SceneManager.LoadScene("Main");
		}
	}
	
}

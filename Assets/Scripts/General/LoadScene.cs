using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void loadScene(string SceneName){
		SceneManager.LoadScene (SceneName);
	}
	public void quitGame(){
		Application.Quit ();
	}
}

using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	void OnGUI(){
		if (GUI.Button (new Rect (10,10,150,100), "START GAME")){
			Application.LoadLevel(MainGameScene);
		}
	}
	
			
			
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;


// This script is for any "non-grey" cubes in the scene, including white cubes. 
public class ColoredCubeScript : MonoBehaviour {
	public Color cubeColor = Color.white;
	// the Cube Color Referance is a number that is used by the GameController.ChooseCubeColor method to
	// assign a random valid color to the cube
	public bool isActive = false;
	public int cubeColorReference = 0;
	private GameControllerScript theGameController;
	public int xPos, yPos;
	
	
	// Use this for initialization
	void Start () {
		theGameController = GameObject.Find("GameControllerObject").GetComponent<GameControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		// update the color of the cube based on it's Refrence #
		CheckColorReference(cubeColorReference);
		//when cube becomes active, move it forward
		if (isActive && transform.position.z == 10) {
			transform.Translate(0, 0, -2);
		}
		else if (!isActive && transform.position.z == 8){
			transform.Translate(0, 0, 2);
		}
	}
	
	void OnMouseDown(){
		theGameController.ProcessClickedCube (this.gameObject, xPos, yPos);	
	}
	
	void CheckColorReference(int r){
		
		switch (r) {
			case 0:
				this.gameObject.renderer.material.color = Color.white;
				break;
			case 1:
				this.gameObject.renderer.material.color = Color.black;
				break;
			case 2:
				this.gameObject.renderer.material.color = Color.blue;
				break;
			case 3:
				this.gameObject.renderer.material.color = Color.red;
				break;
			case 4:
				this.gameObject.renderer.material.color = Color.yellow;
				break;
			case 5:
				this.gameObject.renderer.material.color = Color.green;
				break;
			default:
				this.gameObject.renderer.material.color = Color.magenta;
				break;
		}
	}
}

using UnityEngine;
using System.Collections;


// This script is for any "non-grey" cubes in the scene, including white cubes. 
public class ColoredCubeScript : MonoBehaviour {
	public Color cubeColor;
	
	// the Cube Color Referance is a number that is used by the GameController.ChooseCubeColor method to
	// assign a random valid color to the cube
	public int cubeColorRefrence;
	private GameControllerScript theGameController;
	public int xPos, yPos;
	
	
	// Use this for initialization
	void Start () {
		theGameController = GameObject.Find("GameControllerObject").GetComponent<GameControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		theGameController.ProcessClickedCube (this.gameObject, xPos, yPos);	
	}
}

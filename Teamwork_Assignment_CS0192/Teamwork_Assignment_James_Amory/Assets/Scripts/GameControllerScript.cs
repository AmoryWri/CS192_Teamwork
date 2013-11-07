using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	
	// Living cube refers to a non-grey cube, dead cube is a grey cube. 
	public GameObject livingCube;
	public GameObject deadCube;
	public int gridWidth = 8;
	public int gridHeight = 5;
	private GameObject[,] allCubes;
	private int nextCubeY = 1;
	private int nextCubeX = 1;
	private int nextCubeZ = 10;
	// Use this for initialization
	void Start () {
		// initilize cubes
		for (int x = 0; x < gridWidth; x++) {
			for (int y < gridHeight; y++) {
				allCubes [x,y] = (GameObject) Instantiate(livingCube, new Vector3(x*2-14, y*2-8, 10)Quaternion.Identity);
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () { 
	
	}
	
	// this will give a random colored cube
	void randomCubeSpawn (){
		Instantiate(livingCube, new Vector3 (nextCubeX, nextCubeY, nextCubeZ), Quaternion.identity);
	
	
	public void ProcessClickedCube(GameObject clickedCube, int x, int y){
		// if the cube is colored and active, make it inactive
		// if the cube is colored and inactive, make it active
		// if the cube is white and ajacent to an active cube, move the active cube to that position. 
	}
	
	void OnKeyDown (){
		// when 1-5 is pressed, check to see if the row is full
			// if the row is full, stop game
			// if the row is not full, assign that color to a random cube in that row
				//spawn new cube in "next cube" box
	}
	
	
	void ChooseCubeColor(GameObject chosenCube) {
		chosenCube.cubeColorRefrence = Random.range(1, 5);
		if (chosenCube.cubeColorRefrence < 2) {
			chosenCube.cubeColor = Color.black;
		}
		else if (chosenCube.cubeColorRefrence > 2 && chosenCube.cubeColorRefrence < 3) {
			chosenCube.cubeColor = Color.red;
		}
		
		else if (chosenCube.cubeColorRefrence > 3 && chosenCube.cubeColorRefrence < 4){
			chosenCube.cubeColor = Color.blue;
		}
		else if (chosenCube.cubeColorRefrence > 4 && chosenCube.cubeColorRefrence < 5){
			chosenCube.cubeColor = Color.yellow;
		}
	}
}

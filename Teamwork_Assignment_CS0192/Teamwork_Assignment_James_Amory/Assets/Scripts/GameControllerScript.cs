using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	
	// Living cube refers to a non-grey cube, dead cube is a grey cube. 
	public GameObject livingCube;
	public GameObject deadCube;
	public int gridWidth = 8;
	public int gridHeight = 5;
	private GameObject[,] allCubes;
	private GameObject nextCube;
	private Color nextCubeColor;
	private int nextCubeY = -4;
	private int nextCubeX = -20;
	private int nextCubeZ = 10;
	
	// Use this for initialization
	void Start () {
		// initilize cubes
		allCubes = new GameObject[gridWidth, gridHeight];
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				allCubes[x, y] = (GameObject) Instantiate(livingCube, new Vector3(x*2-14, y*2-8, 10), Quaternion.identity);
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () { 
	}
	
	// this will give a random colored cube
	void RandomCubeSpawn (){
		nextCube = (GameObject) Instantiate(livingCube, new Vector3 (nextCubeX, nextCubeY, nextCubeZ), Quaternion.identity);
		nextCubeColor= ChooseCubeColor(nextCube);
	}
	
	public void ProcessClickedCube(GameObject clickedCube, int x, int y){
		// if the cube is colored and active, make it inactive
		// if the cube is colored and inactive, make it active
		// if the cube is white and ajacent to an active cube, move the active cube to that position. 
	}
	
	void OnKeyDown (){
		int x = Random.Range(0, 8);
		// when 1-5 is pressed, check to see if the row is full
		if (Input.GetKeyDown(KeyCode.Keypad1)) {
			
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2)) {
			
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3)) {
			
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4)) {
			
		}
		else if (Input.GetKeyDown(KeyCode.Keypad5)) {
			
		}
		// if the row is full, stop game
			// if the row is not full, assign that color to a random cube in that row
				//spawn new cube in "next cube" box
	}
	
	Color ChooseCubeColor(GameObject chosenCube) {
		int r = Random.Range(1, 5);
		Color cbColor = Color.white;
		chosenCube.GetComponent<ColoredCubeScript>().cubeColorReference = r;
		chosenCube.GetComponent<ColoredCubeScript>().cubeColor = cbColor;
		
		switch (r) {
			case 1:
				cbColor = Color.black;
				chosenCube.renderer.material.color = Color.black;
				break;
			case 2:
				cbColor = Color.blue;
				chosenCube.renderer.material.color = Color.blue;
				break;
			case 3:
				cbColor = Color.red;
				chosenCube.renderer.material.color = Color.red;
				break;
			case 4:
				cbColor = Color.yellow;
				chosenCube.renderer.material.color = Color.yellow;
				break;
			case 5:
				cbColor = Color.green;
				chosenCube.renderer.material.color = Color.green;
				break;
		}
	}
}

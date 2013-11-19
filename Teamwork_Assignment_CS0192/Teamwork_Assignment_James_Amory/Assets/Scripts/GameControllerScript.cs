using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	
	// Living cube refers to a non-grey cube, dead cube is a grey cube. 
	public float timeToAct = 2f;
	public GameObject deadCube;
	public GameObject livingCube;
	public int gridHeight = 5;
	public int gridWidth = 8;
	// next Cube Color refers to an integer between 1-5 corrisponding to a viable color for the cubes
	// a value of 0 means that the cube will be white
	private int nextCubeColor;
	private float timeBeforeAction;
	private GameObject[,] allCubes;
	private GameObject nextCube;
	private int nextCubeY = -4;
	private int nextCubeX = -20;
	private int nextCubeZ = 10;
	
	void Start () {
		// initilize cubes
		allCubes = new GameObject[gridWidth, gridHeight];
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				allCubes[x, y] = (GameObject) Instantiate(livingCube, new Vector3(x*2-14, y*2-8, 10), Quaternion.identity);
				allCubes[x, y].GetComponent<ColoredCubeScript>().xPos = x;
				allCubes[x, y].GetComponent<ColoredCubeScript>().yPos = y;
			}
		}
	}
	
	void Update () {
		timeBeforeAction += Time.deltaTime;
		if (timeBeforeAction > timeToAct){
			Destroy(nextCube);
			RandomCubeSpawn();
			timeBeforeAction = 0;
		}
		OnKeyDown();
	}
	
	// this will give a random colored cube
	void RandomCubeSpawn (){
		nextCube = (GameObject) Instantiate(livingCube, new Vector3 (nextCubeX, nextCubeY, nextCubeZ), Quaternion.identity);
		ChooseCubeColor(nextCube);
	}
	
	public void ProcessClickedCube(GameObject clickedCube, int x, int y){
		// if the cube is colored and inactive, make it activ
		if (clickedCube.GetComponent<ColoredCubeScript>().cubeColorReference != 0 && clickedCube.GetComponent<ColoredCubeScript>().isActive == false){
			for (int a = 0; a < gridWidth; a++) {
				for (int b = 0; b < gridHeight; b++) {
					allCubes[a, b].GetComponent<ColoredCubeScript>().isActive = false;
				}
			}
			clickedCube.GetComponent<ColoredCubeScript>().isActive = true;
		}
		// if the cube is colored and active, make it inactive
		else if (clickedCube.GetComponent<ColoredCubeScript>().isActive == true){
			clickedCube.GetComponent<ColoredCubeScript>().isActive = false;
		}
		// if the cube is white and ajacent to an active cube, move the active cube to that position. 
	}
	
	void OnKeyDown (){
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			IsRowFull(0);
			PutCubeInRow(0);
			Destroy(nextCube);
			RandomCubeSpawn();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			IsRowFull(1);
			PutCubeInRow(1);
			Destroy(nextCube);
			RandomCubeSpawn();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			IsRowFull(2);
			PutCubeInRow(2);
			Destroy(nextCube);
			RandomCubeSpawn();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			IsRowFull(0);
			PutCubeInRow(3);
			Destroy(nextCube);
			RandomCubeSpawn();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5)) {
			IsRowFull(0);	
			PutCubeInRow(4);
			Destroy(nextCube);
			RandomCubeSpawn();
		}
	}
	
	void ChooseCubeColor(GameObject chosenCube) {
		int r = Random.Range(1, 5);
		chosenCube.GetComponent<ColoredCubeScript>().cubeColorReference = r;
		nextCubeColor = r;
	}
	
	void IsRowFull(int rowNumb){
		int y = 0;
		bool rowFull = true;
		while (y < gridWidth) {
			if (allCubes[rowNumb, y].GetComponent<ColoredCubeScript>().cubeColorReference == 0){
				rowFull = false;
				break;
			}
			else if (y < gridWidth){
				y++;
			}
			else{
				print ("end game");
				break;
			}
		}
		print (rowFull);
	}
	
	void PutCubeInRow(int y){
		int r = Random.Range (0, 8);
		while(r < 10) {
			if (allCubes[r, y].GetComponent<ColoredCubeScript>().cubeColorReference == 0) {
				allCubes[r, y].GetComponent<ColoredCubeScript>().cubeColorReference = nextCubeColor;
				r = 12;
				}
			else {
				r = r;
				r = Random.Range (0, 8);
			}
		}
	}
}
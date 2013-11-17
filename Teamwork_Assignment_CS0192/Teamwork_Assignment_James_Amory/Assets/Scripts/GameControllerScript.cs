using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	
	// Living cube refers to a non-grey cube, dead cube is a grey cube. 
	public float timeToAct = 2;
	public GameObject deadCube;
	public GameObject livingCube;
	public int gridHeight = 5;
	public int gridWidth = 8;
	private Color nextCubeColor;
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
		nextCubeColor= ChooseCubeColor(nextCube);
	}
	
	public void ProcessClickedCube(GameObject clickedCube, int x, int y){
		//when cube becomes active, move it forward
		// if the cube is colored and active, make it inactive
		if (clickedCube.GetComponent<ColoredCubeScript>().cubeColorReference != 0){
			clickedCube.GetComponent<ColoredCubeScript>().isActive = true;
		}
		else if (clickedCube.GetComponent<ColoredCubeScript>().isActive == true){
			clickedCube.GetComponent<ColoredCubeScript>().isActive = false;			
		}
		// if the cube is colored and inactive, make it active
		// if the cube is white and ajacent to an active cube, move the active cube to that position. 
	}
	
	void OnKeyDown (){
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			if (IsRowFull(0)){
				// end the game
			}
			else {
				int r = Random.Range(0,8);
				allCubes[0,r].renderer.material.color = nextCubeColor;
				Destroy(nextCube);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			if (IsRowFull(1)){
				//end the game
			}
			else {
				int r = Random.Range(0,8);
				allCubes[1,r].renderer.material.color = nextCubeColor;
				Destroy(nextCube);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			if (IsRowFull(2)){
				//end the game
			}
			else {
				int r = Random.Range(0,8);
				allCubes[2,r].renderer.material.color = nextCubeColor;
				Destroy(nextCube);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			if (IsRowFull (3)){
				//end the game	
			}
			else {
				int r = Random.Range(0,8);
				allCubes[3,r].renderer.material.color = nextCubeColor;
				Destroy(nextCube);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5)) {
			if (IsRowFull(4)){
				//end the game	
			}
			else {
				int r = Random.Range(0,8);
				allCubes[4,r].renderer.material.color = nextCubeColor;
				Destroy(nextCube);
			}
		}
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
			default:
			cbColor = Color.magenta;
			chosenCube.renderer.material.color = Color.magenta;
			break;
		}
		return cbColor;
	}
	
	bool IsRowFull(int rowNumb){
		int y = 0;
		bool rowFull = true;
		while (y < gridHeight || rowFull == true) {
			if (allCubes[rowNumb, y].renderer.material.color == Color.white){
				
				rowFull = false;
			}
			else {
				y++;
				rowFull = true;	
			}
		}
		return rowFull;
	}
}
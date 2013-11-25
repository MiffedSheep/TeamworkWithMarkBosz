using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
public int GridHeight = 5;
public int GridWidth = 8;
public GameObject aCube;
public GameObject[,] cubeArray;
public CubeBehavior cubeBehavior;

	// Use this for initialization
	void Start () {
	cubeArray = new GameObject[GridWidth, GridHeight];
	cubeBehavior = aCube.GetComponent<CubeBehavior> ();
	for(int x =0; x<GridWidth; x++){	
			for(int y =0; y<GridHeight; y++){
			cubeArray[x,y]= (GameObject) Instantiate (aCube, new Vector3 (x * 2 - 14, y * 2 - 8, 10), Quaternion.identity);
			cubeArray[x, y].GetComponent<CubeBehavior> ().x = x;
			cubeArray[x, y].GetComponent<CubeBehavior> ().y = y;	
			}
		}
	//Make Pusher Cube 1 (with script attached)
	//instantiate a cube in x(-14, 0), 2, 10
	//Make Pusher Cube 2 (with script attached)
	//instantiate a cube in 2, (-8,0), 10
	}
	void ProccessKeyboardInput(){
		if(Input.GetKeyDown (KeyCode.DownArrow)){	
				//move pusher 2 down, but not past the last cube on each end.
			
			}
		if(Input.GetKeyDown (KeyCode.UpArrow)){	
				//move pusher 2 up, but not past the last cube on each end.
				
			}
		if(Input.GetKeyDown (KeyCode.LeftArrow)){	
				//move pusher 1 left, but not past the last cube on each end.
				
			}
		if(Input.GetKeyDown (KeyCode.RightArrow)){	
				//move pusher 1 right, but not past the last cube on each end.
				
			}
		
		
		}
	// Update is called once per frame
	void Update () {
		//ProcessKeyboardInput();
	//if(x ==! cubeArray[x,y].x && y ==! cubeArray[x,y].y){ 
	//(transform this x and y to be in the position of the pushed cube);	
	//}
	}
}

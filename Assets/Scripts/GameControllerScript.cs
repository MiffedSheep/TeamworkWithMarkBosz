using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	
	//GameObjects
	public GameObject aCube;
	public GameObject pusherCube1;
	public GameObject pusherCube2;
	
	//CubeArray
	public GameObject[,] cubeArray;
	public int gridWidth = 8;
	public int gridHeight = 5;
	static int gridSpacing = 2;
	
	//calling other scripts
	public PusherCube1Script pushercube1script;
	public PusherCube2Script pushercube2script;
	public CubeBehaviorScript cubebehaviorscript;
	
	//pusherCube related	
	public bool freeToMoveRegularly = true;
	
	//Game Phase Related
	public float timer;
	public float timeActionPhase = 4f;
	public float timeLooting = 1f;
	public float timeScoredCubeFadeOut = 0.5f;
	public bool itIsNowThePlanningPhase = true;
	public bool itIsNowTheActionPhase = false;
	public bool itIsNowTheResolutionPhase = false;
	public bool thereAreThingsToLoot;
	
	
	// Use this for initialization
	void Start () {
	cubeArray = new GameObject [gridWidth, gridHeight];
	cubebehaviorscript = aCube.GetComponent<CubeBehaviorScript>();
		for(int x =0; x<gridWidth; x++){	
			for(int y =0; y<gridHeight; y++){
				cubeArray[x,y]= (GameObject) Instantiate (aCube, new Vector3 (x * gridSpacing - 14, y * gridSpacing - 8, 10), Quaternion.identity);
				cubeArray[x, y].GetComponent<CubeBehaviorScript> ().x = x;
				cubeArray[x, y].GetComponent<CubeBehaviorScript> ().y = y;	
			}
		}
	//pusherCube1 begins in the horizontal orientation		
	pusherCube1 = (GameObject) Instantiate (pusherCube1, new Vector3 (0,2,10), Quaternion.identity);
	//pusherCube2 begins in the vertical orientation
	pusherCube2 = (GameObject) Instantiate (pusherCube2, new Vector3 (2, 0, 10), Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {
	//How do I make the planning phase method work simultaneously with keyboard input? Can Unity load up both methods at the same time somehow?
	ProcessKeyboardInput();
	}
		
	void ProcessKeyboardInput(){
		if(Input.GetKeyDown (KeyCode.DownArrow)){	
			if(freeToMoveRegularly == true){
				ProcessMovePusherCube2 (pusherCube2,0,-1);		
			}
//			else if (/*position is in top left corner, on the left side*/){
//				ProcessMovePusherCube2 (pusherCube2,1,1);
//			}
//			else if (/*position is in top right corner, on the top side*/){
//				ProcessMovePusherCube2 (pusherCube2,1,-1);
//			}
//			else if (/*position is in bottom left corner, on the bottom side*/){
//				ProcessMovePusherCube2 (pusherCube2,-1,1);
//			}
//			else if (/*position is in bottom right corner, on the right side*/){
//				ProcessMovePusherCube2 (pusherCube2,-1,-1);
//			}			
			else{
				print ("poop1");
			}

		}
		
		if(Input.GetKeyDown (KeyCode.UpArrow)){
			if(freeToMoveRegularly == true){
				ProcessMovePusherCube2 (pusherCube2,0,1);
			}
//			else if (/*position is in top left corner, on the top side*/){
//				ProcessMovePusherCube2 (pusherCube2,-1,-1);
//			}
//			else if (/*position is in top right corner, on the right side*/){
//				ProcessMovePusherCube2 (pusherCube2,-1,1);
//			}
//			else if (/*position is in bottom left corner, on the left side*/){
//				ProcessMovePusherCube2 (pusherCube2,1,-1);
//			}
//			else if (/*position is in bottom right corner, on the bottom side*/){
//				ProcessMovePusherCube2 (pusherCube2,1,1);
//			}
			else{
				print ("poop2");
			}
			
		}
		
		if(Input.GetKeyDown (KeyCode.LeftArrow)){
			if(freeToMoveRegularly == true){
				ProcessMovePusherCube1 (pusherCube1,-1,0);
			}
//			else if (/*position is in top left corner, on the top side*/){
//				ProcessMovePusherCube1 (pusherCube1,-1,-1);
//			}
//			else if (/*position is in top right corner, on the right side*/){
//				ProcessMovePusherCube1 (pusherCube1,-1,1);
//			}
//			else if (/*position is in bottom left corner, on the left side*/){
//				ProcessMovePusherCube1 (pusherCube1,1,-1);
//			}
//			else if (/*position is in bottom right corner, on the bottom side*/){
//				ProcessMovePusherCube1 (pusherCube1,1,1);
//			}
			else{
				print ("poop3");
			}
			
		}
		
		if(Input.GetKeyDown (KeyCode.RightArrow)){
			if (freeToMoveRegularly == true){
				ProcessMovePusherCube1 (pusherCube1,1,0);
			}
//			else if (/*position is in top left corner, on the left side*/){
//				ProcessMovePusherCube1 (pusherCube1,1,1);
//			}
//			else if (/*position is in top right corner, on the top side*/){
//				ProcessMovePusherCube1 (pusherCube1,1,-1);
//			}
//			else if (/*position is in bottom left corner, on the bottom side*/){
//				ProcessMovePusherCube1 (pusherCube1,-1,1);
//			}
//			else if (/*position is in bottom right corner, on the right side*/){
//				ProcessMovePusherCube1 (pusherCube1,-1,-1);
//			}
			else{
				print ("poop4");
			}
		}
		ProcessPlanningPhase();
		
		if(Input.GetKeyDown (KeyCode.Space) && itIsNowThePlanningPhase == true){
			ProcessActionPhase();
		}
		else{
		print ("this is the planning phase");
		}
		
		if(Input.GetKeyDown (KeyCode.Space) && itIsNowTheActionPhase == true){
			ProcessResolutionPhase();
		}
		else{
			print ("this is the action phase");
		}
		
		if(Input.GetKeyDown (KeyCode.Space) && itIsNowTheResolutionPhase == true){
			ProcessPlanningPhase();
		}
		else{
			print ("this is the resolution phase");
		}
		
	}
		
	void ProcessMovePusherCube1(GameObject pusherCube1, int xDir, int yDir){	
		pusherCube1.transform.position += new Vector3(xDir*gridSpacing, yDir*gridSpacing, 0);
	}
			
	void ProcessMovePusherCube2(GameObject pusherCube2, int xDir, int yDir){
		pusherCube2.transform.position += new Vector3(xDir*gridSpacing, yDir*gridSpacing, 0);
	}
	void ProcessPlanningPhase(){
		itIsNowThePlanningPhase = true;
		itIsNowTheActionPhase = false;
		itIsNowTheResolutionPhase = false;
		
//		if(Input.GetKeyDown (KeyCode.Space)){
//			ProcessActionPhase();
//		}
//		else{
//		print ("this is the planning phase");
//		}
		
	}
	void ProcessActionPhase(){
		itIsNowThePlanningPhase = false;
		itIsNowTheActionPhase = true;
		itIsNowTheResolutionPhase = false;
		//timer = Time.deltaTime;
		//if (timeActionPhase >= Time.deltaTime){
			//action button disappears
			//a timer appears going from 4.0 seconds.
			//instructional text = string("you may click on cubes to destroy them")
		//}
		
//		if(Input.GetKeyDown (KeyCode.Space)){
//			ProcessResolutionPhase();
//		}
//		else{
//		print ("this is the action phase");
//		}
	}
	void ProcessResolutionPhase(){
		itIsNowThePlanningPhase = true;
		itIsNowTheActionPhase = false;
		itIsNowTheResolutionPhase = true;
		
		//countdown timer disappears
		//instructional text disappears
		//pusher 1 does its thing
		//pusher 2 does its thing
		//ProcessLooting();
		//scoring
		//emptyspace gets filled up
		//go back to scoring if need be
		
//		if(Input.GetKeyDown (KeyCode.Space)){
//			ProcessPlanningPhase();
//		}
//		else{
//		print ("this is the resolution phase");
//		}
	}
	void ProcessLooting(){
		//do a bunch of looting things
		//max of two loots per turn
		print("loot!");
	}
		void SetPusherCubeArray(){
	//X Locations for Pusher Array
	pusherArrayX[0]=0;
	pusherArrayX[1]=2;	
	pusherArrayX[2]=2;
	pusherArrayX[3]=2;			
	pusherArrayX[4]=2;			
	pusherArrayX[5]=2;
	pusherArrayX[6]=0;
	pusherArrayX[7]=-2;
	pusherArrayX[8]=-4;
	pusherArrayX[9]=-6;
	pusherArrayX[10]=-8;
	pusherArrayX[11]=-10;
	pusherArrayX[12]=-12;
	pusherArrayX[13]=-14; //Little weird addition
	pusherArrayX[14]=-16;
	pusherArrayX[15]=-16;
	pusherArrayX[16]=-16;
	pusherArrayX[17]=-16;
	pusherArrayX[18]=-14;
	pusherArrayX[19]=-12;
	pusherArrayX[20]=-10;
	pusherArrayX[21]=-8;
	pusherArrayX[22]=-6;
	pusherArrayX[23]=-4;
	pusherArrayX[24]=-2;	
	//Y Locations for Pusher Array
	pusherArrayY[0]=2;
	pusherArrayY[1]=0;	
	pusherArrayY[2]=-2;
	pusherArrayY[3]=-4;			
	pusherArrayY[4]=-6;			
	pusherArrayY[5]=-8;
	pusherArrayY[6]=-10;
	pusherArrayY[7]=-10;
	pusherArrayY[8]=-10;
	pusherArrayY[9]=-10;
	pusherArrayY[10]=-10;
	pusherArrayY[11]=-10;
	pusherArrayY[12]=-10;
	pusherArrayY[13]=-8;
	pusherArrayY[14]=-6;
	pusherArrayY[15]=-4;
	pusherArrayY[16]=-2;
	pusherArrayY[17]=2;
	pusherArrayY[18]=2;
	pusherArrayY[19]=2;
	pusherArrayY[20]=2;
	pusherArrayY[21]=2;
	pusherArrayY[22]=2;			
	pusherArrayY[23]=2;
	pusherArrayY[24]=2;			
	}
	
}
/*
 * I need my code to make sure the pusher cubes do not go off the grid, but rather wrap around it
 * 	if a pusher cube is at the last grid position, move it an x and a why. 
 * 
 * 
 */
/*
The game is played on an 8 x 5 grid of large colored cubes, and takes place over 15 turns (tunable). Each turn has the following three phases:
1)	Planning
2)	Action
3)	Resolution

Players may take as long as they want during the planning phase. When players are done planning, they may trigger the start of the action phase.
The action phase lasts 4.0 seconds (tunable). The resolution phase shows the results of the previous phases, and lasts as long as necessary for 
the animations to complete. Then the next planning phase begins, etc. Each phase is described in more detail below.
*/
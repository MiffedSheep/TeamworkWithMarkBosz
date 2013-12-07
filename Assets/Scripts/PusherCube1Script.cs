using UnityEngine;
using System.Collections;

public class PusherCube1Script : MonoBehaviour {
	public int x, y;
	public GameObject pusherCube1;
	private GameControllerScript gameControllerScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	x= gameControllerScript.pusherCube1.transform.x;
	y= gameControllerScript.pusherCube1.transform.y;
	
}

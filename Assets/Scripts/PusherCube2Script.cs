using UnityEngine;
using System.Collections;

public class PusherCube2Script : MonoBehaviour {
	public int x, y;
	public GameObject pusherCube2;
	private GameControllerScript gameControllerScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	x= gameControllerScript.pusherCube2.transform.x;
	y= gameControllerScript.pusherCube2.transform.y;
	
}

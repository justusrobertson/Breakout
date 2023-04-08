using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// The speed at which the player's paddle can move.
	public int speed = 15;
	
	// Use this for initialization
	void Update () 
	{
		// If the left button is pressed, move left.
		
		
		// If the right button is pressed, move right.
		
		
		// If the player is past the right boundary, place it at the right boundary.
		if (transform.position.x > 9.75) transform.position = new Vector3(9.75f, transform.position.y, transform.position.z);
		
		
		// If the ball is past the left boundary, place it at the left boundary.
		if (transform.position.x < -9.75) transform.position = new Vector3(-9.75f, transform.position.y, transform.position.z);
	}
}
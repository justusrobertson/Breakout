using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour 
{
	// Store the location of the left and right course walls.
	private float leftWall;
	private float rightWall;
	
	// Store the location of the top row of blocks.
	private float top;
	
	// Transforms for the three colors of blocks we will use.
	public Transform orangeBlock;
	public Transform blueBlock;
	public Transform lightBlueBlock;
	
	// Use this for initialization
	void Start () 
	{
		// Initialize our record of the course's boundaries.
		leftWall = -9.75f;
		rightWall = 9.75f;
		
		// Initialize the location of the top row of blocks.
		top = 13f;
		
		// Initialize the blocks on screen.
		InitializeBlocks ();
	}
	
	/// <summary>
	/// Initializes the blocks.
	/// </summary>
	public void InitializeBlocks ()
	{
		// Calculate the size of the court.
		float totalSize = Mathf.Abs (leftWall) + Mathf.Abs (rightWall);
		
		// Calculate the number of blocks that can fit on the court.
		float blockNum = Mathf.Floor(totalSize / orangeBlock.GetComponent<Renderer>().bounds.size.x);
		
		// Calculate the size of the gap between the maximum number of bricks and the edge of the court.
		float endGap = totalSize - (blockNum * orangeBlock.GetComponent<Renderer>().bounds.size.x);
		
		// Calculate the gap we want to place between each block.
		float gap = endGap / (blockNum);
		
		// Initialize a local variable to the top of the court.
		float yPos = top;
		
		// Iterate through the six rows of blocks...
		for (int i = 0; i < 6; i++)
		{
			// ...and iterate across the screen using the gap size and block width to guide us...
			for (float xPos = leftWall; xPos <= rightWall; xPos = xPos + orangeBlock.GetComponent<Renderer>().bounds.size.x + gap)
			{
				// Create a placeholder transform.
				Transform block;
				
				// Decide what color block to create, based on the row number.
				if (i < 2)
				{
					block = orangeBlock;	
				}
				else if (i < 3)
				{
					block = blueBlock;
				}
				else
				{
					block = lightBlueBlock;
				}
				
				// Create the block in the game world, setting it as a child of the blocks container.
				(Instantiate (block, new Vector3 (xPos, yPos, 0), Quaternion.identity) as Transform).parent = transform;
			}
			
			// Update the new row's y position.
			yPos = yPos - orangeBlock.GetComponent<Renderer>().bounds.size.y - gap;
		}
	}
	
	/// <summary>
	/// Destroys all blocks that remain on the screen.
	/// </summary>
	public void DestroyRemainingBlocks ()
	{
		// For each child of our block container (ever block)...
		foreach (Transform child in transform)
		{
			// ...destroy the block!
			Destroy (child.gameObject);	
		}
	}
	
	/// <summary>
	/// Resets the board.
	/// </summary>
	public void ResetBoard ()
	{
		DestroyRemainingBlocks ();
		InitializeBlocks ();
	}
}

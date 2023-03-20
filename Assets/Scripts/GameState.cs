using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour 
{
	// An enumeration of game states.
	public enum State
	{
		Pause = 0,
		Play = 1,
		GameOver = 2
	};
	
	// Tracks the current state of the game.
	public State CurrentState { get; set; }
	
	// Keep track of the tries remaining.
	public int BallsLeft { get; set; }
	
	// A reference to the blocks script, used to reset the game board.
	private Blocks blocks;
	
	// The maximum number of tries.
	public int maxTries = 4;
	
	// Use this for initialization
	void Start () 
	{
		// Find and store the blocks script.
		blocks = (Blocks)FindObjectOfType(typeof(Blocks));
		
		// Initialize the tries left to maximum tries.
		InitializeTries ();
		
		// Initialize the current state.
		CurrentState = State.Pause;
	}
	
	// Updates the current state.
	public void NextState ()
	{
		// The ball has fallen out of the court and there are tries remaining...

			// ...pause the game and wait for the player to serve the ball.
		
		// The ball has been served...

			// Remove a ball from the player's stockpile.
			
			// ...so the gameplay has resumed!

		// The player wants to begin a new game...

			// Reset the blocks on the game board.
			
			// Initialize the tries.
			
			// Resume game play.

		// The ball has left the court and the player has no tries left...

			// Game over, man. Game over.
	}
	
	/// <summary>
	/// Initializes the balls left to their maximum count.
	/// </summary>
	private void InitializeTries ()
	{
		BallsLeft = maxTries;	
	}
}

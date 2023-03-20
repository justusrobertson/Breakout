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
	private int maxTries;
	
	// Use this for initialization
	void Start () 
	{
		// Find and store the blocks script.
		blocks = (Blocks)FindObjectOfType(typeof(Blocks));
		
		// Initialize the maximum number of tries.
		maxTries = 4;
		
		// Initialize the tries left to maximum tries.
		InitializeTries ();
		
		// Initialize the current state.
		CurrentState = State.Pause;
	}
	
	// Updates the current state.
	public void NextState ()
	{
		// The ball has fallen out of the court...
		if (CurrentState == State.Play && BallsLeft > 0)
		{
			// ...pause the game and wait for the player to serve the ball.
			CurrentState = State.Pause;
		}
		// The ball has been served...
		else if (CurrentState == State.Pause)
		{
			// Remove a ball from the player's stockpile.
			BallsLeft--;
			
			// ...so the gameplay has resumed!
			CurrentState = State.Play;
		}
		// The player wants to begin a new game...
		else if (CurrentState == State.GameOver)
		{
			// Reset the blocks on the game board.
			blocks.ResetBoard ();
			
			// Initialize the tries.
			InitializeTries ();
			
			// Resume game play.
			CurrentState = State.Play;
		}
		// The ball has left the court and the player has no tries left...
		else
		{
			// Game over, man. Game over.
			CurrentState = State.GameOver;	
		}
	}
	
	/// <summary>
	/// Initializes the balls left to their maximum count.
	/// </summary>
	private void InitializeTries ()
	{
		BallsLeft = maxTries;	
	}
}

using UnityEngine;

public class Ball : MonoBehaviour
{
	// The range of velocities at which the ball can travel in the x direction.
	private Range<float> xVelocityRange = new Range<float>(-20, 20);

    // The range of velocities at which the ball can travel in the y direction.
    private Range<float> yVelocityRange = new Range<float>(15, 40);

    // Controls the amount of spin the paddle puts on the ball.
    private int paddleSpin = 750;
	
	// Holds information about the game's state.
	public GameState state;
	
	// Controls the game's sound.
	// Set this in the editor.
	public Sounds sounds;
	
	// Update is called once per frame
	void Update () 
	{	
		CheckSpeed ();
		CheckDeadBall ();
		CheckServe ();
	}
	
	/// <summary>
	/// Ensures the ball stays within the speed range.
	/// </summary>
	private void CheckSpeed ()
    {
		// Grab the rigidbody component and store it in a variable for easy access.
		Rigidbody rb = GetComponent<Rigidbody>();

        // Store the direction the ball is traveling in x.
        float xSign = Mathf.Sign(rb.velocity.x);

        // Store the direction the ball is traveling in y.
        float ySign = Mathf.Sign (rb.velocity.y);

        // If the ball is travelling slower than the minimum x velocity...
        if (Mathf.Abs(rb.velocity.x) < xVelocityRange.Minimum)
        {
            // ...set the ball's velocity to the minimum x velocity.
            rb.velocity = new Vector3(xVelocityRange.Minimum * xSign, rb.velocity.y, rb.velocity.z);
        }
        // Otherwise, if the ball is travelling faster than the maximum x velocity...
        else if (Mathf.Abs(rb.velocity.x) > xVelocityRange.Maximum)
        {
            // ...set the ball's velocity to the maximum x velocity.
            rb.velocity = new Vector3(xVelocityRange.Maximum * xSign, rb.velocity.y, rb.velocity.z);
        }

        // If the ball is travelling slower than the minimum y velocity...
        if (Mathf.Abs (rb.velocity.y) < yVelocityRange.Minimum)
		{
            // ...set the ball's velocity to the minimum y velocity.
            rb.velocity = new Vector3 (rb.velocity.x, yVelocityRange.Minimum * ySign, rb.velocity.z);	
		}
		// Otherwise, if the ball is travelling faster than the maximum y velocity...
		else if (Mathf.Abs (rb.velocity.y) > yVelocityRange.Maximum)
		{
            // ...set the ball's velocity to the maximum y velocity.
            rb.velocity = new Vector3 (rb.velocity.x, yVelocityRange.Maximum * ySign, rb.velocity.z);	
		}
    }
	
	/// <summary>
	/// Checks to see if the ball has moved out of the court.
	/// </summary>
	private void CheckDeadBall ()
	{
		// If the ball is out of bounds, update the game state!
		if (transform.position.y < -15 && state.CurrentState == GameState.State.Play) state.NextState ();
	}
	
	/// <summary>
	/// Checks to see if the ball should be served.
	/// </summary>
	private void CheckServe ()
	{
		// Check to see if the ball is out of play...
		if (state.CurrentState != GameState.State.Play)
		{			
			// Set the ball's velocity to zero.
			GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
			
			// Check to see if the player has served the ball...
			if (Input.GetButton("Serve")) Serve ();
		}	
	}
	
	/// <summary>
	/// Serves the ball.
	/// </summary>
	private void Serve ()
	{
		// Update the current state.

		
		// Place the ball in center court.


        // Set the ball in motion!

	}
	
	/// <summary>
	/// Calculates the force to be applied to the ball from the paddle.
	/// </summary>
	/// <returns>
	/// The force to apply to the ball.
	/// </returns>
	/// <param name='playerPosition'>
	/// The position of the player's paddle.
	/// </param>
	private float CalculateForce (float playerPosition)
	{
		// Return the force to be applied to the ball:
		// (ball position - paddle position) * spin
		return (transform.position.x - playerPosition) * paddleSpin;	
	}
	
	// When a collision occurs.
	void OnCollisionEnter(Collision collision)
	{
		// Check to see if the ball has collided with the player.
		Player player = collision.gameObject.GetComponent<Player>();
		
		// If so...
		if (player != null)
		{
			// Add the appropriate force to the ball.
			GetComponent<Rigidbody>().AddForce(CalculateForce (player.transform.position.x), 0, 0);	
			
			// Play the paddle collision sound.
			sounds.PlaySound (1);
		}
		else
		{			
			// Check to see if we have collided with a block...
			if (collision.transform.parent != null)
			{
				// Destroy the block! AHAHA!!
				
				
				// Play the block sound!
				sounds.PlaySound (0);
			}
			else
			{
				// We've hit a wall... play the wall bounce sound!
				sounds.PlaySound (2);	
			}
		}
	}
}
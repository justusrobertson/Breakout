using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour 
{
	// The array of sounds, set in the editor.
	public AudioSource[] sounds;
	
	/// <summary>
	/// Plays the sound corresponding to the number set in the editor.
	/// </summary>
	/// <param name='num'>
	/// The number of the sound.
	/// </param>
	public void PlaySound(int num)
	{
		sounds[num].Play();	
	}
}

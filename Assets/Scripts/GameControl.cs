using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;         //A reference to our game control script so we can access it statically.

	public float speed = 10f;
	public float carSpeed = 5f;
	public float frequency = 2f;
	private int score = 0;                      //The player's score.

	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if (instance != this)
			//...destroy this one because it is a duplicate.
			Destroy(gameObject);
	}
}
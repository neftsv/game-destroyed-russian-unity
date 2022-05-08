using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;         //A reference to our game control script so we can access it statically.

	public GameObject car;
	public GameObject cameraFront;
	public GameObject cameraSide;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI GameOverText;
	public Button playButton;
	public Button RestartButton;

	public GameObject Fire;

	public AudioSource bang;
	public AudioSource audio_menu;
	public AudioSource audio_play;
	public AudioSource audio_game;

	public float speed = 10f;
	public float carSpeed = 5f;
	public float frequency = 2f;
	public float score = 0;                      //The player's score.
	public int gameStage = 1;				//0 - end game, 1 - menu, 2 - start game

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

    private void Start()
    {
		Button playbtn = playButton.GetComponent<Button>();
		Button restartbtn = RestartButton.GetComponent<Button>();
		playbtn.onClick.AddListener(PlayBTN);
		restartbtn.onClick.AddListener(RestartBTN);
		audio_menu.Play();
	}

	void PlayBTN()
    {
		playButton.gameObject.SetActive(false);
		scoreText.gameObject.SetActive(true);
		gameStage = 2;
        cameraFront.gameObject.SetActive(true);
        cameraSide.gameObject.SetActive(false);
		audio_menu.Stop();
		audio_play.Play();
    }

	void RestartBTN()
	{
		gameStage = 1;
		playButton.gameObject.SetActive(true);
		RestartButton.gameObject.SetActive(false);
		GameOverText.gameObject.SetActive(false);
		cameraFront.gameObject.SetActive(false);
		cameraSide.gameObject.SetActive(true);
		car.transform.position = new Vector3(2f, 1f, -70f);
		bang.Stop();
		audio_menu.Play();
		Fire.SetActive(false);
	}

	private void FixedUpdate()
    {
		if (gameStage == 2)
		{
			score += speed * Time.deltaTime;
			scoreText.text = "Score: " + Mathf.RoundToInt(score);
			if (!audio_play.isPlaying && !audio_game.isPlaying && !audio_menu.isPlaying)
				audio_game.Play();
		}
		if (gameStage == 1)
        {
			Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
		}
		
    }
}
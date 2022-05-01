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
	}

	void PlayBTN()
    {
		playButton.gameObject.SetActive(false);
		scoreText.gameObject.SetActive(true);
		gameStage = 2;
        cameraFront.gameObject.SetActive(true);
        cameraSide.gameObject.SetActive(false);
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
	}

	

	private void FixedUpdate()
    {
		if (gameStage == 2)
		{
			score += speed * Time.deltaTime;
			scoreText.text = "Score: " + Mathf.RoundToInt(score);
		}
		if (gameStage == 1)
        {
			Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
		}

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControll : MonoBehaviour
{
    public static GameControl instance;
    //private Rigidbody carRB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameControl.instance.gameStage == 2)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(x, 0, z);
            transform.Translate(move * GameControl.instance.carSpeed * Time.deltaTime);
            //transform.Rotate(new Vector3(0, z * -5, 0) * GameControl.instance.carSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //carRB = other.gameObject.GetComponent<Rigidbody>();
            //carRB.isKinematic = false;
            GameControl.instance.gameStage = 0;
            GameControl.instance.GameOverText.text = "Game Over\nScore: " + Mathf.RoundToInt(GameControl.instance.score);
            GameControl.instance.GameOverText.gameObject.SetActive(true);
            GameControl.instance.RestartButton.gameObject.SetActive(true);
            GameControl.instance.scoreText.gameObject.SetActive(false);
            GameControl.instance.score = 0;
        }
    }
}
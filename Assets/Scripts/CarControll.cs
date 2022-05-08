using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarControll : MonoBehaviour
{
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
            GameControl.instance.Fire.SetActive(true);
            GameControl.instance.gameStage = 0;
            GameControl.instance.GameOverText.text = "Game Over\nScore: " + Mathf.RoundToInt(GameControl.instance.score);
            GameControl.instance.GameOverText.gameObject.SetActive(true);
            GameControl.instance.RestartButton.gameObject.SetActive(true);
            GameControl.instance.scoreText.gameObject.SetActive(false);
            GameControl.instance.bang.Play();
            GameControl.instance.audio_game.Stop();
            GameControl.instance.score = 0;
        }
    }
}

//void DestroyAll(string tag)
//{
//    GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
//    for (int i = 0; i < enemies.Length; i++)
//    {
//        Destroy(enemies[i]);
//    }
//}

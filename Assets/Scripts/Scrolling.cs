using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
	//private float speed = GameControl.instance.speed;		//speed = 0, but GameControl.instance.speed = 5  (-_-;)
	private Collider m_collider;
	private Vector3 v_size;
	
	void Start()
	{
		m_collider = GetComponent<Collider>();
		v_size = m_collider.bounds.size;
		//Debug.Log(speed);		//
		//Debug.Log(GameControl.instance.speed);
	}

	void Update()
	{
		gameObject.transform.Translate(-Vector3.forward * GameControl.instance.speed * Time.deltaTime); //Scroll Road
		if (gameObject.transform.position.z <= -v_size.z)   //Repair road
		{
			gameObject.transform.position += new Vector3(0, 0, v_size.z * 2);
		}
	}
}

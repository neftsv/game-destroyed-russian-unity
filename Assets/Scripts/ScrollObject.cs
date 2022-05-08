using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
	// Start is called before the first frame update
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
		if (GameControl.instance.gameStage == 2)
		{
			gameObject.transform.Translate(-Vector3.forward * GameControl.instance.speed * Time.deltaTime); //Scroll Road
			if (gameObject.transform.position.z <= -80)   //Repair road
			{
				Destroy(gameObject);
			}
		}
	}
}

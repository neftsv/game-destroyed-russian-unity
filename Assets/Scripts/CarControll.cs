using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = -Input.GetAxis("Horizontal");
        float z = -Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);
        transform.Translate(move * GameControl.instance.carSpeed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, z * -5, 0) * GameControl.instance.carSpeed * Time.deltaTime);
    }
}
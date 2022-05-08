using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Whells : MonoBehaviour
{
    public float speed = 150f;
    void Update()
    {
        transform.Rotate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyRotate : MonoBehaviour
{
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(50f, 200f);
        if (Random.value > 0.5f) // 50% chance to be negative
        {
            rotationSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

}

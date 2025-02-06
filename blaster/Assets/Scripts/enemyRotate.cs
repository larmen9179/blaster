using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRotate : MonoBehaviour
{
    private float rotationSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rotationSpeed = Random.Range(40f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotationStep);
    }
}

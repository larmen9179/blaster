using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemySpeed = 5;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float randomAngle = Random.Range(0f, 360f);
        Vector2 moveDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
        rb.velocity = moveDirection * enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        
}

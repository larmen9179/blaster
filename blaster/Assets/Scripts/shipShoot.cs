using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shipShoot : MonoBehaviour
{

    public GameObject shot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject createdShot = Instantiate(shot, transform.position, transform.rotation);
        Rigidbody2D rb = createdShot.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10;
    }
}

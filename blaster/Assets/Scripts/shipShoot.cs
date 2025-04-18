using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class shipShoot : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private float offsetAmount = 0.3f;
    private GameObject player;

    public GameObject shot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
        if (player.GetComponent<playerUpgradePrefs>().multiShot){
            // Offset positions to left and right of the ship
            Vector2 leftOffset = transform.position - transform.right * offsetAmount;
            Vector2 rightOffset = transform.position + transform.right * offsetAmount;

            // Left shot
            GameObject leftShot = Instantiate(shot, leftOffset, transform.rotation);
            leftShot.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            int damageAmountLeft = player.GetComponent<playerUpgradePrefs>().playerDamage;
            leftShot.GetComponent<damageDealer>().setDamage(damageAmountLeft);

            // Right shot
            GameObject rightShot = Instantiate(shot, rightOffset, transform.rotation);
            rightShot.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            int damageAmountRight = player.GetComponent<playerUpgradePrefs>().playerDamage;
            rightShot.GetComponent<damageDealer>().setDamage(damageAmountRight);
        }
        else{
            // Single center shot
            GameObject singleShot = Instantiate(shot, transform.position, transform.rotation);
            singleShot.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            int damageAmount = player.GetComponent<playerUpgradePrefs>().playerDamage;
            singleShot.GetComponent<damageDealer>().setDamage(damageAmount);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    public float pushStrength = 3f;
    public float activeTime = 3f;
    public float cooldownTime = 5f;

    private CircleCollider2D forcefieldCollider;
    private SpriteRenderer spriteRenderer;
    private bool forcefieldActive = false;

    void Start()
    {
        forcefieldCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        forcefieldCollider.enabled = false;
        spriteRenderer.enabled = false;

        StartCoroutine(ForcefieldCycle());
    }

    public void ActivateForcefield()
    {
        forcefieldActive = true;
    }

    IEnumerator ForcefieldCycle()
    {
        while (true)
        {
            if (forcefieldActive)
            {
                yield return new WaitForSeconds(Random.Range(3f, cooldownTime));

                // Activate
                forcefieldCollider.enabled = true;
                spriteRenderer.enabled = true;

                yield return new WaitForSeconds(activeTime);

                // Deactivate
                forcefieldCollider.enabled = false;
                spriteRenderer.enabled = false;
            }
            else
            {
                yield return null; // chill for a frame, try again next loop
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemySmall") || other.CompareTag("EnemyMedium") || other.CompareTag("EnemyPlane") || other.CompareTag("EnemyTank"))
        {
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();
            // Push enemy away from the center of the forcefield
            Vector3 pushDirection = other.transform.position - transform.position;
            enemyRb.velocity = pushDirection.normalized * pushStrength;
        }
        else if (other.CompareTag("tankBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}

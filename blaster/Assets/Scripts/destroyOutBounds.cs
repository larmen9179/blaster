using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Add padding margin (e.g., 0.05f) to avoid destroying bullets right at the edges
        if (viewportPosition.x < -0.05f || viewportPosition.x > 1.05f || viewportPosition.y < -0.05f || viewportPosition.y > 1.05f)
        {
            Destroy(gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerThrustEffect : MonoBehaviour
{
    public ParticleSystem[] thrusterParticles;

    // Update is called once per frame
    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||
                       Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
                       Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        foreach (ParticleSystem thruster in thrusterParticles)
        {
            if (isMoving)
            {
                if (!thruster.isPlaying)
                    thruster.Clear();
                    thruster.Play();
                    thruster.Emit(1);
            }
            else
            {
                //stop all thrusters
                if (thruster.isPlaying)
                    thruster.Stop(); 
            }
        }
    }
}

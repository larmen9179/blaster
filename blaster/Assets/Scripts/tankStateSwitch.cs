using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankStateSwitch : MonoBehaviour
{
    public float timer;
    public float timeToSwitch;
    public Boolean armored = true;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timeToSwitch = 2.5f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(armored){
            timer += Time.deltaTime;
            if(timer >= timeToSwitch){
                spriteRenderer.color = Color.white;
                timer = 0;
                armored = false;
                Debug.Log("Armor Gone");
            }
        }
        else{
            timer += Time.deltaTime;
            if(timer >= timeToSwitch){
                spriteRenderer.color = Color.gray;
                timer = 0;
                armored = true;
                Debug.Log("Armor Time");
            }
        }
        
    }
}

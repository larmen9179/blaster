using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageDealer : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage;
    private int hits = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getDamage(){
        return damage;
    }

    public void setDamage(int damageIn){
        damage = damageIn;
    }

    public int getHits(){
        return hits;
    }
    public void setHits(int hitsIn){
        hits = hitsIn;      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Declare Variables
    public float Hitpoints;
    public float MaxHitpoints = 5;
    // Sets the enemies max health
    void Start()
    {
        Hitpoints = MaxHitpoints;
    }
    // Updates the enemies health when it is depleted and destorys it when the health reaches 0
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if(Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    float collisonTimer;
    public GameObject HUD;
    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        Debug.Log(collidedObject.tag);
        if (collidedObject.tag == "Player")
        {
            collisonTimer = 0;
            HUD.GetComponent<HealthController>().ReduceLifeByTag(this.tag);

            switch (this.tag)
            {
                case "Enemy":
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        }
        else if(collidedObject.tag == "AttackSpell")
        {
            GetComponent<EnemyHealth>().TakeHit(5);
            Destroy(collidedObject.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collidedObject)
    {
        collisonTimer += Time.deltaTime;

        if (collidedObject.tag == "Player" && collisonTimer >= 2)
        {
            collisonTimer = 0;
            HUD.GetComponent<HealthController>().ReduceLifeByTag(this.tag);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDamage : MonoBehaviour
{
    //If the passive spell collides with the door then it will damage and or destory it
    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.tag == "PassiveSpell")
        {
            GetComponent<DoorHealth>().TakeHit(5);
            Destroy(collidedObject.gameObject);
        }
    }
}

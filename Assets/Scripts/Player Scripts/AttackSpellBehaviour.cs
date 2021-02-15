using UnityEngine;
public class AttackSpellBehaviour : MonoBehaviour
{
    //Sets the speed of the spell moving
    public float Speed = 15;
    //In this updater method its calculating its movement when the player uses the attack spell
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed; 
    }
    //Once the spell had collided with something we need to destory it.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyHealth>();
        if (enemy)
        {
            enemy.TakeHit(5);
        }
        Destroy(gameObject);
    }
}

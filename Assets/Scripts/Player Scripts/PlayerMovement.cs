using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Setting player movement speed
    public float MovementSpeed = 5;
    //Setting the player Jump
    public float JumpForce = 5;
    //Allows for instances of the attack spell to exist
    public AttackSpellBehaviour ProjectileAttackSpellPrefab;
    public PassiveSpellBehaviour ProjectilePassiveSpellPrefab;
    public Transform LaunchOffset;
    private Rigidbody2D _rigidbody2D;
   private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Gets player input to move the character around
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        //Rotates the player with the direction they are facing
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        //Gets player input to allow the character to jump
        if(Input.GetButtonDown("Jump") && Mathf.Abs( _rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        //Allows the player to use the hostile spell
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectileAttackSpellPrefab, LaunchOffset.position, transform.rotation);
        }
        //Allows the player to use the passive spell
        if(Input.GetButtonDown("Fire2"))
        {
            Instantiate(ProjectilePassiveSpellPrefab, LaunchOffset.position, transform.rotation);
        }
    }

}

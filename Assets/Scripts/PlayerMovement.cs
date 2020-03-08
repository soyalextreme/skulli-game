using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   
    // public variables
    public float jumpStrenght;
    public Transform  refGround;
    public float speedWalk;

    //private variables
    Animator anim;
    Rigidbody2D skully;
    Transform skullyObject;
    

    // Start is called before the first frame update
    void Start()
    {
        skully = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        skullyObject = GetComponent<Transform>();            
    }

    // Update is called once per frame
    void Update()
    {

        // validate is on ground
        bool _onGround = Physics2D.OverlapCircle(refGround.position, 1f, 1<<8);
        anim.SetBool("_onGround", _onGround);

        // Horizontal movement
       float movmentX = Input.GetAxis("Horizontal");
       skully.velocity = new Vector2(movmentX * speedWalk, skully.velocity.y);
        anim.SetFloat("speed", movmentX*movmentX);





        //! flip the sprite with scale
        if(movmentX < 0 ) skullyObject.transform.localScale = new Vector2(Mathf.Abs(skullyObject.localScale.x) * -1, skullyObject.localScale.y);
        if(movmentX > 0 ) skullyObject.transform.localScale = new Vector2(Mathf.Abs(skullyObject.localScale.x) * 1, skullyObject.localScale.y);
        
        // punching
        if(Input.GetKeyDown("f") && movmentX == 0) anim.SetTrigger("punch");

        //Jumping
       if(Input.GetButtonDown("Jump") && _onGround) skully.AddForce(
            new Vector2(0,jumpStrenght), ForceMode2D.Impulse
       );



       
    }
}

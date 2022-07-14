using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
   
    [SerializeField]
    private float jumpForce = 11f;
    // public float maxVelocity = 22f;
    

    //Components
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    
    


    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    
    private bool isGrounded;



 /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        
        myBody=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        //mostly for physics calculations //will be called according to fixed tiestamp
        PlayerJump();

    }


    void PlayerMoveKeyboard(){
        movementX=Input.GetAxisRaw("Horizontal");
        // [-1 or 0 or 1]  //getaxis() will move smoothly within ranger
        // Debug.Log(movementX);
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;    
    }



    void AnimatePlayer(){

        //we are going to right side
        if (movementX>0)
        {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=false;
   
        }else if(movementX<0){
            //we are going to left side
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=true;

        }else{
            //idle
            anim.SetBool(WALK_ANIMATION,false);

        }
    }

    void PlayerJump(){
        if (Input.GetButtonDown("Jump") && isGrounded)//will return true when button is pressed
        {
            isGrounded=false;
            //applying force
            myBody.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
        }


        // if (Input.GetButtonUp("Jump"))//will return true when button is released
        // {
            
        // }

        // if (Input.GetButton("Jump"))//will return true while button is released
        // {
            
        // }
    }

//for jump() :when collides with ground
    private void OnCollisionEnter2D(Collision2D collision) {
        //collision is colliding object
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;

        }        

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject); //current gameobj
            
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        //collider2D can siply access comparetag but not collision2D
        {
            Destroy(gameObject); //current gameobj
            
        }
    }



}//class

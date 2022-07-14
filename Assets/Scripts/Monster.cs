using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{   
    [HideInInspector]
    // public-would be seen in other scripts but wont be seen in inspector tab
    public float speed;
    private Rigidbody2D myBody;
   
   
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        myBody=GetComponent<Rigidbody2D>();
        // speed =7;

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        myBody.velocity =   new Vector2(speed, myBody.velocity.y);
        //velocity pushes player to move like Addforce Vector2(x,y)
    }
   
   
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

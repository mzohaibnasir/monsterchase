using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX; 



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; 
        //getting player's transform property
    }

    // Update is called once per frame
    void Update(){

    }





    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    private void LateUpdate()
    //called after every calculation in update is finished which means we have a new player position to use
    // so we went have conflicts
    {
        if(!player){
            return;
            // obj has been destroyed in Monster but we are still using player position .
        }
        tempPos = transform.position; //current position of camera
        // Debug.Log(transform.position);
        // Debug.Log(tempPos);
        tempPos.x=player.position.x;

        if(tempPos.x < minX){
            tempPos.x=minX;
        }
        if(tempPos.x> maxX){
            tempPos.x=maxX;
        }
        transform.position=tempPos;


    }
}

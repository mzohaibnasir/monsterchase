using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sender : MonoBehaviour{

    public delegate void PlayerDied();//company that make newspapers
    public static event PlayerDied PlayerDiedInfo; //this will inform us that player have died
    //we subscribe to event to know what is going on.

    //To get reciever event, we need to create a function with same signature as our delegate in Receiver.cs

    private bool isAlive;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        // if (PlayerDiedInfo != null)
        // {
        //     PlayerDiedInfo();
        // }

        Invoke("ExecuteEvent", 5f);
    }



    void ExecuteEvent(){
        //  if (isAlive == false)
        //     {
        //          if (PlayerDiedInfo != null) //means somebody has subscribed to event
        //                 {
        //                     PlayerDiedInfo();
        //                 }
        //     }
         if (PlayerDiedInfo != null)
            {
                PlayerDiedInfo();
            }
    }
}



/* Procedure: define delegate:

//sender
public delegate float PlayerDied(Vector3 player,Vector3 target);
public static event PlayerDied playerDiedInfo;

//invoking:
void ExecuteEvent(){
    if(playerDiedInfo != null){
        playerDiedInfo(new Vector3(1f,1f,1f), new Vector3(2f,2f,2f))
    }
}



//reciever

void OnEnable(){
    Sender.playerDiedInfo += PlayerDiedListener;
}

//this function is supposed to be called
 void PlayerDiedListener(Vector3 player,Vector3 target){//function that will execute after that event
        //this function will be subscribed ton that listener
        print("Event has called this function");
    }*/
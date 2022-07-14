using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Receiver : MonoBehaviour{


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        // Sender.PlayerDiedInfo +=PlayerDiedListener;//subscribed
    }



    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// this is recommended function where you should subscribe toour events
    /// </summary>
    private void OnEnable()
    {
       Sender.PlayerDiedInfo +=PlayerDiedListener;//subscribed
       Sender.PlayerDiedInfo +=Test;//subscribed //TEST will exeute

    }


    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
               Sender.PlayerDiedInfo -=PlayerDiedListener;//unsubscribed
               Sender.PlayerDiedInfo -=Test;//unsubscribed 

    }




    //To get reciever event, we need to create a function with same signature as our delegate in Receiver.cs

    void PlayerDiedListener(){//function that will execute after that event
        //this function will be subscribed ton that listener
        print("Event has called this function");
    }



    void Test(){
        print("Called from test");

    }
}
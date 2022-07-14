using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour 
{
    //In order to execute a code when button is presssed, fn needs tobe public void
    // fn can have only one paarameter
    public void PlayGame(){

        //getting button we pressed
        // UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name
        string clickedObj = EventSystem.current.currentSelectedGameObject.name;
        // Debug.Log("index:" + clickedObj); //index because names are 0 and 1

        // STRing-> int
        int selectedCharacter = int.Parse(clickedObj);

        //taking instance from GameManager
        GameManager.instance.CharIndex=selectedCharacter;

        SceneManager.LoadScene("Gameplay");
        // When unity moves between scenes, it destroy all objects in previous scenes.


    }
}//class

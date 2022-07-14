using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
        // menuManager will access through this instance to initialize charIndex  

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex
    {
        get{
            return _charIndex;
        }
        set{
            _charIndex=value;
        }
    }


    private void Awake(){
        if(instance == null){
            instance = this;///this means instance of this class
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }


    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        
    }


  
  
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
        if (scene.name == "Gameplay")
        {
            Instantiate(characters[CharIndex]);
        }
    }


}

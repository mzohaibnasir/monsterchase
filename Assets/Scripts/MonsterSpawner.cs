﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{


    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;


    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMonsters());
    }



//courtine because we are going to call it in intervals of time
    IEnumerator spawnMonsters()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));

            randomIndex =Random.Range(0,monsterReference.Length);
            randomSide = Random.Range(0,2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);




            //left
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;   
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10);
                //from monster class
            }else
            {
                //right side    
                spawnedMonster.transform.position = rightPos.position;   
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
                spawnedMonster.transform.localScale= new Vector3(-1f, 1f, 1f);
                //changing face of monster

            
            
            }
        }
    }
}














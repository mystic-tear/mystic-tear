﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    private float speed;
    private float stoppingDistance = 1.5F;

    private Transform target;
    private bool inBattle = false;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "ARBattle")
        {
            inBattle = true;
        }
        speed = Random.Range(5,11);
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
    }

    void Update()
    {
        if(inBattle)
        {
            if(target == null)
            {
                searchForTarget();
            }
            else 
            {
                chaseTarget();
            }
        }
    }

    void searchForTarget()
    {
        target = GameObject.FindGameObjectWithTag("good").GetComponent<Transform>();
    }

    void chaseTarget()
    {
        if(Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

}

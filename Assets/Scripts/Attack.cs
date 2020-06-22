<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Attack : MonoBehaviour
{
    private Transform target;
    private bool inBattle = false;
    private int attackDistance = 2;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("I'm in enemyFollows : Start.sceneName =" + currentScene.name);
        Debug.Log("I'm in enemyFollows : Start before : inBattle =" + inBattle);

        if(currentScene.name == "ARBattle")
        {
            inBattle = true;
        }
        
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
                attackTarget();
            }
        }
    }

    void searchForTarget()
    {
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
        Debug.Log("I'm in enemyFollows: searchForTarget : target =" + target);
    }

    void attackTarget()
    {
        if(Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            Debug.Log("I'm in attack : attackTarget : RUNNING start");
            
            Debug.Log("I'm in attack : attackTarget : RUNNING end");
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Attack : MonoBehaviour
{
    private Transform target;
    private bool inBattle = false;
    private int attackDistance = 2;
    private int attackAmount = 1;
    private int attackSuccess = 4;
    private soHealth playerHealth;
    private soHealth enemyHealth;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "ARBattle")
        {
            inBattle = true;
        }
        
        playerHealth = FindObjectOfType<ARBattle>().playerHealth;
        enemyHealth = FindObjectOfType<ARBattle>().enemyHealth;
        
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
                StartCoroutine(attackTarget());
            }
        }
    }

    void searchForTarget()
    {
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
    }

    IEnumerator attackTarget()
    {
        if(Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            if(Random.Range(0, attackSuccess + 1) == attackSuccess)
            {
                EnemyTakeDamage(attackAmount);
            }

            yield return new WaitForSeconds(1);
        }
    }

    public void CreaturesTakeDamage(int damage)
    {
        playerHealth.ChangeBy(-damage);
    }

    public void EnemyTakeDamage(int damage)
    {
        enemyHealth.ChangeBy(-damage);
    }
}
>>>>>>> androidDebugging

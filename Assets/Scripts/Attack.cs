using System.Collections;
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
        Debug.Log("I'm in enemyFollows : Start after: inBattle =" + inBattle);
        Debug.Log("I'm in enemyFollows: start : target =" + target);
        Debug.Log("I'm in enemyFollows: start : speed =" + speed);
        Debug.Log("I'm in enemyFollows: start : stoppingDistance =" + stoppingDistance);

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
            ARBattle.
            Debug.Log("I'm in attack : attackTarget : RUNNING end");
        }
    }
}

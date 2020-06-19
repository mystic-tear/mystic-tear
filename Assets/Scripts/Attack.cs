using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Attack : MonoBehaviour
{

    private Transform target;
    private bool inBattle = false;
    private int attackDistance = 2;
    private ARBattle battle;
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
            battle.EnemyTakeDamage(10);
            Debug.Log("I'm in attack : attackTarget : RUNNING end");
        }
    }
}

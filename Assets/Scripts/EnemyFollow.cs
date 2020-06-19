using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    private float speed;
    private float stoppingDistance = 2F;

    private Transform target;
    private bool inBattle = false;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("I'm in enemyFollows : Start.sceneName =" + currentScene.name);
        Debug.Log("I'm in enemyFollows : Start before : inBattle =" + inBattle);

        if(currentScene.name == "ARBattle")
        {
            inBattle = true;
        }
        speed = Random.Range(5,11);
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
                chaseTarget();
            }
        }
    }

    void searchForTarget()
    {
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
        Debug.Log("I'm in enemyFollows: searchForTarget : target =" + target);
    }

    void chaseTarget()
    {
        if(Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            Debug.Log("I'm in enemyFollows : chaseTarget : RUNNING start");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Debug.Log("I'm in enemyFollows : chaseTarget : RUNNING end");
        }
    }

}

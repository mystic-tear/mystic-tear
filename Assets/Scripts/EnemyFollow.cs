<<<<<<< HEAD
﻿using UnityEngine;
=======
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> androidDebugging
>>>>>>> master
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    private float speed;
<<<<<<< HEAD
    private float stoppingDistance = 1.5F;
=======
<<<<<<< HEAD
    private float stoppingDistance = 2F;

=======
    private float stoppingDistance = 1.5F;
>>>>>>> androidDebugging
>>>>>>> master
    private Transform target;
    private bool inBattle = false;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Debug.Log("I'm in enemyFollows : Start.sceneName =" + currentScene.name);
        Debug.Log("I'm in enemyFollows : Start before : inBattle =" + inBattle);
=======
>>>>>>> androidDebugging
>>>>>>> master

        if(currentScene.name == "ARBattle")
        {
            inBattle = true;
        }
        speed = Random.Range(5,11);
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Debug.Log("I'm in enemyFollows : Start after: inBattle =" + inBattle);
        Debug.Log("I'm in enemyFollows: start : target =" + target);
        Debug.Log("I'm in enemyFollows: start : speed =" + speed);
        Debug.Log("I'm in enemyFollows: start : stoppingDistance =" + stoppingDistance);

=======
>>>>>>> androidDebugging
>>>>>>> master
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Debug.Log("I'm in enemyFollows: searchForTarget : target =" + target);
=======
>>>>>>> androidDebugging
>>>>>>> master
    }

    void chaseTarget()
    {
        if(Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
<<<<<<< HEAD
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
=======
<<<<<<< HEAD
            Debug.Log("I'm in enemyFollows : chaseTarget : RUNNING start");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Debug.Log("I'm in enemyFollows : chaseTarget : RUNNING end");
=======
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
>>>>>>> androidDebugging
>>>>>>> master
        }
    }

}
<<<<<<< HEAD
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5;
    public float stoppingDistance = 3;

    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("good").GetComponent<Transform>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
>>>>>>> master
=======
>>>>>>> androidDebugging

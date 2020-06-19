using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Attack : MonoBehaviour
{

    private Transform target;
    private bool inBattle = false;
    private int attackDistance = 2;
    //private int attackAmount = 10;
    private soHealth playerHealth;
    private soHealth enemyHealth;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("I'm in enemyFollows : Start.sceneName =" + currentScene.name);
        Debug.Log("I'm in enemyFollows : Start before : inBattle =" + inBattle);

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
                attackTarget();
            }
        }
    }

    void searchForTarget()
    {
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
        Debug.Log("I'm in attack: searchForTarget : target =" + target);
    }

    void attackTarget()
    {
        if(Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            Debug.Log("I'm in attack : attackTarget : RUNNING start");
            EnemyTakeDamage(10);
            Debug.Log("I'm in attack : attackTarget : RUNNING end");
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

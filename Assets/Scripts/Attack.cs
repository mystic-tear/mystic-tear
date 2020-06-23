using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Attack : MonoBehaviour
{
    private Transform target;
    private GameObject theEnemy;
    private bool inBattle = false;
    private int attackDistance = 2;
    private int attackAmount = 1;
    private int attackSuccess = 4;
    private soHealth playerHealth;
    private soHealth enemyHealth;
    private List<GameObject> goodGuysList;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "ARBattle")
        {
            inBattle = true;
        }
        
        playerHealth = FindObjectOfType<ARBattle>().playerHealth;
        enemyHealth = FindObjectOfType<ARBattle>().enemyHealth;
        
        theEnemy = GameObject.FindGameObjectWithTag("bad");
        target = theEnemy.GetComponent<Transform>();
        goodGuysList = FindObjectOfType<ARBattle>().placedGameObjectsList;
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
        // if(gameObject.tag == "bad")
        // {
        //     targets = 
        // }
        theEnemy = GameObject.FindGameObjectWithTag("bad");
        target = theEnemy.GetComponent<Transform>();
    }

    IEnumerator attackTarget()
    {
        if(Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            if(Random.Range(0, attackSuccess + 1) == attackSuccess)
            {
                EnemyTakeDamage(attackAmount + Random.Range(0, 5));
                if(enemyHealth.health <= 0)
                {
                    Destroy(theEnemy);
                }
            }

            if(gameObject.tag == "bad")
            {
                if(Random.Range(0, attackSuccess + 1) == attackSuccess)
                {
                    CreaturesTakeDamage(attackAmount + Random.Range(0, 9));
                    
                    if(playerHealth.health <= 0 )
                    {
                        Destroy(goodGuysList[3]);
                    }
                    else if(playerHealth.health < (playerHealth.maxHealth - 300))
                    {
                        Destroy(goodGuysList[2]);
                    }
                    else if(playerHealth.health < (playerHealth.maxHealth - 200))
                    {
                        Destroy(goodGuysList[1]);
                    }
                    else if(playerHealth.health < (playerHealth.maxHealth - 100))
                    {
                        Destroy(goodGuysList[0]);
                    }
                }
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

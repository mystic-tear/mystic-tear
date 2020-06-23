using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    public Rigidbody rb;
    private float speed;
    private float stoppingDistance = 1.5F;
    private Transform target;
    private bool inBattle = false;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "ARBattle") inBattle = true;

        if(rb == null) rb = GetComponent<Rigidbody>();

        speed = Random.Range(1, 6);
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
    }

    void Update()
    {
        if(inBattle)
        {
            if(target == null) searchForTarget();
        }
    }

    private void FixedUpdate() 
    {
        chaseTarget();
    }

    void searchForTarget()
    {
        target = GameObject.FindGameObjectWithTag("bad").GetComponent<Transform>();
    }

    void chaseTarget()
    {
        // if(Vector3.Distance(transform.position, target.position) > stoppingDistance)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // }
        if(Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(newPosition);
        }
        else if(Vector3.Distance(transform.position, target.position) <= stoppingDistance)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(newPosition);
            //rb.velocity = Vector3.zero;
        }
    }

}

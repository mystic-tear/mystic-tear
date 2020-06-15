using System.Collections;
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

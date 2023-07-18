using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private EnemyAwareness enemyAwarness;
    private Transform playersTransform;
    private UnityEngine.AI.NavMeshAgent enemyNavMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        enemyAwarness = GetComponent<EnemyAwareness>();
        playersTransform = FindObjectOfType<PlayerMove>().transform;
        enemyNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    private void Update ()
    {
        if (enemyAwarness.isAgro)
        {
            enemyNavMeshAgent.SetDestination(playersTransform.position);
        } else
        {
            enemyNavMeshAgent.SetDestination(transform.position);
        }
    }

}

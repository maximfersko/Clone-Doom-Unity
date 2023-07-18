using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public Material aggroMaterial;
    public bool isAgro;
    public float awarenessRadius = 8f;

    private UnityEngine.Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {

        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist < awarenessRadius)
        {
            isAgro = true;
        }

        if (isAgro)
        {
            GetComponent<MeshRenderer>().material = aggroMaterial;
        }
    }

}

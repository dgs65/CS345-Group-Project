﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public Transform[] points;
    private int destpoint;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNext();
    }
    void GoToNext()
    {
        if(points.Length <= 0)
        {
            return;
        }
        agent.destination = points[destpoint].position;
        destpoint = (destpoint +1) % points.Length;

    }
    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNext();
        }
    }
}

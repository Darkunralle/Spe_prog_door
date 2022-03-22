using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    
public class MoveTo : MonoBehaviour {
       
    [SerializeField]
    private Transform m_goal;
    private NavMeshAgent m_agent;
    //private SphereCollider m_detection;

    private state m_myState;

    private int m_desPoint = 0;

    [SerializeField] private List<GameObject> m_patrolPoint;


    private enum state
    {
        Patrol,
        Alerte,
        Search
    }
       
    void Start () {
        m_agent = GetComponent<NavMeshAgent>();
        //m_detection = GetComponent<SphereCollider>();
        m_agent.autoBraking = false;
        m_myState = state.Patrol;

        if (m_patrolPoint == null)
        {
            Debug.Log("Aucun point de patrouille n'a était assigné");
        }
        
        GotoNextPoint();

        
    }

    private void Update()
    {
        Debug.Log(m_myState);
        switch (m_myState)
        {
            case state.Patrol:
                Debug.Log(message:$"{m_agent.remainingDistance}");
                if (!m_agent.pathPending && m_agent.remainingDistance < 1f)
                    GotoNextPoint();
                break;
            case state.Alerte:
                m_agent.destination = m_goal.position; 
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        m_myState = state.Alerte;
    }

    private void OnTriggerExit(Collider other)
    {
        m_myState = state.Patrol;
        m_agent.destination = transform.position;
    }
    
    void GotoNextPoint() {

        // Set the agent to go to the currently selected destination.
        m_agent.destination = m_patrolPoint[m_desPoint].transform.position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        m_desPoint = (m_desPoint + 1) % m_patrolPoint.Count;
    }
    
}
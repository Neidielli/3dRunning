using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scriptNPC : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject pc;
    public GameObject[] waypoints = new GameObject[4];
    private int index = 0;
    public float maxDist = 2;
    private bool perseguicao = false;
    public float maxDistAlvo = 10;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        proximo();
    }

    private void proximo()
    {
        agent.SetDestination(waypoints[index++].transform.position);
        if (index >= waypoints.Length)
        {
            index = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (perseguicao || Vector3.Distance(transform.position, pc.transform.position) <= maxDistAlvo)
        {
            perseguicao=true;
            agent.SetDestination(pc.transform.position);
        } else if(Vector3.Distance(transform.position, agent.destination) < maxDist)
        {
            proximo();
        }
        //agent.SetDestination(pc.transform.position);
    }
}

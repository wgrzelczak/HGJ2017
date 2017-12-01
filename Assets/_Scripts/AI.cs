using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Doors doors;

    private NavMeshAgent agent;
    private Vector3 targetPosition;
    private CollectableSpawner spawner;

    private int damage = 10;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawner = GetComponent<CollectableSpawner>();
    }

    public void Activate()
    {
        doors = TeamManager.GetInstance().GetDoors(spawner.team);
        targetPosition = doors.transform.position;
        agent.SetDestination(targetPosition);
        StartCoroutine(CheckDistance());
        AudioManager.GetInstance().PlaySFX(AUDIO.CAT_COLLECT);
    }

    IEnumerator CheckDistance()
    {
        while(!agent.isStopped)
        {
            if(Vector3.Distance(transform.position, targetPosition) < 1.0)
            {
                agent.isStopped = true;
                StartCoroutine(Hitting());
            }
            yield return 0;
        }
    }

    IEnumerator Hitting()
    {
        while(!doors.areDestroyed)
        {
            //print("ai hit");
            doors.Hit(damage);
            yield return new WaitForSeconds(0.8f);
        }
    }
}

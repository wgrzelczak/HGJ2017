using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [HideInInspector]
    public TEAM team;
    [HideInInspector]
    public Player player;

    protected abstract void Effect();

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Playerr")
        {
            player = other.GetComponent<Player>();
            team = player.team;
            Effect();
        }
    }
}

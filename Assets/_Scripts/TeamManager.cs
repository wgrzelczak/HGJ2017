using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public Doors doorsRed;
    public Doors doorsBlue;

    private static TeamManager instance = null;

    public void Awake()
    {
        instance = this;
    }

    public static TeamManager GetInstance()
    {
        return instance;
    }

    public Doors GetDoors(TEAM team)
    {
        return (team == TEAM.BLUE ? doorsBlue : doorsRed);
    }
}

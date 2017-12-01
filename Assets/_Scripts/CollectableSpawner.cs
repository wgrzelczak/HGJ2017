using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : Collectable
{
    protected override void Effect()
    {
        GetComponent<AI>().Activate();
    }
}

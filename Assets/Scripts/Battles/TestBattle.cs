using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBattle : Battle
{
    void Start()
    {
        Debug.Log("Setting up Test Battle enemies");
        this.actorNames = new ArrayList();

        actorNames.Add("Player1");
        actorNames.Add("Player2");
        actorNames.Add("Enemy1");
        actorNames.Add("Enemy2");
        actorNames.Add("Enemy3");
        actorNames.Add("Enemy4");
    }

   
    void Update()
    {
        
    }
}

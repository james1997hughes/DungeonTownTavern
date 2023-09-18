using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerInfo playerInfo;

    void Start()
    {
        playerInfo = gameObject.GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

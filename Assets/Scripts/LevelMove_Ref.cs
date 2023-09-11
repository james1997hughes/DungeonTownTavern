using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;

    // level move zones enter, if collider is a plater
    // move game to another scene

   public void OnTriggerEnter2D(Collider2D other) {
        print("Trigger entered");

        //could use other.GetComponent<Player>() tto see if the game object has a player component
        //tags work too, maybe some players have different script components?
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            // player entered, so move level
            print("Switching Scene to" + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

}

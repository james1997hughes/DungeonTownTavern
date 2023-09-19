using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInfoController : MonoBehaviour
{
    BattleController battleController;
    public List<GameObject> playerInfoContainers;
    public int playerCount;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading asset!");
        battleController = GameObject.Find("EventSystem").GetComponent<BattleController>();
        playerInfoContainers = new List<GameObject>();
        
    }

    
    public void highlightPlayer(BattleActor currentPlayer)
    {
        currentPlayer.playerInfoContainer.GetComponent<CanvasGroup>().alpha = 1.0f;
    }
    public void fadeAllPortraits(){
        foreach(GameObject go in playerInfoContainers){
            try{
                go.GetComponent<CanvasGroup>().alpha = 0.3f;
            } catch{
                Debug.Log("Couldn't fade infobox!");
            }
        }
    }
    public void addPlayerInfoContainer(BattleActor ba, GameObject prefab){
        GameObject infoBox = Instantiate(prefab, new Vector2(0,0), Quaternion.identity);
        infoBox.transform.SetParent(gameObject.transform, false);
        infoBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-400, -230+(50*playerCount));
        ba.playerInfoContainer = infoBox;


        PlayerInfoContainer infoClass = infoBox.GetComponent<PlayerInfoContainer>();
        infoClass.ba = ba;
        infoClass.setCharacterSprite(ba.character.portrait);

        CanvasGroup infoboxCG = infoBox.GetComponent<CanvasGroup>();
        infoboxCG.alpha = 0.3f;


        playerCount++;

        playerInfoContainers.Add(infoBox);
    }
}

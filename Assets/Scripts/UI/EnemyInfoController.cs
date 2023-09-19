using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfoController : MonoBehaviour
{
    BattleController battleController;
    public List<GameObject> enemyInfoContainers;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading asset!");
        battleController = GameObject.Find("EventSystem").GetComponent<BattleController>();
        enemyInfoContainers = new List<GameObject>();
        
    }

    
    public void highlightEnemy(BattleActor currentPlayer)
    {
        currentPlayer.enemyInfoContainer.GetComponent<CanvasGroup>().alpha = 1.0f;
    }
    public void fadeAllPortraits(){
        foreach(GameObject go in enemyInfoContainers){
            try{
                go.GetComponent<CanvasGroup>().alpha = 0.3f;
            } catch{
                Debug.Log("Couldn't fade infobox!");
            }
        }
    }
    public void addEnemyInfoContainer(BattleActor ba, GameObject prefab){
        GameObject infoBox = Instantiate(prefab, new Vector2(0,0), Quaternion.identity);
        infoBox.transform.SetParent(gameObject.transform, false);
        infoBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-520+(40*enemyCount), 232);
        ba.enemyInfoContainer = infoBox;


        EnemyInfoContainer infoClass = infoBox.GetComponent<EnemyInfoContainer>();
        infoClass.ba = ba;
        infoClass.setCharacterSprite(ba.character.portrait);

        CanvasGroup infoboxCG = infoBox.GetComponent<CanvasGroup>();
        infoboxCG.alpha = 0.3f;


        enemyCount++;

        enemyInfoContainers.Add(infoBox);
    }
}

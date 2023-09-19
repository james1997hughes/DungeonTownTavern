using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//This & EnemyInfoController should be merged to parent class InfoController
//Then EnemyInfoContrl and this should inherit it
//to reduce the repetition of code
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

    public void updateStats(bool instantly = false){
        foreach(GameObject go in playerInfoContainers){
            PlayerInfoContainer pic = go.GetComponent<PlayerInfoContainer>();
            float hpPerc = ((float)pic.ba.character.hp / (float)pic.ba.character.maxHp)*100;
            GameObject manaSlide = go.transform.Find("ManaSlider").gameObject;
            Slider manaSlider = manaSlide.GetComponent<Slider>();
            Slider hpSlider = go.transform.Find("HPSlider").gameObject.GetComponent<Slider>();

            if (hpSlider.value != hpPerc && !instantly){
                StartCoroutine(adjustStat(hpPerc, hpSlider));
            } else if(hpSlider.value != hpPerc && instantly){
                hpSlider.value = hpPerc;
            }
        }
    }

    IEnumerator adjustStat(float newValue, Slider slider){
        float originalValue = slider.value;
        while(slider.value > newValue+2 || slider.value < newValue-2){
            float i = (newValue - originalValue)/5 * Time.deltaTime; // Sub slider.value in for originalValue here for 'slows down as it gets close' effect
            slider.value += i;
            yield return null;
        }
        slider.value = newValue;
    }
}

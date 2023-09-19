using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void updateStats(bool instantly = false){
        foreach(GameObject go in enemyInfoContainers){
            EnemyInfoContainer pic = go.GetComponent<EnemyInfoContainer>();
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

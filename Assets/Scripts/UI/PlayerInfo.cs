using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    BattleController battleController;
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        battleController = GameObject.Find("EventSystem").GetComponent<BattleController>();
        prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PlayerInfoContainer.prefab");
    }

    
    void highlightPlayer()
    {
        
    }
    void addPlayerInfoContainer(Character character){
        GameObject infoBox = Instantiate(prefab, new Vector2(0,0), Quaternion.identity);
        infoBox.transform.parent = gameObject.transform;
        infoBox.GetComponent<RectTransform>().position = new Vector2(-400, -174);
    }
}

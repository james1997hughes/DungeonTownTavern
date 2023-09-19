using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoContainer : MonoBehaviour
{
    public BattleActor ba;
    public Sprite characterSprite;
    
    void Start()
    {
        
    }

    public void setCharacterSprite(Sprite sprite){
        this.characterSprite = sprite;
        gameObject.transform.Find("Portrait").GetComponent<Image>().sprite = sprite;
    }
    void UpdateHpBar(float value)
    {
        
    }

    void UpdateManaBar(float value){
        
    }
}

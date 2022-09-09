using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{

    public GameObject[] characterPreFabs;
    
    public TMP_Text label;

    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPreFabs[selectedCharacter];
        
        label.text = prefab.name;
    }

   
}

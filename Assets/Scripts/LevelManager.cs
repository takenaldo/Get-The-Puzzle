using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject  []lvlButtons;

    public int testUserLevel = -1;
    public Sprite unlockedSprite;

    void Start()
    {
        if (testUserLevel > 0 )
            PlayerPrefs.SetInt(Helper.USER_LEVEL, testUserLevel);

        int userLevel = Helper.getUserLevel();
        Debug.Log("LVL is: " + userLevel);
        for (int i = 1; i <= userLevel; i++)
        {
            lvlButtons[i - 1].GetComponent<Image>().sprite = unlockedSprite;
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

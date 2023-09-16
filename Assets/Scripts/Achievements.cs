using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievements : MonoBehaviour
{
    public GameObject levelsPlayed;
    public GameObject gamesPlayed;
    public TextMeshProUGUI txtLevels;
    public TextMeshProUGUI txtGamesWonPerPLayed;


    // Start is called before the first frame update
    void Start()
    {



        int lvl = Helper.getUserLevel();
        txtLevels.text = lvl + "/9";
        GameObject[] items = Helper.getChildsFor(levelsPlayed);
            for (int i = 0; i < items.Length; i++)
            {
                if(lvl == i + 1)
                {
                    items[i].SetActive(true);
                }
                else
                {
                    items[i].SetActive(false);
                }            
            }

        int _gamesPlayed_num = PlayerPrefs.GetInt(Helper.GAMES_PLAYED);
        int gamesWon = PlayerPrefs.GetInt(Helper.GAMES_WON);
        gamesWon = 9;
        _gamesPlayed_num = 10;

        txtGamesWonPerPLayed.text =  gamesWon+"/"+_gamesPlayed_num;

            

        int percentageWon = (gamesWon * 9) / _gamesPlayed_num;

        GameObject[] gp_items = Helper.getChildsFor(gamesPlayed);
        for (int i = 0; i < gp_items.Length; i++)
        {
            if (percentageWon == i + 1)
            {
                gp_items[i].SetActive(true);
            }
            else
            {
                gp_items[i].SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

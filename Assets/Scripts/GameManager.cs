using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameFinished = false;
    public int current_level = 1;
    public static int LANGUAGE_EN = 0;
    public static int LANGUAGE_RU = 1;
    public int levels = 9;

    public GameObject[] spots;
    public GameObject board;
    public List<Candidate> candidates;
    public bool timeUp = false;

    private bool playerLooses = false;
    private bool playerWins = false;

//    public GameObject dialogLoose;
    public GameObject dialogWin;

    public GameObject parentGamePlayObjects;

    public GameObject movingCandidate;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public string GAMES_PLAYED = "games_played";
    public string GAMES_WON = "games_won";

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(GAMES_PLAYED,PlayerPrefs.GetInt(GAMES_PLAYED,1) + 1);
        spots = Helper.getChildsFor(board);
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("candidate"))
            candidates.Add(item.GetComponent<Candidate>());
    }


    // Update is called once per frame
    void Update()
    {

        if (isGameFinished())
        {

            if (playerWins && !dialogWin.activeSelf)
            {
                dialogWin.SetActive(true);
                if (current_level + 1 > Helper.getUserLevel())
                    Helper.updateLevel();
                PlayerPrefs.SetInt(GAMES_WON, PlayerPrefs.GetInt(GAMES_WON, 0)+1);
            }


            parentGamePlayObjects.SetActive(false);

        }


    }


    public bool isGameFinished()
    {
        if (timeUp)
        {
            playerLooses = true;
            playerWins = false;
            gameFinished = true;
            Debug.Log("TIME UP");
            return gameFinished;
        }

        if (allCandidatesMatching() && !timeUp)
        {
            playerLooses = false;
            playerWins = true;
            Debug.Log("WIN");
            gameFinished = true;
        }
        else
        {
            gameFinished = false;
        }


        return gameFinished;
    }


    // checks if all candidates are matching
    public bool allCandidatesMatching()
    {
        foreach (Candidate candidate in candidates)
            if (!candidate.matching)
                return false;
        return true;
    }


}

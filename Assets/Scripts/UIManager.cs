using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text healthCount;
    [SerializeField] private TMP_Text blueCount;
    [SerializeField] private TMP_Text redCount;
    [SerializeField] private TMP_Text teamWins;
    [SerializeField] private Button play;
    [SerializeField] private Button exit;
    [SerializeField] private Button exit2;
    [SerializeField] private Button newGame;
    [SerializeField] private GameObject panelEndGame;    
    [SerializeField] private List<GameObject> screens = new List<GameObject>();
    [SerializeField] private Button settings;

    public Action newGameEvent;

    private void OnEnable()
    {
        play.onClick.AddListener(() => newGameEvent?.Invoke());
        exit.onClick.AddListener(() => Application.Quit());
        exit2.onClick.AddListener(() => Application.Quit());
        newGame.onClick.AddListener(() => newGameEvent?.Invoke());
    }
    private void OnDisable()
    {
        
    }    
    
    public void TextHealthOut(int count)
    {
        healthCount.text = count.ToString();
    }
    public void TankCountOut(TypeTank typeTank, int count)
    {
        if (typeTank == TypeTank.blue) blueCount.text = count.ToString();
        if (typeTank == TypeTank.red) redCount.text = count.ToString();
    }
    public void ChangeScreen(Screens screen)
    {
        foreach(GameObject scr in screens)
        {
            if (scr.GetComponent<Screen>().screen == screen) scr.SetActive(true);
            else scr.SetActive(false);
        }
    }
    public void EndGame(bool blueWin)
    {
        panelEndGame.SetActive(true);
        if (blueWin)
        {
            panelEndGame.GetComponent<Image>().color = new Color(0, 0.627451f, 0.7882354f, 1f);
            teamWins.text = "BLUE TEAM WIN";
        }
        else
        {
            panelEndGame.GetComponent<Image>().color = new Color(0.7921569f, 0.2352941f, 0.2352941f, 1f);
            teamWins.text = "RED TEAM WIN";
        }
    }
}


public enum Screens
{
    menu,
    game,
    settings,
}
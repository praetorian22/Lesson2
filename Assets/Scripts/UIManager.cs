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
    [SerializeField] private Button play;
    [SerializeField] private Button exit;
    [SerializeField] private List<GameObject> screens = new List<GameObject>();
    [SerializeField] private Button settings;

    public Action newGameEvent;    

    private void Start()
    {
        play.onClick.AddListener(() => newGameEvent?.Invoke());
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
}

public enum Screens
{
    menu,
    game,
    settings,
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeTank : MonoBehaviour
{
    private int level;    
    private int metalRemains;

    [SerializeField] private int maxLevel;
    [SerializeField] private List<int> levelUpPoints = new List<int>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> tankTextures = new List<Sprite>();

    public Action<int> upgradeEvent;

    private void AddRemains(int count)
    {
        if (level != maxLevel)
        {
            metalRemains += count;
            if (metalRemains >= levelUpPoints[level])
            {
                LevelUp();
            }
        }
    }
    private void LevelUp()
    {
        level++;
        upgradeEvent?.Invoke(level);
        spriteRenderer.sprite = tankTextures[level];
    }
    private void Start()
    {
        level = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddRemains(collision.GetComponent<MetalRemains>().MetalRemainsCount);
        collision.GetComponent<MetalRemains>().destroyRemainsEvent?.Invoke(collision.gameObject);
    }

}

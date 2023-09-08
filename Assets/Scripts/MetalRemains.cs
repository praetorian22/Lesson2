using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MetalRemains : MonoBehaviour
{
    private int metalRemainsCount;
    [SerializeField] private int metalRemainsCountMin;
    [SerializeField] private int metalRemainsCountMax;

    public int MetalRemainsCount { get => metalRemainsCount; }
    public Action<GameObject> destroyRemainsEvent;


    private void Start()
    {
        metalRemainsCount = UnityEngine.Random.Range(metalRemainsCountMin, metalRemainsCountMax);
    }

}

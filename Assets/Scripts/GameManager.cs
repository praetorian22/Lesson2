using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> pointsSpawnBlue = new List<Transform>();
    [SerializeField] private List<Transform> pointsSpawnRed = new List<Transform>();
    [SerializeField] private int blueCount;
    [SerializeField] private int redCount;    
    [SerializeField] private GameObject player;    
    [SerializeField] private int startHealtPlayer;
    private UIManager uiManager;
    private SpawnerTanks spawnerTanks;
    private SpawnerRemains spawnerRemains;
    private EffectManager effectManager;


    private void Start()
    {
        
    }

    private void StartGame()
    {
        uiManager.ChangeScreen(Screens.game);
        for (int i = 0; i < blueCount; i++)
        {
            spawnerTanks.SpawnTank(TypeTank.blue, pointsSpawnBlue[Random.Range(0, pointsSpawnBlue.Count)].position);            
        }
        for (int i = 0; i < redCount; i++)
        {
            spawnerTanks.SpawnTank(TypeTank.red, pointsSpawnRed[Random.Range(0, pointsSpawnRed.Count)].position);
        }                
        player.GetComponent<HealthScript>().SetHealth(startHealtPlayer);
        spawnerRemains.StartSpawn();
    }

    private void EndGame(GameObject player, TypeTank typeTank)
    {
        player.transform.position = Vector3.zero;
        uiManager.ChangeScreen(Screens.menu);
        spawnerTanks.DestroyAllTank();
        spawnerRemains.StopSpawn();
        spawnerRemains.DestroyAllRemains();        
    }

    private void OnEnable()
    {
        uiManager = GetComponent<UIManager>();
        spawnerTanks = GetComponent<SpawnerTanks>();
        spawnerRemains = GetComponent<SpawnerRemains>();
        effectManager = GetComponent<EffectManager>();
        uiManager.newGameEvent += StartGame;
        spawnerTanks.tankDeadEvent += spawnerRemains.SpawnAfterTankDead;
        spawnerTanks.tankDeadEvent += effectManager.Explosion;
        player.GetComponent<HealthScript>().changeHealthEvent += uiManager.TextHealthOut;
        player.GetComponent<HealthScript>().deadEvent += EndGame;
        spawnerTanks.tankCountChangeEvent += uiManager.TankCountOut;
    }
    private void OnDisable()
    {
        if (player != null)
        {
            player.GetComponent<HealthScript>().changeHealthEvent -= uiManager.TextHealthOut;
            player.GetComponent<HealthScript>().deadEvent -= EndGame;
        }
        spawnerTanks.tankCountChangeEvent -= uiManager.TankCountOut;
        spawnerTanks.tankDeadEvent -= spawnerRemains.SpawnAfterTankDead;
        spawnerTanks.tankDeadEvent -= effectManager.Explosion;
        uiManager.newGameEvent -= StartGame;
    }
}

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
    [SerializeField] private Transform startPositionPlayer;
    private UIManager uiManager;
    private SpawnerTanks spawnerTanks;
    private SpawnerRemains spawnerRemains;
    private EffectManager effectManager;
    private bool isGame;


    private void Start()
    {
        
    }

    private void StartGame()
    {
        isGame = true;
        player.transform.position = startPositionPlayer.position;
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

    private void PlayerDead(GameObject player, TypeTank typeTank)
    {
        isGame = false;
        EndGame(false);
    }

    private void PlayerWin()
    {
        if (isGame) EndGame(true);
        isGame = false;
    }

    private void EndGame(bool blue)
    {
        player.transform.position = Vector3.zero;
        uiManager.ChangeScreen(Screens.menu);
        uiManager.EndGame(blue);
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
        player.GetComponent<HealthScript>().deadEvent += PlayerDead;
        player.GetComponent<HealthScript>().shotEvent += effectManager.ExplosionMini;
        spawnerTanks.tankCountChangeEvent += uiManager.TankCountOut;
        spawnerTanks.noRedTanksEvent += PlayerWin;
    }
    private void OnDisable()
    {
        if (player != null)
        {
            player.GetComponent<HealthScript>().changeHealthEvent -= uiManager.TextHealthOut;
            player.GetComponent<HealthScript>().deadEvent -= PlayerDead;
            player.GetComponent<HealthScript>().shotEvent -= effectManager.ExplosionMini;
        }
        spawnerTanks.tankCountChangeEvent -= uiManager.TankCountOut;
        spawnerTanks.tankDeadEvent -= spawnerRemains.SpawnAfterTankDead;
        spawnerTanks.tankDeadEvent -= effectManager.Explosion;
        uiManager.newGameEvent -= StartGame;
        spawnerTanks.noRedTanksEvent -= PlayerWin;
    }
}

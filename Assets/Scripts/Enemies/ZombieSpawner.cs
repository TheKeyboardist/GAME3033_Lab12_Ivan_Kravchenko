using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerStateMachine))]
public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private int numberOfZombiesToSpawn;

    public GameObject[] zombiePrefabs;

    public SpawnVolume[] spawnVolumes;

    public GameObject FollowObject => followObject;
    private GameObject followObject;

    private SpawnerStateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<SpawnerStateMachine>();

        followObject = GameObject.FindGameObjectWithTag("Player");

        ZombieWaveState beginningWave = new ZombieWaveState(this, stateMachine)
        {
            zombiesToSpawn = 10,
            nextState = SpawnerStateEnum.Complete
        };

        stateMachine.AddState(SpawnerStateEnum.Beginner, beginningWave);
        stateMachine.Initialize(SpawnerStateEnum.Beginner);
    }
}

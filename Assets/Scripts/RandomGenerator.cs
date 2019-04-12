using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    public GameObject FriendPrefab;
    public GameObject EnemyPrefab;
    public GameObject EnergyPrefab;

    public int MaxWidth = 10;
    public int MaxHeight = 5;
    public int MaxFriends = 5;
    public int MaxEnemies = 3;
    public int MaxEnergies = 5;

    // private variables
    private List<Vector3> PositionList;
    private int max;
    private bool IsSpaceFull = false;

    private bool IsSpawn = false;
    private float timer = 1f;

    // Use this for initialization
    void Start () {
        PositionList = new List<Vector3>();
        max = (MaxWidth * 2) * (MaxHeight * 2);

        if (IsSpaceFull == false && IsSpawn == false)
        {
            // spawn new object
            RandomSpawn(FriendPrefab, MaxFriends);
            RandomSpawn(EnemyPrefab, MaxEnemies);
            RandomSpawn(EnergyPrefab, MaxEnergies);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    // generate random objects
    void RandomSpawn(GameObject circle, int count)
    {
        if (PositionList.Count == max)
        {
            Debug.Log("The Space is Full.");
            IsSpaceFull = true;
            return;
        }

        for (int i = 0; i < count; i++)
        {
            // random position
            Vector3 position = GenerateRandomPosition();

            //while(true)
            while (PositionList.Count < max)
            {
                if (!PositionList.Contains(position))
                {
                    Instantiate(circle, position, Quaternion.identity);
                    PositionList.Add(position);
                    
                    break;
                }
                else
                {
                    position = GenerateRandomPosition();
                }
            }
        }
    }

    // generate random position
    private Vector3 GenerateRandomPosition()
    {
        return new Vector3(Random.Range(-MaxWidth, MaxWidth), Random.Range(-MaxHeight, MaxHeight), 0);
    }
}

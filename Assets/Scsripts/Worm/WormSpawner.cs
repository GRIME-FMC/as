using PathCreation;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WormSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wormPrefab;
    [SerializeField] private GameObject wormPartPrefab;
    [SerializeField] private PathCreator pathCreator;
    public float spawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0) 
        {
            if (LevelSettings.WORM_ID < LevelSettings.MAX_WORMS)
            {
                //SPAWN
                int wormLength = Random.Range(10, 10); //LevelSettings.MAX_WORM_LENGTH);

                GameObject worm = GameObject.Instantiate(wormPrefab);
                worm.name = "Worm_" + LevelSettings.WORM_ID;
                LevelSettings.WORM_ID++;
                SpawnWorm(worm, wormLength);

                spawnTime = wormLength * LevelSettings.SPAWN_INTERVAL_MULTIPIER;
            }
        }
    }

    public void SpawnWorm(GameObject head,int len) 
    {
        for (int i = 0; i < len; i++)
        {
            GameObject tempGO = GameObject.Instantiate(wormPartPrefab);
            tempGO.name = head.name + "_part_" + i;
            tempGO.GetComponent<WormPart>().distanceTravelled = i;
            tempGO.transform.parent = head.transform;            
            tempGO.GetComponent<WormPart>().pathCreator = pathCreator;
            head.GetComponent<Worm>().AddWormPart(tempGO);
            tempGO.GetComponent<WormPart>().index = i;
            tempGO.GetComponentInChildren<TextMeshPro>().text = "" + i;

            if (i == 0)
            {
                tempGO.GetComponent<WormPart>().wormPartType = WormPartType.Head;
                
            }
            else
            {
                tempGO.GetComponent<WormPart>().wormPartType = WormPartType.Body;
                tempGO.GetComponent<WormPart>().nextPart = head.GetComponent<Worm>().GetWormPart(i - 1);
            }

        }
    }
}

using PathCreation;
using UnityEngine;

public class WormPart : MonoBehaviour
{
    public PathCreator pathCreator;
    [SerializeField] public WormPartType wormPartType;
    public GameObject nextPart;
    public WormPart nextWormPart;
    public float distanceTravelled = 1f;
    public float speedTravelled = 1f;

    //TEST
    public int index = 0;
    void Start()
    {
        if (nextPart != null)
        {
            nextWormPart = nextPart.GetComponent<WormPart>();
            wormPartType = WormPartType.Body;
            //distanceTravelled = nextWormPart.distanceTravelled -1;
        }
        else
        {
            wormPartType = WormPartType.Head;
        }
    }

    void Update()
    {
        switch (wormPartType)
        {
            case WormPartType.Head:
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                break;
            case WormPartType.Body:
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                //transform.position = nextPart.GetComponent<PathFollow>().pathCreator.path.GetPointAtDistance(distanceTravelled);
                //transform.rotation = nextPart.GetComponent<PathFollow>().pathCreator.path.GetRotationAtDistance(distanceTravelled);
                break;
        }
        distanceTravelled += speedTravelled * Time.deltaTime;
    }
}

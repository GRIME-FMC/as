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
        Vector3 pcV = pathCreator.path.GetPointAtDistance(distanceTravelled);
        Quaternion pcQ = pathCreator.path.GetRotationAtDistance(distanceTravelled); ;

        transform.position = pcV;// new Vector3(pcV.x, 0.5f, pcV.z);
        transform.rotation = pcQ;
        switch (wormPartType)
        {
            //case WormPartType.Head:

            //    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            //    Quaternion q = pathCreator.path.GetRotationAtDistance(distanceTravelled);
            //    transform.rotation = new Quaternion(q.x,0,q.z,0);
            //    break;
            //case WormPartType.Body:
            //    Quaternion qq = pathCreator.path.GetRotationAtDistance(distanceTravelled);
            //    transform.rotation = new Quaternion(qq.x, 0, qq.z, 0);
            //    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            //    transform.rotation = qq;
            //    //transform.position = nextPart.GetComponent<PathFollow>().pathCreator.path.GetPointAtDistance(distanceTravelled);
            //    //transform.rotation = nextPart.GetComponent<PathFollow>().pathCreator.path.GetRotationAtDistance(distanceTravelled);
            //    break;
        }
        distanceTravelled += speedTravelled * Time.deltaTime;
    }
}

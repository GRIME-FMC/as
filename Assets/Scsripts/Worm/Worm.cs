using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Worm : MonoBehaviour
{
    [SerializeField] private List<GameObject> wormParts;


    public void AddWormPart(GameObject wormPart)
    {
        if (wormPart != null) wormParts.Add(wormPart);
    }

    public GameObject GetWormPart(int num)
    {
        if (num > 0 && num < wormParts.Count) return wormParts[num];
        return null;
    }

    public void DestroyPart(int removeIndex)
    {
        //STOP TRAVEL
        Debug.Log("INDEX : " + removeIndex);
        for (int i = wormParts.Count - 1; i > removeIndex; i--)
        {
            wormParts[i].GetComponent<WormPart>().distanceTravelled--;
            wormParts[i].GetComponent<WormPart>().index--;
            //wormParts[i].GetComponentInChildren<TextMeshPro>().text = "" + wormParts[i].GetComponent<WormPart>().index;
        }
        GameObject tGO = wormParts[removeIndex].gameObject;
        wormParts.RemoveAt(removeIndex);
        Destroy(tGO);
        //RELINK

        for (int i = 0; i < wormParts.Count; i++) 
        {

        }
        //RESUME TRAVEl       
    }
}

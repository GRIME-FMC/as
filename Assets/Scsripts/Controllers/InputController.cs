using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log(hit.transform.name);
                if (hit.transform.tag == "WormPart") 
                {
                    hit.transform.parent.GetComponent<Worm>().DestroyPart(hit.transform.GetComponent<WormPart>().index);
                }
            }
        }
    }
}

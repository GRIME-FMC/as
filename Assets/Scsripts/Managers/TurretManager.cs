using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float coolDown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown < 0f)
        {
            Instantiate(bulletPrefab, Input.mousePosition, Quaternion.identity);
            coolDown = 1f;
        }
        else { 
            coolDown -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button 0 is pressed");
            
        }
    }
}

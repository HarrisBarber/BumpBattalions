using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SelectUnder()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + new Vector3(0.0f, 0.1f));
        if (hit)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
}

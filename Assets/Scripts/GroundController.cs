using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private bool isCarUpTriggered = false;
    private static GroundController _instance;
    public Rigidbody2D carObject;
    public static GroundController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsCarUpTriggered()
    {
        return isCarUpTriggered;
    }
    

    
    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ground Trigger " + other.collider.tag );
        isCarUpTriggered = other.collider.tag == "CarUp";
        
      // if (other.collider.CompareTag("CarFront"))
      //   {
      //       carObject.velocity = Vector2.zero;
      //       carObject.AddForce(new Vector2(0,100));
      //   }  
      /*
        else if (other.collider.CompareTag("CarBack"))
        {
            carObject.AddForce(transform.up * 10000);
        }*/
    }
}

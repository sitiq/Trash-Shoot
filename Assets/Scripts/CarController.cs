using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backWheel;
    public Rigidbody2D frontWheel;
    public float wheelSpeed = 5f;
    public float upForce = 30f;
    private static CarController _instance;
    public static CarController Instance { get { return _instance; } }
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

    public void MoveForward(float speed)
    {
        backWheel.AddTorque(-GetFixedSpeed(speed));
        frontWheel.AddTorque(-GetFixedSpeed(speed));
        if (speed >0.5)
        {
            frontWheel.AddForce(transform.up * upForce );
        }
    }

    float GetFixedSpeed(float speed)
    {
        return (speed * wheelSpeed);
    }

    public void ClearTorque()
    {
        backWheel.angularVelocity = 0;
        frontWheel.angularVelocity = 0;

    }

    public void MoveBackward(float speed)
    {
        backWheel.AddTorque(GetFixedSpeed(speed));
        frontWheel.AddTorque(GetFixedSpeed(speed));
        if (speed >0.5)
        {
            frontWheel.AddForce(-transform.up * upForce);
        } 
    }
    
}

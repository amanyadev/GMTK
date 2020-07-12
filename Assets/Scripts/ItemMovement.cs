using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{

    public float _xspeed = 0f;
    public float _yspeed = -1f;
    Rigidbody2D _rb;
    Vector3 direction;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       transform.Translate(_xspeed * Time.deltaTime,_yspeed * Time.deltaTime,0);
       if(transform.position.y < -6)
       {
           Destroy(this.gameObject);
       }
    }
}

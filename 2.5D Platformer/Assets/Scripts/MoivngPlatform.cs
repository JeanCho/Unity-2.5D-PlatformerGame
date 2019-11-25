using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoivngPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _positionA;
    [SerializeField]
    private Transform _positionB;
    [SerializeField]
    private float _speed = 5.0f;
    private bool _goBack = false;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = _speed * Time.deltaTime;

        if(_goBack == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionB.position, step);

        }
        else if(_goBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionA.position, step);

        }

        if (this.transform.position == _positionA.position)
        {
            _goBack = false;
            
        }

        else if (this.transform.position == _positionB.position)
        {
            _goBack = true;

        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
            Debug.Log("Collided");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}

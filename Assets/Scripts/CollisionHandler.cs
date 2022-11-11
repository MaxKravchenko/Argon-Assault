using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{   
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name);    
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");    
    }
}

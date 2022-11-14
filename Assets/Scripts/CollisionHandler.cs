using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    //PARAMETERS
    [SerializeField] float levelLoadDelay = 1f;
    
    //STATE
    bool isTransitioning = false;


    private void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) { return;}
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name);
        StartCrashSequence();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(isTransitioning) { return;}
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");
        StartCrashSequence();    
    }

    void StartCrashSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        isTransitioning = true;
        //audioSource.Stop();
        GetComponent<PlayerControls>().enabled = false;
        //audioSource.PlayOneShot(crash);
        //crashParticle.Play();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

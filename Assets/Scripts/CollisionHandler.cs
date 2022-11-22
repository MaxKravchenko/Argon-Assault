using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    //PARAMETERS
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] ParticleSystem crashParticle;
    
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
        crashParticle.Play();
        
        //each child's mesh mesh renderer to false
        MeshRenderer[] rs = GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer r in rs)
            r.enabled = false;
            
        GetComponent<BoxCollider>().enabled = false;
        isTransitioning = true;
        //audioSource.Stop();
        GetComponent<PlayerControls>().enabled = false;
        //audioSource.PlayOneShot(crash);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

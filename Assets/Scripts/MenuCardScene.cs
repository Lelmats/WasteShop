using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCardScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with has a specific tag
        if (collision.gameObject.CompareTag("cardStart"))
        {
            Debug.Log("Card collided with cardStart");
            ChangeSceneF();
        }
    }
    public void ChangeSceneF(){
        SceneManager.LoadScene("VideoInicial(Spanish)");
    }
}

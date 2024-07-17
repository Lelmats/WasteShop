using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneIntro : MonoBehaviour
{
    void Start(){
      ChangeSceneIntroTime();
    }
    private void ChangeSceneEvent(){
		SceneManager.LoadScene("MainScene");
    }
    public void ChangeSceneIntroTime(){
        Invoke("ChangeSceneEvent", 30f);
    }

}
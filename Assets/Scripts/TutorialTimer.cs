using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTimer : MonoBehaviour
{
    public GameObject tutorialTimer;
    // Start is called before the first frame update
    void Start(){
      TimerTutorialStart();
    }
    private void TimerTutorial(){
		tutorialTimer.SetActive(false);
    }
    public void TimerTutorialStart(){
        Invoke("ChangeSceneEvent", 10f);
    }
}

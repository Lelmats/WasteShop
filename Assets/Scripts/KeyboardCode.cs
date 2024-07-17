using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KeyboardCode : MonoBehaviour
{
    // public GameObject keyboard_user;
    public GameObject keyboard_pass;
    // Start is called before the first frame update
    private void KeyboardActivePassPre()
    {
        keyboard_pass.SetActive(true);
    }
    public void KeyboardActivePass()
    {
        Invoke("KeyboardActivePassPre", 1f);
    }
}

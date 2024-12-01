using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Transition sceneTransition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        sceneTransition.LoadLevel("Main_Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] public GameObject setActiveHolder;

    [SerializeField] public bool hasAnimation;

    private bool inCollider;
    private bool canPlayAnimation;

    private TriggerAnimation triggerAnimation;

    [SerializeField] AudioSource doorOpenSound;
    [SerializeField] AudioSource doorCreakingSound;

    // Start is called before the first frame update
    void Start()
    {
        inCollider = false;
        canPlayAnimation = true;
        triggerAnimation = GetComponent<TriggerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inCollider)
        {
            setActiveHolder.SetActive(true);
            if(hasAnimation && canPlayAnimation)
            {
                Debug.Log("Playing Animation...");
                canPlayAnimation = false;
                triggerAnimation.PlayAnimation();
                StartCoroutine(playDoorAudio());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = false;
        }
    }

    IEnumerator playDoorAudio()
    {
        doorOpenSound.Play();
        doorCreakingSound.Play();
        yield return new WaitForSeconds(3.2f);
        doorCreakingSound.Stop();
        doorOpenSound.Play();
    }
}

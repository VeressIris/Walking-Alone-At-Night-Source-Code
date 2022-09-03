using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private TypewriterEffect typewriterScript;

    private AudioSource audioSource;

    [SerializeField] private GameObject invisibleWall;
    [SerializeField] private GameObject rightInvisibleWall;

    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    private PlayerFootsteps playerFootsteps;

    void Start()
    {
        typewriterScript = text.GetComponent<TypewriterEffect>();

        audioSource = GetComponent<AudioSource>();
        
        text.SetActive(false);

        invisibleWall.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            StartCoroutine("ShowAndHideText");

            audioSource.Play();
            
            playerMovement = player.GetComponent<PlayerMovement>();
            playerLook = player.GetComponentInChildren<PlayerLook>();
            playerFootsteps = player.GetComponent<PlayerFootsteps>();
            DisablePlayerControl();

            invisibleWall.SetActive(true);
            rightInvisibleWall.transform.position = new Vector3(0f, 0f, 93f);
        }
    }

    IEnumerator ShowAndHideText()
    {
        text.SetActive(true);

        typewriterScript.StartCoroutine("TypeText");

        yield return new WaitForSeconds(8.5f);

        text.SetActive(false);

        EnablePlayerControl();
    }

    private void DisablePlayerControl()
    {
        playerMovement.enabled = false;
        playerLook.enabled = false;
        playerFootsteps.enabled = false;
    }
    
    private void EnablePlayerControl()
    {
        playerMovement.enabled = true;
        playerLook.enabled = true;
        playerFootsteps.enabled = true;
    }
}

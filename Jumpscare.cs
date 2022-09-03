using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerLook playerLook;

    private GameObject scaryModel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    

        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerLook = player.GetComponent<PlayerLook>();

        scaryModel = GameObject.Find("low poly character");
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            audioSource.PlayOneShot(audioClips[0]); //play woman screaming
            audioSource.PlayOneShot(audioClips[1], 0.7f); //play piano hit

            Destroy(playerMovement);
            Destroy(playerLook);

            scaryModel.transform.position = new Vector3(player.transform.position.x + 0.815f, -0.362f, player.transform.position.z); //places it in front of the player
            scaryModel.transform.rotation = Quaternion.Euler(0, 270, 0); //rotates it to face the player

            StartCoroutine("LoadNextScene");
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(4.5f);
        
        SceneManager.LoadScene("Thanks");
    }
}

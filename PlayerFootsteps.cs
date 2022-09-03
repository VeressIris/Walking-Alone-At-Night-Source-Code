using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] AudioClip[] footsteps;
    private AudioSource audioSource;

    private CharacterController characterController;

    private AudioClip footstepClip;

    private float minVol = 0.4f;
    private float maxVol = 0.85f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float magnitude = characterController.velocity.sqrMagnitude;
        if (magnitude > 0 && !audioSource.isPlaying)
        {
            audioSource.clip = footsteps[Random.Range(0, footsteps.Length)];
            audioSource.volume = Random.Range(minVol, maxVol);
            audioSource.Play();
        }
    }
}

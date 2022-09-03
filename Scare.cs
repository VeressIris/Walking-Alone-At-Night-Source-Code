using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Scare : MonoBehaviour
{
    private GameObject scaryModel;
    private Animator modelAnimator;
    [SerializeField] private string pose;

    private Transform newPositionPoint;

    private AudioSource audioSource;
    [SerializeField] private AudioClip soundEffect;

    [SerializeField] private bool wantToStopPlaying;
    [SerializeField] private float stopTime;

    [SerializeField] private bool wantToDelayStart;
    [SerializeField] private float startDelayTime = 0f;

    void Start()
    {
        scaryModel = GameObject.Find("low poly character");
        modelAnimator = scaryModel.GetComponent<Animator>();

        newPositionPoint = gameObject.transform.Find("Model Point");

        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {            
            PlaySoundEffect();
            
            scaryModel.transform.position = newPositionPoint.transform.position;
            scaryModel.transform.rotation = newPositionPoint.transform.rotation * Quaternion.Euler(0f, 180f, 0f); //rotates the model at the same angle as the position point
            
            modelAnimator.Play(pose);
        }
    }

    void PlaySoundEffect()
    {
        if (wantToDelayStart)
        {
            StartCoroutine("StartPlaying");
        }
        else
        {
            audioSource.PlayOneShot(soundEffect);
        }

        if (wantToStopPlaying)
        {
            StartCoroutine("StopPlaying");
        }
    }

    IEnumerator StartPlaying()
    {
        yield return new WaitForSeconds(startDelayTime);

        audioSource.PlayOneShot(soundEffect);
    }

    IEnumerator StopPlaying()
    {
        yield return new WaitForSeconds(stopTime);

        audioSource.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CharacterDisappear : MonoBehaviour
{
    private GameObject scaryModel;

    void Start()
    {
        scaryModel = GameObject.Find("low poly character");
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            scaryModel.transform.position = new Vector3(scaryModel.transform.position.x, -100f, scaryModel.transform.position.z);
        }
    }
}

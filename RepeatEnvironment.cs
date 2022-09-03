using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerMovement playerScript;

    [SerializeField] private float platformSize = 107.075f;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerScript.nextPlatform)
        {
            StartCoroutine("MovePlatform");
        }
    }

    IEnumerator MovePlatform()
    {
        yield return new WaitForSeconds(5f);

        Transform currentPlatformPos = playerScript.trigger.transform;
        transform.position = new Vector3(0f, 0f, currentPlatformPos.position.z + platformSize);
        
        playerScript.nextPlatform = false;
        
        playerScript.trigger.AddComponent<RepeatEnvironment>();
        Destroy(this);
    }
}

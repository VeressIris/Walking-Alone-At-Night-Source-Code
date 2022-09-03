using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float speed = 10f;

    public bool nextPlatform = false;

    public GameObject trigger;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.right * x + transform.forward * z;

        characterController.Move(moveDir * speed * Time.deltaTime);
    }

    //Preparing to move the previous platform forward
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Platform Trigger")
        {
            nextPlatform = true;
            trigger = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        collider.isTrigger = false;

        StartCoroutine(SetTrigger(collider)); //re-enables trigger collider
    }

    IEnumerator SetTrigger(Collider collider)
    {
        yield return new WaitForSeconds(8);

        collider.isTrigger = true;
    }
}

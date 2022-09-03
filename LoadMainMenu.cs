using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadMainMenu : MonoBehaviour
{
    private TypewriterEffect typewriterScript;
    [SerializeField] private TMP_Text text;

    void Awake()
    {
        typewriterScript = text.GetComponent<TypewriterEffect>();
    }

    IEnumerator Start()
    {
        typewriterScript.StartCoroutine("TypeText");

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Main Menu");
    }
}

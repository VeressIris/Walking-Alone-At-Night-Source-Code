using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private string textToType;
    [SerializeField] private TMP_Text textLabel;

    private float speed = 7f;


    public IEnumerator TypeText()
    {
        float time = 0f;
        int characterIndex = 0;

        while (characterIndex < textToType.Length)
        {
            time += Time.deltaTime * speed;
            characterIndex = Mathf.FloorToInt(time);
            characterIndex = Mathf.Clamp(characterIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, characterIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}

using System.Collections;
using TMPro;
using UnityEngine;

public class DialogPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [SerializeField] private float _timeBetweenCharacters;

    public void SetText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(ShowText(text));
    }

    private IEnumerator ShowText(string text)
    {
        int totalCharacters = text.Length;

        string currentText = "";
        for (int i = 0; i < totalCharacters; i++)
        {
            currentText += text[i];
            _text.text = currentText;
            yield return new WaitForSeconds(_timeBetweenCharacters);
        }
    }
}

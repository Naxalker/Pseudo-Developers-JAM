using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogPanel : MonoBehaviour, IPointerClickHandler
{
    public event Action TextIsSet;

    [SerializeField] private TMP_Text _text;

    [SerializeField] private float _timeBetweenCharacters;

    private bool _isWriting, _instantShow;

    public void SetText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(ShowText(text));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_isWriting)
        {
            _instantShow = true;
        }
    }

    private IEnumerator ShowText(string text)
    {
        _isWriting = true;

        int totalCharacters = text.Length;

        string currentText = "";
        for (int i = 0; i < totalCharacters; i++)
        {
            currentText += text[i];
            _text.text = currentText;

            if (_instantShow)
            {
                _instantShow = false;
                _text.text = text;
                break;
            } else
            {
                yield return new WaitForSeconds(_timeBetweenCharacters);
            }
        }

        _isWriting = false;
        TextIsSet?.Invoke();
    }
}

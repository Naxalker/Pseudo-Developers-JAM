using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PanelImage : MonoBehaviour
{
    private const float AppearDuration = .5f;

    [SerializeField] private RectTransform _startTransform, _endTransform;

    private Image _choiceImage;
    private Vector3 _startPos, _endPos;
    private Vector3 _startRot, _endRot;

    private void Start()
    {
        _choiceImage = GetComponent<Image>();

        _startPos = _startTransform.anchoredPosition;
        _endPos = _endTransform.anchoredPosition;

        _startRot = _startTransform.rotation.eulerAngles;
        _endRot = _endTransform.rotation.eulerAngles;
    }

    public void Appear()
    {
        _choiceImage.rectTransform.DOAnchorPos(_endPos, AppearDuration);
        _choiceImage.rectTransform.DORotate(_endRot, AppearDuration);
        _choiceImage.DOFade(.5f, AppearDuration);
    }

    public void Disappear()
    {
        _choiceImage.rectTransform.DOAnchorPos(_startPos, AppearDuration);
        _choiceImage.rectTransform.DORotate(_startRot, AppearDuration);
        _choiceImage.DOFade(0f, AppearDuration);
    }
}

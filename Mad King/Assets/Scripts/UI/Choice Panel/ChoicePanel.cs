using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChoicePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private const float FadeDuration = 1.0f;

    [SerializeField] private PanelImage _panelImage;
    [SerializeField] private TMP_Text _leftPanelText;

    public void SetText(string text)
        => _leftPanelText.text = text;

    public void Activate()
    {
        _leftPanelText.DOFade(1f, FadeDuration).OnComplete(() => GetComponent<Image>().enabled = true);
    }

    public void Deactivate()
    {
        GetComponent<Image>().enabled = false;
        _panelImage.Disappear();
        _leftPanelText.DOFade(0f, FadeDuration);
    }

    public void OnPointerEnter(PointerEventData eventData)
        => _panelImage.Appear();

    public void OnPointerExit(PointerEventData eventData)
        => _panelImage.Disappear();
}

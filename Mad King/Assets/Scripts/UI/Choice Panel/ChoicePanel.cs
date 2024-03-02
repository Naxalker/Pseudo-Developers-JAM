using UnityEngine;
using UnityEngine.EventSystems;

public class ChoicePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PanelImage _panelImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _panelImage.Appear();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _panelImage.Disappear();
    }
}

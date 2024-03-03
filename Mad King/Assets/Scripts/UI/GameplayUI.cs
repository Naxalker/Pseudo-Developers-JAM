using TMPro;
using UnityEngine;
using Zenject;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private DialogPanel _dialogPanel;
    [SerializeField] private ChoicePanel _leftChoicePanel;
    [SerializeField] private ChoicePanel _rightChoicePanel;

    private SceneGameplayUIMediator _gameplayUIMediator;

    [Inject]
    private void Construct(SceneGameplayUIMediator gameplayUIMediator)
    {
        _gameplayUIMediator = gameplayUIMediator;
    }

    private void OnEnable()
    {
        _dialogPanel.TextIsSet += OnDialogTextIsSet;
    }

    private void OnDisable()
    {
        _dialogPanel.TextIsSet -= OnDialogTextIsSet;
    }

    public void SetText(string dialogText, string leftDialogText, string rightDialogText)
    {
        _dialogPanel.SetText(dialogText);
        _leftChoicePanel.SetText(leftDialogText);
        _rightChoicePanel.SetText(rightDialogText);
    }

    public void SetScene(int panelIndex)
    {
        _gameplayUIMediator.LoadNextScene(panelIndex);
    }

    private void OnDialogTextIsSet()
    {
        _leftChoicePanel.Activate();
        _rightChoicePanel.Activate();
    }
}

using TMPro;
using UnityEngine;
using Zenject;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private DialogPanel _dialogPanel;
    [SerializeField] private TMP_Text _leftDialogText;
    [SerializeField] private TMP_Text _rightDialogText;

    private SceneGameplayUIMediator _gameplayUIMediator;

    [Inject]
    private void Construct(SceneGameplayUIMediator gameplayUIMediator)
    {
        _gameplayUIMediator = gameplayUIMediator;
    }

    public void SetText(string dialogText, string leftDialogText, string rightDialogText)
    {
        _dialogPanel.SetText(dialogText);
        _leftDialogText.text = leftDialogText;
        _rightDialogText.text = rightDialogText;
    }

    public void SetScene(int panelIndex)
    {
        _gameplayUIMediator.LoadNextScene(panelIndex);
    }
}

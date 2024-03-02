using System;
using Zenject;

public class SceneGameplayUIMediator
{
    private GameplayUI _gameplayUI;
    private ScenesController _scenesController;

    private int _leftOptionIndex, _rightOptionIndex;

    public SceneGameplayUIMediator(GameplayUI gameplayUI, ScenesController scenesController)
    {
        _gameplayUI = gameplayUI;
        _scenesController = scenesController;
    }

    public void UpdateUIData(SceneSO sceneData)
    {
        _gameplayUI.SetText(sceneData.DialogText, sceneData.LeftOptionText, sceneData.RightOptionText);

        _leftOptionIndex = sceneData.LeftOptionIndex;
        _rightOptionIndex = sceneData.RightOptionIndex;
    }

    public void LoadNextScene(int panelIndex)
    {
        if (panelIndex == 0)
            _scenesController.SetScene(_leftOptionIndex);
        else if (panelIndex == 1)
            _scenesController.SetScene(_rightOptionIndex);
    }
}

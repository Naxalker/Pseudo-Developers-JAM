using UnityEngine;
using Zenject;

public class Scene : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private SpriteRenderer _hero;
    [SerializeField] private SpriteRenderer _firstVisitor;
    [SerializeField] private SpriteRenderer _secondVisitor;

    [SerializeField] private GameplayUI _gameplayText;

    private SceneGameplayUIMediator _mediator;

    [Inject]
    private void Construct(SceneGameplayUIMediator mediator)
    {
        _mediator = mediator;
    }

    public void SetScene(SceneSO sceneData)
    {
        _background.sprite = sceneData.BackgroundImage;
        _hero.sprite = sceneData.HeroSprite;
        _firstVisitor.sprite = sceneData.LeftVisitorSprite;
        _secondVisitor.sprite = sceneData.RightVisitorSprite;

        _mediator.UpdateUIData(sceneData);
    }
}

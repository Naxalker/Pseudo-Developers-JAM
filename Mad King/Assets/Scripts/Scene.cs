using DG.Tweening;
using UnityEngine;
using Zenject;

public class Scene : MonoBehaviour
{
    private float FadeDuration = .5f;

    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private SpriteRenderer _hero;
    [SerializeField] private SpriteRenderer _leftVisitor;
    [SerializeField] private SpriteRenderer _rightVisitor;

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
        _background.DOFade(1f, FadeDuration);

        _hero.sprite = sceneData.HeroSprite;
        _hero.DOFade(1f, FadeDuration);

        _leftVisitor.sprite = sceneData.LeftVisitorSprite;
        _leftVisitor.DOFade(1f, FadeDuration);

        _rightVisitor.sprite = sceneData.RightVisitorSprite;
        _rightVisitor.DOFade(1f, FadeDuration);

        _mediator.UpdateUIData(sceneData);
    }

    public void ClearScene()
    {
        _background.DOFade(0f, FadeDuration);
        _hero.DOFade(0f, FadeDuration);
        _leftVisitor.DOFade(0f, FadeDuration);
        _rightVisitor.DOFade(0f, FadeDuration);
    }
}

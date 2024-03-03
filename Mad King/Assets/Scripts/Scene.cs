using DG.Tweening;
using UnityEngine;
using Zenject;

public class Scene : MonoBehaviour
{
    private float FadeDuration = .5f;
    private float ScaleDuration = 1f;

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
        _hero.transform.DOScale(1.3f, ScaleDuration).SetEase(Ease.OutElastic);

        _leftVisitor.sprite = sceneData.LeftVisitorSprite;
        _leftVisitor.transform.DOScale(1f, ScaleDuration).SetEase(Ease.OutElastic);

        _rightVisitor.sprite = sceneData.RightVisitorSprite;
        _rightVisitor.transform.DOScale(1f, ScaleDuration).SetEase(Ease.OutElastic);

        _mediator.UpdateUIData(sceneData);
    }

    public void ClearAndSet(SceneSO sceneData)
    {
        Sequence fadeSequence = DOTween.Sequence();

        if (sceneData.BackgroundImage != _background.sprite)
            fadeSequence.Join(_background.DOFade(0f, FadeDuration));

        if (sceneData.HeroSprite != _hero.sprite)
            fadeSequence.Join(_hero.transform.DOScale(0f, ScaleDuration).SetEase(Ease.OutQuart));

        if (sceneData.LeftVisitorSprite != _leftVisitor.sprite)
            fadeSequence.Join(_leftVisitor.transform.DOScale(0f, ScaleDuration).SetEase(Ease.OutQuart));

        if (sceneData.RightVisitorSprite != _rightVisitor.sprite)
            fadeSequence.Join(_rightVisitor.transform.DOScale(0f, ScaleDuration).SetEase(Ease.OutQuart));

        fadeSequence.OnComplete(() => SetScene(sceneData));
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Scene", menuName = "SceneSO/Scene")]
public class SceneSO : ScriptableObject
{
    [field: SerializeField, Min(0)] public int Id { get; private set; }

    [Header("Sprites")]
    [field: SerializeField] public Sprite BackgroundImage;
    [field: SerializeField] public Sprite HeroSprite;
    [field: SerializeField] public Sprite LeftVisitorSprite;
    [field: SerializeField] public Sprite RightVisitorSprite;

    [Header("Options")]
    [field: SerializeField, TextArea(3, 5)] public string DialogText;
    [field: SerializeField, TextArea(3, 5)] public string LeftOptionText;
    [field: SerializeField, TextArea(3, 5)] public string RightOptionText;
    [field: SerializeField, Min(0)] public int LeftOptionIndex;
    [field: SerializeField, Min(0)] public int RightOptionIndex;
}

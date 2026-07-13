
using UnityEngine;
using UnityEngine.UI;

public class ClothingChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] _femaleClothingSprites;
    [SerializeField] private Sprite[] _maleClothingSprites;
    [SerializeField] private Image[] _clothingImages;

    [SerializeField] private ModelTogglers _modelTogglers;

    private void OnEnable()
    {
        _modelTogglers.MaleModelChoosed += ChangeSprites;
    }

    private void OnDisable()
    {
        _modelTogglers.MaleModelChoosed -= ChangeSprites;
    }

    private void ChangeSprites(bool isMaleSprites)
    {
        Sprite currentSprite;

        for(int i = 0;i < _femaleClothingSprites.Length; i++)
        {
            currentSprite = isMaleSprites ? _maleClothingSprites[i] : _femaleClothingSprites[i];

            _clothingImages[i].sprite = currentSprite;
        }
    }
}


using Unity.VisualScripting;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    [SerializeField] private ModelChanger _modelChanger;
    [SerializeField] private ClothingChanger _clothingChanger;
    [SerializeField] private MainAudio _mainAudio;
    [SerializeField] private BackGroundChanger _backgroundChanger;

    private void Start()
    {
        LoadAll();
    }

    private void LoadAll()
    {
        _clothingChanger.SetDefaulReset(false);

        _mainAudio.ChangeVolume(PlayerPrefs.GetFloat(PrefsKeys.VolumeKey,1));

        _modelChanger.ChangeModel(PlayerPrefs.GetInt(PrefsKeys.ChoosedCharacterKey,1));

        _clothingChanger.ChangeSpriteSet(PlayerPrefs.GetInt(PrefsKeys.ChoosedClothingSetKey,1),
            PlayerPrefs.GetInt(PrefsKeys.ChoosedAppearanceKey,1));

        _backgroundChanger.ChangeBackground(PlayerPrefs.GetInt(PrefsKeys.BackgroundDisabledKey, 0) == 0 ? false : true);

        _clothingChanger.SetDefaulReset(true);
    }
}

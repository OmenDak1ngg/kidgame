using UnityEngine;

public static class SaveSystem
{
    public static void SaveMainVolume(float value)
    {
        PlayerPrefs.SetFloat(PrefsKeys.VolumeKey, value);
        PlayerPrefs.Save();
    }

    public static void SaveCharacterNumber(int number)
    {
        PlayerPrefs.SetInt(PrefsKeys.ChoosedCharacterKey, number); 
        PlayerPrefs.Save();
    }

    public static void SaveClothingNumber(int number)
    {
        PlayerPrefs.SetInt(PrefsKeys.ChoosedClothingSetKey,number);
        PlayerPrefs.Save();
    }

    public static void SaveAppearanceNumber(int number)
    {
        PlayerPrefs.SetInt(PrefsKeys.ChoosedAppearanceKey,number);
        PlayerPrefs.Save();
    }
}

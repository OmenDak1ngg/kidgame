using System;
using UnityEngine;

public class CharacterAppearance : MonoBehaviour
{
    [SerializeField] private Sprite[] _firstSpriteSet;
    [SerializeField] private Sprite[] _secondSpriteSet;

    public Sprite[] GetSpiteSet(int numberOfSet)
    {
        switch (numberOfSet)
        {
            case 1:
                return _firstSpriteSet;

            case 2:
                return _secondSpriteSet;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

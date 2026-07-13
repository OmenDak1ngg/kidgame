using UnityEngine;

public class ClothingPositioner : MonoBehaviour
{
    [SerializeField] private CloseButton _parametresCloseButton;    
    
    [SerializeField] private Clothing[] _clothings;
    [SerializeField] private ClothingStartPosition[] _startPositions;

    private void Awake()
    {
        MoveToStartPosition();
    }

    private void OnEnable()
    {
        _parametresCloseButton.Clicked += MoveToStartPosition;
    }

    private void OnDisable()
    {
        _parametresCloseButton.Clicked -= MoveToStartPosition;
    }

    private void MoveToStartPosition()
    {
        for (int i = 0; i < _clothings.Length; i++)
        {
            _clothings[i].GetComponent<RectTransform>().position =
                _startPositions[i].GetComponent<RectTransform>().position;
        }
    }
}


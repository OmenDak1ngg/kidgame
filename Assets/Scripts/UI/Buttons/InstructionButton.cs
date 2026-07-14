using UnityEngine;

public class InstructionButton : UIButton
{
    [SerializeField] private UIWindow _instructionWindow;

    protected override void OnClick()
    {
        base.OnClick();
        _instructionWindow.gameObject.SetActive(true);
    }
}

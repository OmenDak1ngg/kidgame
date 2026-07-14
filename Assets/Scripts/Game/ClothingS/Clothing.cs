using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DragDrop))]
public class Clothing : HighlightObject
{
    [SerializeField] private ClothingTypes _type;

    public ClothingTypes Type => _type;

    protected override void Awake()
    {
        base.Awake();
    }
}
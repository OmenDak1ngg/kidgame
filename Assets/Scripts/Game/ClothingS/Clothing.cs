using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DragDrop))]
public class Clothing : MonoBehaviour, IHiglightable
{
    [SerializeField] private ClothingTypes _type;

    public ClothingTypes Type => _type;
}
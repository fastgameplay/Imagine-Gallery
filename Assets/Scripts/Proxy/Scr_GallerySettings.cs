using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Gallery Settings")]
public class Scr_GallerySettings : ScriptableObject
{
    public Vector2 AutoLoadRange;
    [SerializeField] Vector2 _autoLoadRange;
}

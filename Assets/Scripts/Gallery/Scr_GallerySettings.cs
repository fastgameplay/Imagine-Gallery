using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Gallery Settings")]
public class Scr_GallerySettings : ScriptableObject
{
    public Vector2Int AutoLoadRange => _autoLoadRange;
    [SerializeField] Vector2Int _autoLoadRange;
    public GalleryImage GalleryImagePrefab => _galleryImagePrefab;
    [SerializeField] GalleryImage _galleryImagePrefab;
}

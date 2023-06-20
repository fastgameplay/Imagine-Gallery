using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryInitialize : MonoBehaviour
{
    [SerializeField] Scr_GallerySettings _gallerySettings;
    void Start(){
        for (int i = _gallerySettings.AutoLoadRange.x; i <= _gallerySettings.AutoLoadRange.y; i++){
            Instantiate(_gallerySettings.GalleryImagePrefab,Vector3.zero, Quaternion.identity, transform).UpdateID(i);
        }
    }
}

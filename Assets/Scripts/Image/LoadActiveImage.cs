using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(GalleryImage))]
public class LoadActiveImage : MonoBehaviour
{
    GalleryImage _currentGalleryImage;
    void Awake(){
        _currentGalleryImage = GetComponent<GalleryImage>();
    }
    
    void Start(){
        int id = PlayerPrefs.GetInt(nameof(PlayerPrefKeys.ActiveImageID),-1);
        if(id == -1) {
            Debug.LogError($"PlayerPrefs isn't containing value of {nameof(PlayerPrefKeys.ActiveImageID)}");
            SceneLoader.Instance.LoadScene(1);
        }
        _currentGalleryImage.UpdateID(id);
    }
}
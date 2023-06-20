using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RawImage))]
public class TempImage : MonoBehaviour
{
    [SerializeField] int _id = -1;
    ImageProxy _proxy;
    RawImage _currentRawImage;
    void Awake(){
        _currentRawImage = GetComponent<RawImage>();
        _proxy = ImageProxy.Instance;
    }
    void Start(){
        GetAndSetTexture();
    }
    
    void TextureUpdate(int id){
        if(id != _id) return;
        GetAndSetTexture();

    }
    void TextureNotFound(int id){
        if(id != _id) return;
        Debug.Log($"Texture Of ID {_id} Not Found");
        Destroy(gameObject);
    }


    void GetAndSetTexture(){
        _currentRawImage.texture = _proxy.GetRawTexture(_id);
    }


    void OnEnable(){
        _proxy.OnTextureUpdate += TextureUpdate;
        _proxy.OnTextureNotFound += TextureNotFound;
    }
    void OnDisable(){
        _proxy.OnTextureUpdate -= TextureUpdate;
        _proxy.OnTextureNotFound -= TextureNotFound;
    }
}

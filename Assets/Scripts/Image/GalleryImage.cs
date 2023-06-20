using UnityEngine;
using UnityEngine.UI;
public class GalleryImage : MonoBehaviour
{
    int _id;
    RawImage _currentRawImage;
    void Awake(){
        _currentRawImage = GetComponent<RawImage>();
    }

    public void UpdateID(int id){
        _id = id;
        gameObject.name = $"Gallery Image {id}";
        UpdateTexture();
    }
    void UpdateTexture(){
        _currentRawImage.texture = ImageProxy.Instance.GetRawTexture(_id);
    }
    void TextureUpdate(int id){
        if(id != _id) return;
        UpdateTexture();
    }
    void TextureNotFound(int id){
        if(id != _id) return;
        Debug.Log($"Texture Of ID {_id} Not Found");
        Destroy(gameObject);
    }

    void OnEnable(){
        ImageProxy.Instance.OnTextureUpdate += TextureUpdate;
        ImageProxy.Instance.OnTextureNotFound += TextureNotFound;
    }
    void OnDisable(){
        ImageProxy.Instance.OnTextureUpdate -= TextureUpdate;
        ImageProxy.Instance.OnTextureNotFound -= TextureNotFound;
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GalleryImage : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData){
        PlayerPrefs.SetInt(nameof(PlayerPrefKeys.ActiveImageID),_id);
        SceneLoader.Instance.LoadScene(2);
    }

    void TextureUpdate(int id){
        if(id != _id) return;
        UpdateTexture();
    }
    void TextureNotFound(int id){
        if(id != _id) return;
        Debug.LogWarning($"Texture Of ID {_id} Not Found");
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

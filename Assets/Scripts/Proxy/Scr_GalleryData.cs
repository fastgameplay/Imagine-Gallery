using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/GalleryData")]
public class Scr_GalleryData : ScriptableObject
{
    private Dictionary<int,Texture> gallery = new Dictionary<int, Texture>();

    public bool HasTexture(int id){
        return gallery.ContainsKey(id);
    }
    public Texture GetTexture(int id){
        return gallery[id];
    }
    public void AddTexture(Texture texture, int id){
        gallery.Add(id, texture);
    }
    public void Reset(){
        gallery = new Dictionary<int, Texture>();
    }

}

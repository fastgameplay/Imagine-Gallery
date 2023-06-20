using UnityEngine;
[CreateAssetMenu(menuName = "Data/UrlData")]
public class Scr_UrlData : ScriptableObject
{
    
    public string Url => _url;
    public string Suffix => _suffix;
    
    [SerializeField] private string _url;
    [SerializeField] private string _suffix;
}

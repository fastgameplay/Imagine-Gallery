using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image _fillImage;
    
    public float Progress{
        set{
            _fillImage.fillAmount = Mathf.Clamp01(value);
        }
    }
}

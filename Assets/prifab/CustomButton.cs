using UnityEngine.UI;
using UnityEngine;

public class CustomButton : MonoBehaviour
{
    [SerializeField,Range(0f,1f)] private float _alpha=0.1f;

    private void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = _alpha;
        
        
    }
}

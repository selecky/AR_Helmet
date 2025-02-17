using TMPro;
using UnityEngine;

namespace Canvas
{
    public class InfoTextScript : MonoBehaviour
    {
        private void Awake()
        {
            TextMeshProUGUI textComponent = GetComponent<TextMeshProUGUI>();
            textComponent.text = "Move camera slowly to detect planes.";
        }
    }
}
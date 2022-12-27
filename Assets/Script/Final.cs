using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    [SerializeField] Text caseText;
    [SerializeField] GameObject retryButton;

    void Start()
    {
            caseText.text = "Oyunu Tamamlad�n�z.Tebrikler!";
            retryButton.gameObject.SetActive(true);
    }
}

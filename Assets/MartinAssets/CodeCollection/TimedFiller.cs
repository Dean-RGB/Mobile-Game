using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedFiller : MonoBehaviour
{
    [Header("Image")]
    public Image Image;

    [Header("Wait fors")]
    public float SecondsToWait;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
      button =  Image.GetComponent<Button>();
    }

    public void PressButton()
    {  
        Image.fillAmount = 0;
        button.enabled = false;
        StartCoroutine(Move.Instance.BoostCharacter());
        StartCoroutine(FillAmmountIncrease());
    }

    private IEnumerator FillAmmountIncrease()
    {
        while (Image.fillAmount < 1.0f)
        {
            Image.fillAmount  += SecondsToWait / 100;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        button.enabled = true;

        yield break;
    }
}
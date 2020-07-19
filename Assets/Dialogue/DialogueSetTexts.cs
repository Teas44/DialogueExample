using UnityEngine;
using UnityEngine.UI;
public class DialogueSetTexts : MonoBehaviour
{
    public GameObject text;
    public GameObject components;
    public GameObject button;

    public GameObject img;

    public void setText(string v)
    {
        text.GetComponent<TypeWriterEffect>().setFullText(v);
    }

    public void setComponentsActive(bool v)
    {
        components.SetActive(v);
    }

    public void setImg(Sprite v)
    {
        img.GetComponent<Image>().sprite = v;
    }

    public void setButtonActive(bool v)
    {
        button.SetActive(v);
        button.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    public void setButtonText(string v)
    {
        button.GetComponentInChildren<Text>().text = v;
    }
}

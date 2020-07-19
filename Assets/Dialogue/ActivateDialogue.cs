using UnityEngine;
using UnityEngine.UI;

public class ActivateDialogue : MonoBehaviour
{
    GameObject SwitchObject;

    public bool onlyOnce = true;
    public Sprite sprite;

    public AudioSource audioSource;
    public AudioClip audioclip;

    public bool button;
    public string buttonText = "";
    public GameObject ifButtonPressed;
    public GameObject ActiveOnExit;

    public string text = "";
    bool Activate = true;

    void Start()
    {  
        SwitchObject = GameObject.FindGameObjectWithTag("Dialogue");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Activate)
            {
                    SwitchObject.GetComponent<DialogueSetTexts>().setComponentsActive(true);
                    SwitchObject.GetComponent<DialogueSetTexts>().setText(text);

                    if (sprite != null)
                        SwitchObject.GetComponent<DialogueSetTexts>().setImg(sprite);

                    if (button)
                    {
                        SwitchObject.GetComponent<DialogueSetTexts>().setButtonActive(button);
                        SwitchObject.GetComponent<DialogueSetTexts>().setButtonText(buttonText);
 
                        GameObject.FindGameObjectWithTag("DialogueButton").GetComponent<Button>().onClick.AddListener(ButtonAction);
                    }

                if(audioclip != null)
                {
                    audioSource.PlayOneShot(audioclip, audioSource.volume);
                }
            }

            if (onlyOnce)
            {
                Activate = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "Player")
        {
            SwitchObject.GetComponent<DialogueSetTexts>().setComponentsActive(false);
            SwitchObject.GetComponent<DialogueSetTexts>().setButtonActive(false);

            if(ActiveOnExit != null)
            {
                ActiveOnExit.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    void ButtonAction()
    {
        if (ifButtonPressed != null)
        {
            ifButtonPressed.SetActive(true);
            gameObject.SetActive(false); 
        }
    }
}

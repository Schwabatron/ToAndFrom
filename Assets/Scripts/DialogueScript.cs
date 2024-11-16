using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*NOTE:
To use this script, you need to
1. drag a TMP text element into the dialoguebox panel.
2. Drag the script into dialoguebox
3. drag text (tmp) into "TextComponent" under Dialogue (Script)
4. Enter the text read speed
5. Click the lines dropdown and manually add desired text and number of desired lines.
*/
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //currently uses left click
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                //Gets stops line and instantly fills it out so you can skip animation
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    //Type each character in index
    IEnumerator TypeLine()
    {
    
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
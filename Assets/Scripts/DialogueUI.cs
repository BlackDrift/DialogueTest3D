using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TMP_Text _TextLabel;
    [SerializeField] private DialogueObject _testDialogue;

    private TypewriterEffect _TypewriterEffect;

    private void Start()
    {
        _TypewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(_testDialogue);

    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        _dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach(string dialogue in dialogueObject.Dialogue)
        {
            yield return _TypewriterEffect.Run(dialogue, _TextLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        _dialogueBox.SetActive(false);
        _TextLabel.text = string.Empty;
    }
}

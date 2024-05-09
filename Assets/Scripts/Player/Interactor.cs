using UnityEngine;
using TMPro;

interface IInteractable
{
    public void Interact();
    public string Prompt { get; }
}
public class Interactor : MonoBehaviour
{
    public float interactRange = 3f;
    private Transform interactorSource;
    private TextMeshProUGUI cursorPrompt;

    private void Awake()
    {
        interactorSource = Camera.main.transform;
        cursorPrompt = GameObject.FindGameObjectWithTag("Cursor_Prompt").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Ray r_0 = new(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r_0, out RaycastHit hitInfo_0, interactRange, 3))
        {
            if (hitInfo_0.collider.gameObject.TryGetComponent(out IInteractable obj))
            {
                Debug.DrawRay(interactorSource.position, interactorSource.forward * interactRange, Color.green);
                cursorPrompt.text = obj.Prompt;
                if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                    Action(obj);
            }
            else
            {
                Debug.DrawRay(interactorSource.position, interactorSource.forward * interactRange, Color.red);
                cursorPrompt.text = "";
            }
        }
        else
        {
            Debug.DrawRay(interactorSource.position, interactorSource.forward * interactRange, Color.red);
            cursorPrompt.text = "";
        }
    }

    private void Action(IInteractable interactObj)
    {
        //Debug.Log("INTERACT");
        interactObj.Interact();
    }
}

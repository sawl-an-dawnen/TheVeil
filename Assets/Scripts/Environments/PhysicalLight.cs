using UnityEngine;

public class PhysicalLight : MonoBehaviour
{

    public Material onMat;
    public Material offMat;
    public bool power = true;
    public bool status = false;

    private Light lightComponent;


    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (power && status)
        {
            lightComponent.enabled = true;
            gameObject.GetComponent<MeshRenderer>().material = onMat;
        }
        else 
        {
            lightComponent.enabled = false;
            gameObject.GetComponent<MeshRenderer>().material = offMat;
        }
    }

    public void PowerOff() { power = false; }
    public void PowerOn() { power = true; }
    public void TurnOn() { status = true; }
    public void TurnOff() { status = false; }

}

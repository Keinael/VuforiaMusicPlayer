using UnityEngine;
using Vuforia;

public class VirtualButtonsEventHandler : MonoBehaviour, IVirtualButtonEventHandler {

    public bool isPressed1;
    public bool isPressed2;
    public bool isPressed3;
    public bool isPressed4;
    public GameObject christmasTree;
    public bool isRotate;

    private VirtualButtonBehaviour[] _vbObjects;

	// Use this for initialization
	void Start()
    {
        isRotate = false;
        _vbObjects = GetComponentsInChildren<VirtualButtonBehaviour>();
        foreach (VirtualButtonBehaviour buttons in _vbObjects)
        {
            buttons.RegisterEventHandler(this);
        }        
	}

    void Update()
    {
        CristmasTreeRotator();
    }

    public void CristmasTreeRotator()
    {
        if (isRotate)
        {
            christmasTree.gameObject.transform.Rotate(new Vector3(0, 1, 0), 1);
        }
    }

    public void PlayAudio(VirtualButtonBehaviour vb, bool isPlay)
    {
        if (!isPlay)
        {
            vb.GetComponent<AudioSource>().Play();
            isRotate = true;
        }
        else
        {
            vb.GetComponent<AudioSource>().Stop();
            isRotate = false;
        }
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "vbtn1":                
                PlayAudio(_vbObjects[0], isPressed1);
                isPressed1 = !isPressed1;
                break;
            case "vbtn2":
                PlayAudio(_vbObjects[1], isPressed2);
                isPressed2 = !isPressed2;
                break;
            case "vbtn3":
                PlayAudio(_vbObjects[2], isPressed3);
                isPressed3 = !isPressed3;
                break;
            case "vbtn4":
                PlayAudio(_vbObjects[3], isPressed4);
                isPressed4 = !isPressed4;
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {       
    }
}

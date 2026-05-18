using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Splines;
using UnityEngine.UI;

public class FilmmakingManager : MonoBehaviour
{
    public Camera cam;
    public Light lightbulb;
    public Slider camSlider;
    public int lightBaseValue = 100;

    public int rangeY;
    public int rangeZ;
    public int minAngle;
    public int maxAngle;

    private Vector3 camAnchor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camAnchor = cam.transform.position;
        camSlider.minValue = minAngle;
        camSlider.maxValue = maxAngle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateCamera(float  angle)
    {
        float range = maxAngle - minAngle;
        cam.transform.rotation = Quaternion.Euler(angle,0,0);
        cam.transform.position = camAnchor + new Vector3(0, (angle / range) * rangeY, (angle / range) * rangeZ);
    }

    public void ChangeLighting(float intensity)
    {
        lightbulb.intensity = intensity + lightBaseValue;
    }
}

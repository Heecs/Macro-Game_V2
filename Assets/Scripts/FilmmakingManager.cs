using UnityEngine;
using UnityEngine.UI;

public class FilmmakingManager : MonoBehaviour
{
    
    [Header("Camera Settings")]
    public Camera cam;
    public Slider camSlider;
    public int camRangeY;
    public int camRangeZ;
    public int minCamAngle;
    public int maxCamAngle;
    public int startingAngleOffset;

    [Header("Light Settings")]
    public Light lightbulb;
    public Slider lightSlider;
    public int minIntensity;
    public int maxIntensity;
    public int startingIntensityOffset;

    [Header("Sound Settings")]
    public AudioSource audioSource;
    public Slider audioSlider;
    public float startingVolume;


    private Vector3 camAnchor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camAnchor = cam.transform.position;
        camSlider.minValue = minCamAngle;
        camSlider.maxValue = maxCamAngle;
        lightSlider.minValue = minIntensity;
        lightSlider.maxValue = maxIntensity;
        RotateCamera(startingAngleOffset);
        camSlider.value = startingAngleOffset;
        ChangeLighting(startingIntensityOffset);
        lightSlider.value = startingIntensityOffset;
        AdjustVolume(startingVolume);
        audioSlider.value = startingVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateCamera(float  angle)
    {
        float range = maxCamAngle - minCamAngle;
        cam.transform.rotation = Quaternion.Euler(angle,0,0);
        cam.transform.position = camAnchor + new Vector3(0, (angle / range) * camRangeY, (angle / range) * camRangeZ);
    }

    public void ChangeLighting(float intensity)
    {
        lightbulb.intensity = intensity + minIntensity;
    }

    public void AdjustVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

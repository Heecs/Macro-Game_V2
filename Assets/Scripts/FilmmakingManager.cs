using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FilmmakingManager : MonoBehaviour
{
    public TextMeshProUGUI camGoalText;
    public TextMeshProUGUI audioGoalText;
    public TextMeshProUGUI lightGoalText;
    public GameObject ResultsPanel;
    public TextMeshProUGUI camResultText;
    public TextMeshProUGUI camResultGrade;
    public TextMeshProUGUI audioResultText;
    public TextMeshProUGUI audioResultGrade;
    public TextMeshProUGUI lightResultText;
    public TextMeshProUGUI lightResultGrade;

    [Header("Camera Settings")]
    public Camera cam;
    public Slider camSlider;
    public int camRangeY;
    public int camRangeZ;
    public int minCamAngle;
    public int maxCamAngle;
    public int startingAngleOffset;
    public float camSpeed;

    [Header("Light Settings")]
    public Light lightbulb;
    public Slider lightSlider;
    public int minIntensity;
    public int maxIntensity;
    public float intensityMult;
    public int startingIntensityOffset;

    [Header("Sound Settings")]
    public AudioSource audioSource;
    public Slider audioSlider;
    public float startingVolume;

    [Header("Target Settings")]
    public int targetAngle;
    public int angleGreatRange;
    public int angleGoodRange;
    public int angleOkRange;
    public int targetBrightness;
    public int lightGreatRange;
    public int lightGoodRange;
    public int lightOkRange;
    public float targetVolume;
    public float soundGreatRange;
    public float soundGoodRange;
    public float soundOkRange;


    private Vector3 camAnchor;
    private string camResult;
    private string lightResult;
    private string audioResult;
    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomizeTargets();
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
        UpdateGoals();
        ResultsPanel.SetActive(false);
        UnpauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGoals()
    {
        camGoalText.SetText("Camera Target Angle: " + targetAngle + "°");
        audioGoalText.SetText("Target Volume: " + (int)(targetVolume*100) + "%");
        lightGoalText.SetText("Target Brightness: " + targetBrightness + "%");
    }

    public void RotateCamera(float  angle)
    {
        float range = maxCamAngle - minCamAngle;
        cam.transform.rotation = Quaternion.Euler(angle, 0, 0);
        cam.transform.position = camAnchor + new Vector3(0, (angle / range) * camRangeY, (angle / range) * camRangeZ);
    }

    public void ChangeLighting(float intensity)
    {
        lightbulb.intensity = intensity * intensityMult + minIntensity;
    }

    public void AdjustVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void PressRecord()
    {
        print(isPaused);
        if (!isPaused)
        {
            float camAccuracy = Mathf.Abs(targetAngle - cam.transform.rotation.eulerAngles.x);
            float soundAccuracy = Mathf.Abs(audioSource.volume - targetVolume);
            float lightAccuracy = Mathf.Abs(lightbulb.intensity / intensityMult - targetBrightness);
            camResult = CheckResults(camAccuracy, angleGreatRange, angleGoodRange, angleOkRange);
            audioResult = CheckResults(soundAccuracy, soundGreatRange, soundGoodRange, soundOkRange);
            lightResult = CheckResults(lightAccuracy, lightGreatRange, lightGoodRange, lightOkRange);
            PauseGame();
            ResultsPanel.SetActive(true);
            camResultText.text = "Camera Angle: " + (int)cam.transform.rotation.eulerAngles.x + "°";
            camResultGrade.text = camResult;
            audioResultText.text = "Volume: " + (int)(audioSource.volume * 100) + "%";
            audioResultGrade.text = audioResult;
            lightResultText.text = "Brightness: " + (int)(lightbulb.intensity / intensityMult) + "%";
            lightResultGrade.text = lightResult;
        }
    }

    private string CheckResults(float accuracy, float forGreat, float forGood, float forOk)
    {
        if (accuracy <= forGreat)
        {
            return "Great";
        }
        else if (accuracy <= forGood)
        {
            return "Good";
        }
        else if (accuracy <= forOk)
        {
            return "Okay";
        }
        else
        {
            return "Bad";
        }
    }

    private void PauseGame()
    {
        camSlider.interactable = false;
        audioSlider.interactable = false;
        lightSlider.interactable = false;
        isPaused = true;
    }

    private void UnpauseGame()
    {
        camSlider.interactable = true;
        audioSlider.interactable = true;
        lightSlider.interactable = true;
        isPaused = false;
    }

    private void RandomizeTargets()
    {
        targetAngle = Random.Range(minCamAngle, maxCamAngle + 1);
        targetBrightness = Random.Range(0, 101);
        targetVolume = Random.Range(0f, 1f);
        print(targetAngle + "\n" + targetBrightness + "\n" + targetVolume + "\n");
    }
}

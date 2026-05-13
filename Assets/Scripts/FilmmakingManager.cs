using UnityEngine;
using UnityEngine.Splines;

public class FilmmakingManager : MonoBehaviour
{
    public Camera cam;

    private Vector3 camAnchor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camAnchor = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateCamera(float  angle)
    {
        print(angle);
        cam.transform.rotation = Quaternion.Euler(angle,0,0);
        cam.transform.position = camAnchor + new Vector3(0, (angle/55)*5, (angle / 55) * 5);
    }
}

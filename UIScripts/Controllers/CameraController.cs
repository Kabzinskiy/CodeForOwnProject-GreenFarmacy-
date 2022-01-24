using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float StartDistance { get; set; } = 0;
    private const float MinCameraSize = 3f;    
    private const float MaxCameraSize = 10f;

    private Vector3 StartPos { get; set; } = new Vector3(0,0,0);
    private float Speed => (camera.orthographicSize-2)*3;

    [SerializeField] private float TopBorder = 40;
    [SerializeField] private float LowBorder = -40;
    [SerializeField] private float RightBorder = 30;
    [SerializeField] private float LeftBorder = -30;
    


    private Camera camera { get; set; }

    void Awake()
    {
        camera = GetComponent<Camera>();
        camera.orthographicSize = 7.5f;
    }

    void Update()
    {

        if (Input.touchCount >= 2) Zoom();
        else if (Input.touchCount == 1) Move();
        

    }

    private void Zoom()
    {
        var finger1 = Input.GetTouch(0).position;
        var finger2 = Input.GetTouch(1).position;

        StartDistance = Input.GetTouch(1).phase == TouchPhase.Began ? Vector2.Distance(finger1, finger2) : StartDistance;
        //StartDistance = (StartDistance == 0 ? Vector2.Distance(finger1, finger2) : StartDistance);
        
        if (camera.orthographicSize >= MinCameraSize && camera.orthographicSize <= MaxCameraSize)
        {
            float delta = Vector2.Distance(finger1, finger2) - StartDistance;
            camera.orthographicSize -= delta/1000;
        }

        camera.orthographicSize = (camera.orthographicSize < MinCameraSize ? MinCameraSize : camera.orthographicSize);
        camera.orthographicSize = (camera.orthographicSize > MaxCameraSize ? MaxCameraSize : camera.orthographicSize);
    }

    private void Move()
    {
        
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartPos = camera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        float deltaX = camera.ScreenToWorldPoint(Input.GetTouch(0).position).x - StartPos.x;
        float deltaY = camera.ScreenToWorldPoint(Input.GetTouch(0).position).y - StartPos.y;

        Vector3 resultVector = new Vector3(transform.position.x - deltaX, transform.position.y - deltaY, transform.position.z);

        transform.position =
            Vector3.MoveTowards(transform.position, resultVector, Speed * Time.deltaTime);
        CheckCamera();
    }

    private void CheckCamera()
    {
        var cameraPosition = transform.position;

        cameraPosition.x = cameraPosition.x >= RightBorder ? RightBorder : cameraPosition.x;
        cameraPosition.x = cameraPosition.x <= LeftBorder ? LeftBorder : cameraPosition.x;
        cameraPosition.y = cameraPosition.y >= TopBorder ? TopBorder : cameraPosition.y;
        cameraPosition.y = cameraPosition.y <= LowBorder ? LowBorder : cameraPosition.y;

        transform.position = cameraPosition;
    }


}

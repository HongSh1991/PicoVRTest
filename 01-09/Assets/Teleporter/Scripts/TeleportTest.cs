using UnityEngine;
/// \brief A test script for "The Lab" style teleportation if you don't have a Vive.  Keep in mind that this 
///        doesn't have fade in/out, whereas TeleportVive (a version of this specifically made for the Vive) does.
/// \sa TeleportVive
[AddComponentMenu("Vive Teleporter/Test/Teleporter Test (No SteamVR)")]
public class TeleportTest : MonoBehaviour {

    public GameObject picoCamera;
    public Camera LookCamera;
    public ParabolicPointer Pointer;
    public Transform Controller;

    public float MovementSpeed = 1;
    public float LookSensitivity = 10;
    public float PointSensitivity = 10;

    public GUIStyle InstructionsStyle;

    private float pointer_pitch = 0;
    private float pointer_yaw = 0;
	private Vector3 moveOffset = new Vector3(0, 1.5f, 0);
    private Vector3 boxGyr;
    private bool isPointerActive = false;
    public GameObject pitchLabel;
    public GameObject yawLabel;
    public float maxHorizontal = 60;
    public float maxVertical = 60;
    private Vector3 originalPosition;
    void Start ()
    {
        picoCamera = GameObject.Find("1111");
        originalPosition = picoCamera.transform.position;
        Controller.gameObject.SetActive(false);
    }

    void Update ()
    {
        Vector3 move = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")).normalized * MovementSpeed;
        move = transform.TransformDirection(move);
        transform.Translate(move * Time.deltaTime);

        #if UNITY_EDITOR
		if(Input.GetButton(InputUtil.shiftLeft))
        {
            transform.Rotate(-Input.GetAxis("Mouse Y") * LookSensitivity, Input.GetAxis("Mouse X") * LookSensitivity, 0);
        }
        #endif


        if (Input.GetButtonDown(InputUtil.buttonX))
		{
			if(!isPointerActive){
                isPointerActive = true;
                Controller.gameObject.SetActive(true);
            }
		}

        if(isPointerActive){
            // 手柄转动TeleportController
           // boxGyr = PicoVRBaseDevice.GetDevice().GetBoxSensorGyr();
            pointer_pitch += -boxGyr[0] * PointSensitivity;
            pointer_yaw += -boxGyr[2] * PointSensitivity;
            if(pointer_pitch>maxHorizontal) pointer_pitch = maxHorizontal;
            if(pointer_pitch<-maxHorizontal) pointer_pitch = -maxHorizontal;
            if(pointer_yaw>maxVertical) pointer_yaw = maxVertical;
            if(pointer_yaw<-maxVertical) pointer_yaw = -maxVertical;
            transform.localRotation = Quaternion.Euler(pointer_pitch, pointer_yaw, 0);

            pitchLabel.GetComponent<TextMesh>().text = "Horizontal:"+pointer_pitch;
            yawLabel.GetComponent<TextMesh>().text = "Vertical  :"+pointer_yaw;
        }

        if (Input.GetButtonUp(InputUtil.buttonX))
		{
            if(isPointerActive){
                isPointerActive = false;
                Controller.gameObject.SetActive(false);
            }

			if(Pointer.PointOnNavMesh){
                picoCamera.transform.position = Pointer.SelectedPoint + moveOffset;
            }

            // 复位TeleportController
            pointer_pitch = 0;
            pointer_yaw = 0;
            transform.localRotation = Quaternion.Euler(pointer_pitch, pointer_yaw, 0);
		}

        if(Input.GetButtonUp(InputUtil.triggerLeft) && Pointer.PointOnNavMesh){
            picoCamera.transform.position = Pointer.SelectedPoint + moveOffset;
        }

        // if(Input.GetButtonUp(InputUtil.buttonA) && Pointer.PointOnNavMesh)
        //     picoCamera.transform.position = Pointer.SelectedPoint + moveOffset;

        if(Input.GetButtonUp(InputUtil.buttonY))
            picoCamera.transform.position = originalPosition;

	}

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height - 60, 300, 50), "Hold ALT to turn camera, Click to teleport, Mouse to rotate controller/camera", InstructionsStyle);
    }
}

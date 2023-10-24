using UnityEngine.InputSystem;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float minY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (SystemInfo.supportsGyroscope && Stats.isMobile)
        {
            Input.gyro.enabled = true;
        }
    }

    private void Update()
    {
        #region
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");
        //if (Input.GetKey(KeyCode.E))
        //{
        //    Rotate(-Stats.playerSpeedRotation);
        //    //Debug.Log("aliseffiosefoi");
        //}
        //else if (Input.GetKey(KeyCode.Q))
        //{
        //    Rotate(Stats.playerSpeedRotation);
        //    //Debug.Log("mohgauyfdiu");
        //}
        //else
        //{
        //    NormalRotatePosition(transform.rotation.z* Stats.playerSpeedRotation);
        //}
        //Movement(mouseX, mouseY);
        #endregion
        MoveInput();
    }

    private void MoveInput()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.E))
        {
            Rotate(-Stats.playerSpeedRotation);
            //Debug.Log("aliseffiosefoi");
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Rotate(Stats.playerSpeedRotation);
            //Debug.Log("mohgauyfdiu");
        }
        else
        {
            NormalRotatePosition(transform.rotation.z * Stats.playerSpeedRotation);
            Debug.Log(transform.rotation.z * Stats.playerSpeedRotation);
        }
        Movement(mouseX, mouseY);

    }

    private void Movement(float x, float y)
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        x = Mathf.Clamp(x, -Stats.playerSpeedOffset, Stats.playerSpeedOffset);
        y = Mathf.Clamp(y, -Stats.playerSpeedOffset, Stats.playerSpeedOffset);
        transform.position += new Vector3(x, y,0) * Stats.playerSpeedOffset;
    }

    private void Rotate(float value)
    {
        transform.Rotate(Vector3.forward * value * Time.deltaTime, Space.Self);
    }

    private Quaternion Rotate(Quaternion q)
    {
        return new Quaternion(transform.position.x, q.y, transform.position.z, -q.w);
    }

    private void NormalRotatePosition(float value)
    {
        if (transform.rotation.z != 0 && transform.rotation.z < 0)
        {
            transform.Rotate(Vector3.forward * -value * Time.deltaTime, Space.Self);
        }
        else if (transform.rotation.z != 0 && transform.rotation.z > 0)
        {
            transform.Rotate(Vector3.forward * value * Time.deltaTime, Space.Self);
        }
    }
}

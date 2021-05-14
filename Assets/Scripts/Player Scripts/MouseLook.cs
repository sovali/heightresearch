using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public Transform playerRoot, lookRoot;

    private Vector2 current_Mouse_Look;
    private Vector2 look_Angles;
    [SerializeField]
    private float sensitivity = 5f;
    [SerializeField]
    private bool invert;
    [SerializeField]
    private bool can_Unlock = true;
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);
    private Vector2 smooth_Move;
    [SerializeField]
    private int smooth_Steps = 10;
    [SerializeField]
    private float smooth_Weight = 0.4f;
    [SerializeField]
    private float roll_Angle = 10f;
    [SerializeField]
    private float roll_Speed = 3f;
    private float current_Roll_Angle;
    [SerializeField]
    private int last_Look_Frame;


    // Start is called before the first frame update
    void Start()
    {
        //print("In FP Camera start");
        if (GameManager.gameStart)
        {
            // print(GameManager.gameStart + "Mouse look");
            // Cursor.lockState = CursorLockMode.Locked;
            // print("Locked");
            // LockAndUnlockCursor();
            // Cursor.visible = false;
        //lookRoot = GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameStart)
        {
            LockAndUnlockCursor();
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                LookAround();
            }
        }
        
    }

    public void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                print("Unlocked");
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                print("locked");
                Cursor.visible = false;
            }
        }
            
    }

    void LookAround()
    {
        //Rotating in the vertical direction from lookRoot and the horizontal direction from Player because it feels more natural. 
        current_Mouse_Look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y),
            Input.GetAxis(MouseAxis.MOUSE_X)); //mouse Y data is fed to x because the Look Root behaves like that. 
        //Need to restrict the mouse movement. 

        look_Angles.x += current_Mouse_Look.x * sensitivity * (invert ? 1f : -1f); //x vector will move in the vertical direction for this particular Look Root. 
        look_Angles.y += current_Mouse_Look.y * sensitivity; //Here y represnts the horizontal movement. 
        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y); //clamping because we don't want it to look behind. 

        //current_Roll_Angle = Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * roll_Angle, Time.deltaTime * roll_Speed);
        //The above code is to implement the functionality for rotation along the z axis - drunk effect. 

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0, current_Roll_Angle);
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);

    }

}

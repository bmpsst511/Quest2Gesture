using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Camera mainCamera;
    private string nameObject;
    private bool hitObject;
    bool grabObj = false;
    public GameObject Cup1;
    public GameObject Cup2;
    public GameObject Cup3;
    Rigidbody rb_1, rb_2, rb_3;
    int grabtimes = 0;

    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color m_MouseOverColor = Color.red;
    //This stores the GameObject's original color
    Color m_OriginalColor;
    //Get the GameObject's mesh renderer to access the GameObject's material and color
    MeshRenderer m_Renderer;

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
        //Get the object's rigid body 
        rb_1 = Cup1.GetComponent<Rigidbody>();
        rb_2 = Cup2.GetComponent<Rigidbody>();
        rb_3 = Cup3.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grabtimes);
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        hitObject = false;
        if (Physics.Raycast(ray, out hit))
        {
            hitObject = true;
            Transform objectHit = hit.transform;
            nameObject = hit.transform.gameObject.name;

            /*********檢測是否是第1個杯子*********/
            if (nameObject == "Cup1")
            {
                /*********當抓起第1個杯子*********/
                if (Input.GetMouseButtonDown(0))
                {
                    grabObj = true;
                    if(grabObj)
                    {
                        grabtimes +=1;
                        grabObj = false;
                    }
                    rb_1.constraints = RigidbodyConstraints.FreezeRotation;
                    //Debug.Log("Cup1 clicked");
                }
                
                /*********當放下第1個杯子*********/
                if (Input.GetMouseButtonUp(0))
                {
                    this.rb_1.useGravity = true;
                    rb_1.constraints = RigidbodyConstraints.None;
                    //Debug.Log("Cup1 released"); 
                }
            }

            /*********檢測是否是第2個杯子*********/
            if (nameObject == "Cup2")
            {
                /*********當抓起第2個杯子*********/
                if (Input.GetMouseButtonDown(0))
                {
                    grabObj = true;
                    if(grabObj)
                    {
                        grabtimes +=1;
                        grabObj = false;
                    }
                    rb_2.constraints = RigidbodyConstraints.FreezeRotation;
                    //Debug.Log("Cup2 clicked");
                }
                
                /*********當放下第2個杯子*********/
                if (Input.GetMouseButtonUp(0))
                {
                    this.rb_2.useGravity = true;
                    rb_2.constraints = RigidbodyConstraints.None;
                    //Debug.Log("Cup2 released");  
                }
            }

            /*********檢測是否是第3個杯子*********/
            if (nameObject == "Cup3")
            {
                /*********當抓起第3個杯子*********/
                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("clicked");
                }
                
                /*********當放下第3個杯子*********/
                if (Input.GetMouseButtonUp(0))
                {
                    //Debug.Log("released"); 
                }
            }

            if(grabtimes > 2)
            {
                rb_1.isKinematic = true;
                rb_2.isKinematic = true;
                rb_3.isKinematic = true;
            }

        }
    }

    void OnGUI()
    {
        if (hitObject = true)
        {
            Vector2 screenPos = Event.current.mousePosition;
            Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);

            GUI.Label(new Rect(convertedGUIPos.x, convertedGUIPos.y, 200, 20), nameObject);
        }
    }

    /********************滑鼠靠近物體改變顏色，抓取並移動物體********************/
    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = m_MouseOverColor;
    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
    } 

    void OnMouseDown()
    {
        mZCoord = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
    /********************滑鼠靠近物體改變顏色，抓取並移動物體********************/
}
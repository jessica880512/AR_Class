using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlay : MonoBehaviour
{
    [Header("放置物件")]
    public GameObject tapobjct;

    //AR 射線碰撞管理器
    private ARRaycastManager arRaycast;

    //AR 射線碰撞到的物件(集合清單)
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    //點擊座標
    private Vector2 mousePos;

    private void Start()
    {
        //取得ar
        arRaycast = GetComponent<ARRaycastManager>();
    }
    private void TapObject()
    {
        //是否點擊
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //儲存點擊座標
            mousePos = Input.mousePosition;
            //ar射線碰撞
            if (arRaycast.Raycast(mousePos, hits, TrackableType.PlaneWithinPolygon))
            {
                //生成物件在點擊座標
                Pose pose = hits[0].pose;
                GameObject temp = Instantiate(tapobjct, pose.position, pose.rotation);
                Vector3 look = transform.position;
                look.y = temp.transform.position.y;
                temp.transform.LookAt(look);

            }
        }
    }
}

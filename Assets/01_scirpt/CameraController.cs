using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // 카메라가 추적하는 대상
    private float distance; // 카메라와 target의 거리

    private void Awake()
    {
        // 최초 설정된 target과 카메라의 위치를 바탕으로 distance 값 초기화
        distance = Vector3.Distance(transform.position, target.position);
    }

    // LateUpdate() - 모든 Update 함수가 호출된 후, 마지막으로 호출됩니다.
    // 주로 오브젝트를 따라가게 설정한 카메라는 LateUpdate 를 사용합니다
    // (카메라가 따라가는 오브젝트가 Update함수 안에서 움직일 경우가 있기 때문).
    private void LateUpdate()
    {
        // target이 존재하지 않으면 실행하지 않는다.
        if (target == null) return;

        // 카메라의 위치(position) 정보 갱신
        // target의 위치를 기준으로 distance만큼 떨어져서 쫓아간다.
        transform.position = target.position + transform.rotation * new Vector3(0, 0, -distance);
    }
}

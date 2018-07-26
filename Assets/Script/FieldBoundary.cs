using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBoundary: MonoBehaviour {

    // 트리거를 보내 모든것을 파괴합니다.

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}

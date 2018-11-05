using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour {
    public void Warp()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = player.transform.position;
        pos.x = transform.position.x;
        pos.z = transform.position.z;
        player.transform.position = pos;
    }
}

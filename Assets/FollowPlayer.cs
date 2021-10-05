using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : Follow {
    private void Start() {
        if (target == null) {
            target = GameObject.Find("Player").transform;
        }
    }
}

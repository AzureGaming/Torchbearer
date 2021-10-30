using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLevelEvent : PyreEvent {
    public override void TriggerEvent() {
        GameManager.OnPyreIgnite?.Invoke();
    }
}

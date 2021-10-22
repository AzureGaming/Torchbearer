using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStage2Event : PyreEvent {
    public override void TriggerEvent() {
        Boss.OnCompleteStage2?.Invoke();
    }
}

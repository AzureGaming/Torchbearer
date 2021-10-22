using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStage7Event : PyreEvent {
    public override void TriggerEvent() {
        Boss.OnCompleteStage7?.Invoke();
    }
}
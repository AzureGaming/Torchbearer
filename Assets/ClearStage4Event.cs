using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStage4Event : PyreEvent {
    public override void TriggerEvent() {
        Boss.OnCompleteStage4?.Invoke();
    }
}

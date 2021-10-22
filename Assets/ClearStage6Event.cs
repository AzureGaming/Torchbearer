using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStage6Event : PyreEvent {
    public override void TriggerEvent() {
        Boss.OnCompleteStage6?.Invoke();
    }
}

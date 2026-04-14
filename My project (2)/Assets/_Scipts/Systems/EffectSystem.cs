using System.Collections;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    void OnEnable()
    {
        ActionSystem.AttachPerformer<PerformEffectGA>(PerformEffectPerformer);
    }
    void OnDisable()
    {
        ActionSystem.DetachPerformer<PerformEffectGA>();
    }
    private IEnumerator PerformEffectPerformer(PerformEffectGA performEffectGA)
    {
        if (performEffectGA.Effect != null)
        {
            GameAction effectAction = performEffectGA.Effect.GetGameAction(performEffectGA.Targets);
            ActionSystem.Instance.AddReaction(effectAction);
        }
        else
        {
            Debug.LogWarning("PerformEffectGA.Effect is null. This may be due to an unassigned effect on a CardData asset.");
        }
        yield return null;
    }
}

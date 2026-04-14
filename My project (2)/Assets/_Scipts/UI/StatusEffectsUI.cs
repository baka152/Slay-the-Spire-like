using System.Collections.Generic;
using UnityEngine;

public class StatusEffectsUI : MonoBehaviour
{
    [SerializeField]private StatusEffectUI statusEffectUIPrefab;
    [SerializeField] private Sprite armoSprite, burnSprite;
    private Dictionary<StatusEffectType, StatusEffectUI> statusEffectUIs = new ();
    public void UpdateStatusEffect(StatusEffectType statusEffectType, int stackCount)
    {
        if(stackCount==0)
        {
            if(statusEffectUIs.ContainsKey(statusEffectType))
            {
                StatusEffectUI statusEffectsUI= statusEffectUIs[statusEffectType];
                statusEffectUIs.Remove(statusEffectType);  
                Destroy(statusEffectsUI.gameObject);
            }
        }
        else
        {
            if (!statusEffectUIs.ContainsKey(statusEffectType))
            {
                StatusEffectUI statusEffectsUI = Instantiate(statusEffectUIPrefab, transform);
                statusEffectUIs.Add(statusEffectType, statusEffectsUI);
            }
            Sprite sprite = GetSpriteByType(statusEffectType);
            statusEffectUIs[statusEffectType].Set(sprite, stackCount);
        }
    }
    private Sprite GetSpriteByType(StatusEffectType statusEffectType)
    {
        return statusEffectType switch
        {
            StatusEffectType.ARMOR => armoSprite,
            StatusEffectType.BURN => burnSprite,
            _ => null
        };
    }
}

using UnityEngine;
using TMPro;
public class ManaUI : MonoBehaviour
{
    [SerializeField] private TMP_Text mana;
    public void UpdatamanaText(int currentMana)
    {
        mana.text = currentMana.ToString();
    }
}

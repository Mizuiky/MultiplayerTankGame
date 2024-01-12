using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public void Init();
    public void Reset();
    public void Damage(float value);

    public void UpdateUI();

}

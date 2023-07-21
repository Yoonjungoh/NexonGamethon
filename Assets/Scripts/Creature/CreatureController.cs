using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    protected int _hp;
    protected int _attack;
    public int Hp { get { return _hp; } set { _hp = value; } }
    public void OnDamaged()
    {

    }
}

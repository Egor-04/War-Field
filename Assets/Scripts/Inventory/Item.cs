using UnityEngine;

public enum WeaponType {Pistol, Rifle, Grenade, RocketLauncher}
public class Item : MonoBehaviour
{
    [Header("Item")]
    public WeaponType TypeWeapon;
    public int ID;
    public string ItemName;
    public Sprite Icon;
    public bool ActivateItemInHand = true;
}
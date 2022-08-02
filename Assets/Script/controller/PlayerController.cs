﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : TankController
{
    public Text levelTxt;
    private void Start()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, LevelUp);
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        move(direction);

        var position = Input.mousePosition;
        Vector3 gunDirectionmoba = new Vector3(
            position.x - Screen.width / 2,
            position.y - Screen.height / 2);
        rotateGun(gunDirectionmoba);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(); }
    }

    private void LevelUp(object data)
    {
        float levelEnemy = (float)data;
        level += levelEnemy;
        levelTxt.text = "Level player: " + level.ToString();
    }
    



}




public class Player : SingletonMonoBehaviour<PlayerController>
{
    
}

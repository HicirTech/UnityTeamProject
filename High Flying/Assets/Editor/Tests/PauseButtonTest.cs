﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewTestScript {

    [Test]    
    public void PauseUnitTest() {
    // Use the Assert class to test conditions.
    UIBattleController UIButtons = new UIBattleController();
   // set object for UIbatttleController 
    PauseAndMenu pauseMenu = UIButtons.getPauseAndMenu(); 
    //get object from pauseMenu       
    Assert.AreEqual(0, pauseMenu.PauseGame()); //make sure time Scale return to 0 so the game pause
    Assert.AreEqual(1, pauseMenu.ResumeGame()); //make sure time Scale return to 1 so the game resume
    }
}

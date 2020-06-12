﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScript
    {
        
        
        [Test]
        public void checkScore()
        {
            var ball = new Ball();
            ball.UpdateScore(1);
            Assert.AreEqual(ball.score, 1);
        }

        [Test]
        public void checkCollisionBallBlock()
        {
            // Use the Assert class to test conditions
            Assert.AreEqual(0, 0);
        }

        [Test]
        public void checkCollisionBallLine()
        {
            // Use the Assert class to test conditions
            Assert.AreEqual(0, 0);
        }

        [Test]
        public void checkGameOver()
        {
            // Use the Assert class to test conditions
            Assert.AreEqual(0, 0);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        /*[UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }*/
    }
}

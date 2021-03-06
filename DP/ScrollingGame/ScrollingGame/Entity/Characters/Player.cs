﻿using ScrollingGame.Gravity;
using ScrollingGame.Items;
using ScrollingGame.Jump;
using ScrollingGame.Move;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity.Characters {
    public class Player : Character {
        public PlayerSubject playerItemSubject;
        public PlayerSubject playerMoveSubject;

        private List<AItem> _itemList;

        public List<AItem> itemList {
            get {
                if (_itemList == null)
                    _itemList = new List<AItem>();
                return _itemList;
            }
        }

        public AItem addItem {
            set {
                if (!itemList.Contains(value)) {
                    itemList.Add(value);
                    playerItemSubject.Notify();
                }
            }
        }

        public static bool[] buttons = new bool[4];
        public override Vector2 characterDirection { get => movement; protected set { return; } }
        private Vector2 movement {
            get {
                Vector2 temp = Vector2.Zero;
                if (buttons[2])
                    temp += Vector2.Left;
                if (buttons[3])
                    temp += Vector2.Right;
                return temp;
            }
        }

        public readonly float maxHealth;
        public float currentHealth;

        public float damagePlayer {
            set {
                currentHealth -= value;
            }
        }

        //public static float PlayerMovementSpeed = 100;
        public Player(Vector2 location, Vector2 size, Color color, bool doTick, bool doDraw, float maxHealth) : base(location, size, color, doTick, doDraw) {
            playerItemSubject = new PlayerSubject();
            playerMoveSubject = new PlayerSubject();
            moveStrategy = new SimpleMove();
            jumpStrategy = new SimpleJump();
            currentHealth = this.maxHealth = maxHealth;
        }

        public override void onUpdate() {
            base.onUpdate();

            Vector2 oldLocation = location;

            moveStrategy.Move(this);

            if(location != oldLocation) {
                playerMoveSubject.Notify();
            }

            List<AItem> remove = new List<AItem>();
            foreach (AItem i in itemList) {
                i.remainingDuration -= Time.deltaTimeSeconds;
                if (i.remainingDuration <= 0) {
                    i.onExpire(this);
                    remove.Add(i);
                }
            }
            foreach (AItem i in remove)
                itemList.Remove(i);
        }

        public override void onLoad() {
            base.onLoad();
            moveStrategy = new SimpleMove();
            jumpStrategy = new SimpleJump();
            entityMass = 2;
            characterMovement = 100;
            currentHealth = maxHealth;
        }

        public void ShootBullet() {

        }
    }
}

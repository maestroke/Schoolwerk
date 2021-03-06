﻿using ScrollingGame.Entity.Characters;
using ScrollingGame.Entity.Characters.NPC;
using ScrollingGame.Entity.Obstacles;
using ScrollingGame.Items;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrollingGame {
    public partial class Game : Form {
        private enum dirs {
            W = 1,
            S = 2,
            A = 4,
            D = 8
        }

        public Game() {
            InitializeComponent();

            Singleton.game = this;

            CreateTestLevel1();
        }

        public void gamePictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                Singleton.Draw(e.Graphics);
            }
        }

        private void gameStart() {
            Singleton.Load();
        }

        private void gameTimer_Tick(object sender, EventArgs e) {
            Singleton.Tick();
        }

        private void CreateTestLevel1() {
            Level temp = new Level(2);
            //temp.addObstale = new Obstacle(new Vector2(100, 100), new Vector2(20, 20), Color.Green, true);
            //temp.addObstale = new Obstacle(new Vector2(300, 100), new Vector2(20, 20), Color.Black, true);
            //temp.addObstale = new Obstacle(new Vector2(200, 100), new Vector2(20, 20), Color.Black, true);
            temp.addObstacle = new Obstacle(new Utils.Vector2(0, 500), new Utils.Vector2(2000, 20), Color.Red, false, true);
            //temp.addObstale = new Obstacle(new Vector2(100, 475), new Vector2(100, 25), Color.Orange, false, true);
            temp.addObstacle = new Obstacle(new Utils.Vector2(900, 480), new Utils.Vector2(20, 20), Color.Blue, false, true);

            temp.addItem = new DoubleJumpItem(new Utils.Vector2(100, 480), 10, Color.Blue, true, true);
            //temp.addItem = new SlowMove(new Vector2(150, 480), 10, Color.Black, true, true);
            //temp.addItem = new TripleJumpItem(new Vector2(300, 480), 10, Color.Orange, true, true);

            //temp.addCharacter = new Jumper(new Vector2(500, 480), new Vector2(20, 20), Color.Black, true, true);
            temp.addCharacter = new Shooter(new Utils.Vector2(500, 480), new Utils.Vector2(20, 20), Color.Orange, true, true, 3);

            Singleton.currentLevel = temp;
            gameStart();
        }

        private void CreateTestLevel2() {
            Level temp = new Level(1);

            temp.addObstacle = new Obstacle(new Utils.Vector2(0, 500), new Utils.Vector2(Global.width - 1, 20), Color.Black, false, true);

            Singleton.currentLevel = temp;
            gameStart();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                //case Keys.W:
                //case Keys.Up:
                //    Player.buttons[0] = true;
                //    break;
                case Keys.S:
                case Keys.Down:
                    Player.buttons[1] = true;
                    break;
                case Keys.A:
                case Keys.Left:
                    Player.buttons[2] = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    Player.buttons[3] = true;
                    break;
                //case Keys.Space:
                case Keys.W:
                case Keys.Up:
                    Singleton.player.jumpStrategy.Jump(Singleton.player);
                    break;
                case Keys.D1:
                    CreateTestLevel1();
                    break;
                case Keys.D2:
                    CreateTestLevel2();
                    break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                //case Keys.W:
                //case Keys.Up:
                //    Player.buttons[0] = false;
                //    break;
                case Keys.S:
                case Keys.Down:
                    Player.buttons[1] = false;
                    break;
                case Keys.A:
                case Keys.Left:
                    Player.buttons[2] = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    Player.buttons[3] = false;
                    break;
            }
        }
    }
}

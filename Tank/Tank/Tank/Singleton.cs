using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Tank.Properties;
using System.Media;

namespace Tank
{
    class Singleton
    {
        private P1Tank p1Tank;
        private P2Tank p2Tank;
        private Symbol symbol;
        public P1Tank P1Tank
        {
            get { return p1Tank; }
            set { p1Tank = value; }
        }
        public P2Tank P2Tank
        {
            get { return p2Tank; }
            set { p2Tank = value; }
        }
        public Symbol Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        #region 私有对象
        private List<Blast> blast = new List<Blast>();
        private List<Enemy> enemy = new List<Enemy>();
        private List<Missile> missile = new List<Missile>();
        private List<myMissile> myMissile = new List<myMissile>();
        private List<EnemyMissile> enemyMissile = new List<EnemyMissile>();
        private List<Wall> wall = new List<Wall>();
        private List<Grass> grass = new List<Grass>();
        private List<Water> water = new List<Water>();
        private List<Steel> steel = new List<Steel>();
        private List<Equipment> equip = new List<Equipment>();
        private List<Born> born = new List<Born>();
        #endregion
        public int count;

        private Singleton()
        {
        }
        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public void CreateThread()           //使用多线程
        {
            Thread hitThread = new Thread(new ThreadStart(HitCheck));
            hitThread.Start();
            count = enemy.Count;
        }
        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="e"></param>
        public void AddElement(Element e)
        {
            #region 添加相应的元素
            if (e is P1Tank)
            {
                p1Tank = e as P1Tank;
                return;
            }
            if (e is P2Tank)
            {
                p2Tank = e as P2Tank;
                return;
            }
            if (e is Symbol)
            {
                symbol = e as Symbol;
                return;
            }
            if (e is myMissile)
            {
                myMissile.Add(e as myMissile);
                return;
            }
            if (e is Enemy)
            {
                enemy.Add(e as Enemy);
                return;
            }
            if (e is EnemyMissile)
            {
                enemyMissile.Add(e as EnemyMissile);
                return;
            }
            if (e is Blast)
            {
                blast.Add(e as Blast);
                return;
            }
            if (e is Born)
            {
                born.Add(e as Born);
                return;
            }
            if (e is Wall)
            {
                wall.Add(e as Wall);
                return;
            }
            if (e is Grass)
            {
                grass.Add(e as Grass);
                return;
            }
            if (e is Water)
            {
                water.Add(e as Water);
                return;
            }
            if (e is Steel)
            {
                steel.Add(e as Steel);
                return;
            }
            if (e is Equipment)
            {
                equip.Add(e as Equipment);
                return;
            }
            #endregion
        }
        /// <summary>
        /// 画出所有的元素
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            #region 画出相应的元素
            if (!StartForm.editing)
            {
                p1Tank.Draw(g);
                symbol.Draw(g);
            }
            if (StartForm.isMultiplayer)
            {
                p2Tank.Draw(g);
            }
            
            for (int i = 0; i < myMissile.Count; i++)
            {
                myMissile[i].Draw(g);
            }
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].Draw(g);
            }
            for (int i = 0; i < enemyMissile.Count; i++)
            {
                enemyMissile[i].Draw(g);
            }
            for (int i = 0; i < blast.Count; i++)
            {
                blast[i].Draw(g);
            }
            for (int i = 0; i < born.Count; i++)
            {
                born[i].Draw(g);
            }
            for (int i = 0; i < wall.Count; i++)
            {
                wall[i].Draw(g);
            }
            for (int i = 0; i < grass.Count; i++)
            {
                grass[i].Draw(g);
            }
            for (int i = 0; i < water.Count; i++)
            {
                water[i].Draw(g);
            }
            for (int i = 0; i < steel.Count; i++)
            {
                steel[i].Draw(g);
            }
            for (int i = 0; i < equip.Count; i++)
            {
                equip[i].Draw(g);
            }
            #endregion
        }
        /// <summary>
        /// 碰撞检测
        /// </summary>
        public void HitCheck()
        {
            #region  玩家是否和敌人子弹碰撞
            for (int i = 0; i < enemyMissile.Count; i++)
            {
                if (p1Tank.Live >= 0)
                {
                    try
                    {
                        if (p1Tank.GetRectangle().IntersectsWith(enemyMissile[i].GetRectangle()))        //玩家1是否和敌人子弹碰撞
                        {                        
                            p1Tank.Life -= enemyMissile[i].power;
                            enemyMissile.Remove(enemyMissile[i]);
                            p1Tank.IsDead();
                        }
                    }
                    catch
                    { }
                }
                if (StartForm.isMultiplayer && p2Tank.Live >= 0)
                {
                    try
                    {
                        if (p2Tank.GetRectangle().IntersectsWith(enemyMissile[i].GetRectangle()))        //玩家2是否和和人子弹碰撞
                        {                        
                            p2Tank.Life -= enemyMissile[i].power;
                            enemyMissile.Remove(enemyMissile[i]);
                            p2Tank.IsDead(); ;
                        }
                    }
                    catch
                    { }
                }
                try
                {
                    if (symbol.GetRectangle().IntersectsWith(enemyMissile[i].GetRectangle()))
                    {
                        symbol.IsDestory = true;
                        enemyMissile.Remove(enemyMissile[i]);
                    }
                }
                catch
                { }
            }
            #endregion
            #region  玩家的子弹是否和敌人碰撞
            for (int i = 0; i < myMissile.Count; i++)
            {
                for (int j = 0; j < enemy.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(enemy[j].GetRectangle()))    //玩家的子弹是否和敌人碰撞
                        {
                            SoundPlayer sound = new SoundPlayer(Resources.hit);
                            sound.Play();
                            enemy[j].Life -= myMissile[i].power;
                            enemy[j].IsDead();
                            myMissile.Remove(myMissile[i]);

                        }
                    }
                    catch
                    { }
                }
                try
                {
                    if (symbol.GetRectangle().IntersectsWith(myMissile[i].GetRectangle()))
                    {
                        symbol.IsDestory = true;
                        myMissile.Remove(myMissile[i]);
                    }
                }
                catch
                { }
            }
            #endregion
            #region  玩家的子弹是否和敌人的子弹碰撞
            for (int i = 0; i < myMissile.Count; i++)
            {
                for (int j = 0; j < enemyMissile.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(enemyMissile[j].GetRectangle()))   //玩家的子弹是否和敌人的子弹碰撞
                        {
                            myMissile.Remove(myMissile[i]);
                            enemyMissile.Remove(enemyMissile[j]);
                        }
                    }
                    catch
                    { }
                }
            }
            #endregion
            #region  子弹是否和组件碰撞
            for (int i = 0; i < myMissile.Count; i++)
            {
                for (int j = 0; j < wall.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(wall[j].GetRectangle()))   //玩家的子弹是否和土墙碰撞
                        {
                            myMissile.Remove(myMissile[i]);
                            wall.Remove(wall[j]);
                        }
                    }
                    catch { }
                }
                for (int j = 0; j < steel.Count; j++)
                {
                    try
                    {
                        if (myMissile[i].GetRectangle().IntersectsWith(steel[j].GetRectangle()))   //玩家的子弹是否和钢墙碰撞
                        {
                            myMissile.Remove(myMissile[i]);
                        }
                    }
                    catch { }
                }
            }
            for (int i = 0; i < enemyMissile.Count; i++)
            {
                for (int j = 0; j < wall.Count; j++)
                {
                    try
                    {
                        if (enemyMissile[i].GetRectangle().IntersectsWith(wall[j].GetRectangle()))          //敌人的子弹是否和土墙碰撞
                        {
                            enemyMissile.Remove(enemyMissile[i]);
                            wall.Remove(wall[j]);
                        }
                    }
                    catch { }
                }
                for (int j = 0; j < steel.Count; j++)
                {
                    try
                    {
                        if (enemyMissile[i].GetRectangle().IntersectsWith(steel[j].GetRectangle()))          //敌人的子弹是否和钢墙碰撞
                        {
                            enemyMissile.Remove(enemyMissile[i]);
                        }
                    }
                    catch { }
                }
            }
            #endregion
            #region  坦克是否和土墙碰撞
            for (int i = 0; i < wall.Count; i++)
            {
                for (int j = 0; j < enemy.Count; j++)
                {
                    if (enemy[j].GetRectangle().IntersectsWith(wall[i].GetRectangle()))                //敌人是否和土墙碰撞
                    {
                        switch (enemy[j].dir)
                        {
                            case directions.U:
                                enemy[j].Y = wall[i].Y + wall[i].Height;
                                break;
                            case directions.D:
                                enemy[j].Y = wall[i].Y - enemy[j].Height;
                                break;
                            case directions.L:
                                enemy[j].X = wall[i].X + wall[i].Width;
                                break;
                            case directions.R:
                                enemy[j].X = wall[i].X - enemy[j].Width;
                                break;
                        }
                    }
                }
                if (p1Tank.GetRectangle().IntersectsWith(wall[i].GetRectangle()))          //玩家1是否和土墙碰撞
                {
                    switch (p1Tank.dir)
                    {
                        case directions.U:
                            p1Tank.Y = wall[i].Y + wall[i].Height;
                            break;
                        case directions.D:
                            p1Tank.Y = wall[i].Y - p1Tank.Height;
                            break;
                        case directions.L:
                            p1Tank.X = wall[i].X + wall[i].Width;
                            break;
                        case directions.R:
                            p1Tank.X = wall[i].X - p1Tank.Width;
                            break;
                    }

                }
                if (StartForm.isMultiplayer)
                {
                    if (p2Tank.GetRectangle().IntersectsWith(wall[i].GetRectangle()))              //玩家1是否和土墙碰撞
                    {
                        switch (p2Tank.dir)
                        {
                            case directions.U:
                                p2Tank.Y = wall[i].Y + wall[i].Height;
                                break;
                            case directions.D:
                                p2Tank.Y = wall[i].Y - p1Tank.Height;
                                break;
                            case directions.L:
                                p2Tank.X = wall[i].X + wall[i].Width;
                                break;
                            case directions.R:
                                p2Tank.X = wall[i].X - p1Tank.Width;
                                break;
                        }

                    }
                }

            }
            #endregion
            #region  坦克是否和钢墙碰撞
            for (int i = 0; i < steel.Count; i++)
            {
                for (int j = 0; j < enemy.Count; j++)
                {
                    if (enemy[j].GetRectangle().IntersectsWith(steel[i].GetRectangle()))                //敌人是否和钢墙碰撞
                    {
                        switch (enemy[j].dir)
                        {
                            case directions.U:
                                enemy[j].Y = steel[i].Y + steel[i].Height;
                                break;
                            case directions.D:
                                enemy[j].Y = steel[i].Y - enemy[j].Height;
                                break;
                            case directions.L:
                                enemy[j].X = steel[i].X + steel[i].Width;
                                break;
                            case directions.R:
                                enemy[j].X = steel[i].X - enemy[j].Width;
                                break;
                        }
                    }
                }
                if (p1Tank.GetRectangle().IntersectsWith(steel[i].GetRectangle()))          //玩家1是否和钢墙碰撞
                {
                    switch (p1Tank.dir)
                    {
                        case directions.U:
                            p1Tank.Y = steel[i].Y + steel[i].Height;
                            break;
                        case directions.D:
                            p1Tank.Y = steel[i].Y - p1Tank.Height;
                            break;
                        case directions.L:
                            p1Tank.X = steel[i].X + steel[i].Width;
                            break;
                        case directions.R:
                            p1Tank.X = steel[i].X - p1Tank.Width;
                            break;
                    }

                }
                if (StartForm.isMultiplayer)
                {
                    if (p2Tank.GetRectangle().IntersectsWith(steel[i].GetRectangle()))              //玩家1是否和钢墙碰撞
                    {
                        switch (p2Tank.dir)
                        {
                            case directions.U:
                                p2Tank.Y = steel[i].Y + steel[i].Height;
                                break;
                            case directions.D:
                                p2Tank.Y = steel[i].Y - p1Tank.Height;
                                break;
                            case directions.L:
                                p2Tank.X = steel[i].X + steel[i].Width;
                                break;
                            case directions.R:
                                p2Tank.X = steel[i].X - p1Tank.Width;
                                break;
                        }

                    }
                }
            }
            #endregion
            #region 坦克是否和河水碰撞
            for (int i = 0; i < water.Count; i++)
            {
                for (int j = 0; j < enemy.Count; j++)
                {
                    if (enemy[j].GetRectangle().IntersectsWith(water[i].GetRectangle()))                //敌人是否和河水碰撞
                    {
                        switch (enemy[j].dir)
                        {
                            case directions.U:
                                enemy[j].Y = water[i].Y + water[i].Height;
                                break;
                            case directions.D:
                                enemy[j].Y = water[i].Y - enemy[j].Height;
                                break;
                            case directions.L:
                                enemy[j].X = water[i].X + water[i].Width;
                                break;
                            case directions.R:
                                enemy[j].X = water[i].X - enemy[j].Width;
                                break;
                        }
                    }
                }
                if (p1Tank.GetRectangle().IntersectsWith(water[i].GetRectangle()))          //玩家1是否和河水碰撞
                {
                    switch (p1Tank.dir)
                    {
                        case directions.U:
                            p1Tank.Y = water[i].Y + water[i].Height;
                            break;
                        case directions.D:
                            p1Tank.Y = water[i].Y - p1Tank.Height;
                            break;
                        case directions.L:
                            p1Tank.X = water[i].X + water[i].Width;
                            break;
                        case directions.R:
                            p1Tank.X = water[i].X - p1Tank.Width;
                            break;
                    }
                }
                if (StartForm.isMultiplayer)
                {
                    if (p2Tank.GetRectangle().IntersectsWith(water[i].GetRectangle()))              //玩家1是否和河水碰撞
                    {
                        switch (p2Tank.dir)
                        {
                            case directions.U:
                                p2Tank.Y = water[i].Y + water[i].Height;
                                break;
                            case directions.D:
                                p2Tank.Y = water[i].Y - p1Tank.Height;
                                break;
                            case directions.L:
                                p2Tank.X = water[i].X + water[i].Width;
                                break;
                            case directions.R:
                                p2Tank.X = water[i].X - p1Tank.Width;
                                break;
                        }
                    }
                }
            }
            #endregion
            #region 玩家是否和装备碰撞
            for (int i = 0; i < equip.Count; i++)
            {
                try
                {
                    if (p1Tank.GetRectangle().IntersectsWith(equip[i].GetRectangle()))
                    {
                        SoundPlayer sound = new SoundPlayer(Resources.add);
                        sound.Play();
                        Equip(equip[i].Flag, 1);
                        equip.Remove(equip[i]);
                    }
                    if (p2Tank.GetRectangle().IntersectsWith(equip[i].GetRectangle()))
                    {
                        Equip(equip[i].Flag, 2);
                        equip.Remove(equip[i]);
                    }
                }
                catch
                { }
            }
            #endregion
        }
        public void RemoveElement(Element e)
        {
            #region 删除元素
            if (e is myMissile)
            {
                myMissile.Remove(e as myMissile);
                return;
            }
            if (e is Enemy)
            {
                enemy.Remove(e as Enemy);
                return;
            }
            if (e is EnemyMissile)
            {
                enemyMissile.Remove(e as EnemyMissile);
                return;
            }
            if (e is Blast)
            {
                blast.Remove(e as Blast);
                return;
            }
            if (e is Wall)
            {
                wall.Remove(e as Wall);
                return;
            }
            if (e is Grass)
            {
                grass.Remove(e as Grass);
                return;
            }
            if (e is Water)
            {
                water.Remove(e as Water);
                return;
            }
            if (e is Steel)
            {
                steel.Remove(e as Steel);
                return;
            }
            #endregion
        }
        /// <summary>
        /// 删除组件土墙.草地.水地.钢
        /// </summary>
        public void RemoveImg()        
        {
            for (int i = 0; i < wall.Count; i++)
            {
                try
                {
                    if (!EditForm.arrWall[wall[i].X / 15, wall[i].Y / 15])
                    {
                        wall.Remove(wall[i]);
                    }
                }
                catch
                { }
            }
            for (int i = 0; i < grass.Count; i++)
            {
                if (!EditForm.strArr[grass[i].X / 60, grass[i].Y / 60])
                {
                    grass.Remove(grass[i]);
                }
            }
            for (int i = 0; i < water.Count; i++)
            {
                if (!EditForm.strArr[water[i].X / 60, water[i].Y / 60])
                {
                    water.Remove(water[i]);
                }
            }
            for (int i = 0; i < steel.Count; i++)
            {
                if (!EditForm.arrSteel[steel[i].X / 30, steel[i].Y / 30])
                {
                    steel.Remove(steel[i]);
                }
            }
        }
        /// <summary>
        /// 玩家装备
        /// </summary>
        /// <param name="type">装备的型号</param>
        /// <param name="player">玩家</param>
        public void Equip(int type, int player)
        {
            switch (type)
            {
                case 0:
                    if (player == 1)
                    {
                        if (p1Tank.MisLv < 2)
                        {
                            p1Tank.MisLv++;
                        }
                        if (p1Tank.MisLv == 2)
                        {
                            p1Tank.Life++;
                        }
                    }
                    if (player == 2)
                    {
                        if (p2Tank.MisLv < 2)
                        {
                            p2Tank.MisLv++;
                        }
                        if (p1Tank.MisLv == 2)
                        {
                            p2Tank.Life++;
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].Life = 0;
                        enemy[i].IsDead();
                    }
                    break;
                case 2:
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].Enable = false;
                    }
                    break;
            }
        }

    }
}

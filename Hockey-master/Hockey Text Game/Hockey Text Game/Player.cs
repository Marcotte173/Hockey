﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string name;
    public int shot;
    public int pass;
    public int stick;
    public int run;
    public int def;
    public int save;
    public int school;
    public int canPlay;
    public int chances;
    
    public Player(string name, int shot, int pass, int stick, int run, int def, int save, int school)
    {
        this.name = name;
        this.shot = shot;
        this.pass = pass;
        this.stick = stick;
        this.run = run;
        this.def = def;
        this.save = save;
        this.school = school;
    }

    public string getName() { return name; }
    public int getShot() { return shot; }
    public int getPass() { return pass; }
    public int getStick() { return stick; }
    public int getRun() { return run; }
    public int getDef() { return def; }
    public int getSave() { return save; }
    public int getSchool() { return school; }
    public int getCanPlay() { return canPlay; }
    public int getChances() { return chances; }

    public void setChances(int i) { chances = i; }
    public void setCanPlay(int i) { canPlay = i; }
    public void setShot(int i) { shot = i; }
    public void setPass(int i) { pass = i; }
    public void setStick(int i) { stick = i; }
    public void setRun(int i) { run = i; }
    public void setDef(int i) { def = i; }
    public void setSave(int i) { save = i; }
    public void setSchool(int i) { school = i; }

}


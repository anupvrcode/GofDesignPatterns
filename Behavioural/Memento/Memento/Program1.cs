using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memento
{
    class Program1
    {
    /*static void Main(string[] args)
    {
        Originator<string> orig = new Originator<string>();

        orig.SetState("state0");
        Caretaker<string>.SaveState(orig); //save state of the originator
        orig.ShowState();

        orig.SetState("state1");
        Caretaker<string>.SaveState(orig); //save state of the originator
        orig.ShowState();

        orig.SetState("state2");
        Caretaker<string>.SaveState(orig); //save state of the originator
        orig.ShowState();

        //restore state of the originator
        Caretaker<string>.RestoreState(orig, 0);
        orig.ShowState();  //shows state0

        Console.ReadLine();
    }*/
}

//object that stores the historical state
public class Memento<t>
{
    private t state;

    public t GetState()
    {
        return state;
    }

    public void SetState(t state)
    {
        this.state = state;
    }
}

//the object that we want to save and restore, such as a check point in an application
public class Originator<t>
{
    private t state;

    //for saving the state
    public Memento<t> CreateMemento()
    {
        Memento<t> m = new Memento<t>();
        m.SetState(state);
        return m;
    }

    //for restoring the state
    public void SetMemento(Memento<t> m)
    {
        state = m.GetState();
    }

    //change the state of the Originator
    public void SetState(t state)
    {
        this.state = state;
    }

    //show the state of the Originator
    public void ShowState()
    {
        Console.WriteLine(state.ToString());
    }
}

//object for the client to access
public static class Caretaker<t>
{
    //list of states saved
    private static List<Memento<t>> mementoList = new List<Memento<t>>();

    //save state of the originator
    public static void SaveState(Originator<t> orig)
    {
        mementoList.Add(orig.CreateMemento());
    }

    //restore state of the originator
    public static void RestoreState(Originator<t> orig, int stateNumber)
    {
        orig.SetMemento(mementoList[stateNumber]);
    }
}
}

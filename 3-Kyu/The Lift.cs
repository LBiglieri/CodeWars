//I bet you won't ever catch a Lift (a.k.a. elevator) again without thinking of this Kata !

//Synopsis
//A multi-floor building has a Lift in it.

//People are queued on different floors waiting for the Lift.

//Some people want to go up. Some people want to go down.

//The floor they want to go to is represented by a number (i.e. when they enter the Lift this is the button they will press)

//Rules

//Lift Rules
//The Lift only goes up or down!
//Each floor has both UP and DOWN Lift-call buttons (except top and ground floors which have only DOWN and UP respectively)
//The Lift never changes direction until there are no more people wanting to get on/off in the direction it is already travelling
//When empty the Lift tries to be smart. For example,
//If it was going up then it may continue up to collect the highest floor person wanting to go down
//If it was going down then it may continue down to collect the lowest floor person wanting to go up
//The Lift has a maximum capacity of people
//When called, the Lift will stop at a floor even if it is full, although unless somebody gets off nobody else can get on!
//If the lift is empty, and no people are waiting, then it will return to the ground floor

//People Rules
//People are in "queues" that represent their order of arrival to wait for the Lift
//All people can press the UP/DOWN Lift-call buttons
//Only people going the same direction as the Lift may enter it
//Entry is according to the "queue" order, but those unable to enter do not block those behind them that can
//If a person is unable to enter a full Lift, they will press the UP/DOWN Lift-call button again after it has departed without them

//Kata Task
//Get all the people to the floors they want to go to while obeying the Lift rules and the People rules
//Return a list of all floors that the Lift stopped at (in the order visited!)

//NOTE: The Lift always starts on the ground floor (and people waiting on the ground floor may enter immediately)

//I / O
//Input
//queues a list of queues of people for all floors of the building.
//The height of the building varies
//0 = the ground floor
//Not all floors have queues
//Queue index [0] is the "head" of the queue
//Numbers indicate which floor the person wants go to
//capacity maximum number of people allowed in the lift
//Parameter validation - All input parameters can be assumed OK. No need to check for things like:

//People wanting to go to floors that do not exist
//People wanting to take the Lift to the floor they are already on
//Buildings with < 2 floors
//Basements
//Output
//A list of all floors that the Lift stopped at (in the order visited!)


using System.Collections.Generic;
using System.Linq;

public class Dinglemouse
{

    public static int[] TheLift(int[][] queues, int capacity)
    {
        var stoppedFloors = new List<int>() { 0 };
        var lift = new Lift(capacity, queues.Length - 1);
        for (var i = 0; i < queues.Length; i++)
        {
            if (queues[i].Length <= 0) continue;
            foreach (var i1 in queues[i])
            {
                lift.EntryWaitingQueues(new People(i, i1));
            }
        }
        lift.Run(ref stoppedFloors);
        return stoppedFloors.ToArray();
    }
}

public class Lift
{
    private readonly int _capacity;

    private readonly int _floorNumber;

    private readonly List<People> _ridingPeoples = new List<People>();

    private readonly List<People> _waitingPeoples = new List<People>();

    public Lift(int capacity, int floorNumber)
    {
        _capacity = capacity;
        _floorNumber = floorNumber;
        Direction = 1;
        CurrentFloor = 0;
    }

    public int Direction { get; private set; }

    public int CurrentFloor { get; private set; }

    private void ReverseDirection()
    {
        Direction *= -1;
    }

    private bool ExitArrivedPeople()
    {
        return _ridingPeoples.RemoveAll(p => p.WannaFloor == CurrentFloor) > 0;
    }

    private bool EntryOnePeople(People people)
    {
        if (_ridingPeoples.Count >= _capacity)
        {
            return false;
        }
        else
        {
            _ridingPeoples.Add(people);
            return true;
        }
    }

    private void GotoNextFloor()
    {
        CurrentFloor += Direction;
        if (CurrentFloor == _floorNumber || CurrentFloor == 0)
        {
            ReverseDirection();
        }
    }

    public void EntryWaitingQueues(People people)
    {
        _waitingPeoples.Add(people);
    }

    public void Run(ref List<int> stoppedFloors)
    {
        while (_waitingPeoples.Count > 0 || _ridingPeoples.Count > 0)
        {
            var needStop = ExitArrivedPeople();
            if (_ridingPeoples.Count < _capacity)
            {
                foreach (var currentFloorWaitingPeople in _waitingPeoples
                    .Where(p => p.StandingFloor == CurrentFloor && p.Direction == Direction).ToList())
                {
                    if (!EntryOnePeople(currentFloorWaitingPeople)) break;
                    needStop = true;
                    _waitingPeoples.Remove(currentFloorWaitingPeople);
                }
            }
            else
            {
                if (_waitingPeoples.Any(p => p.StandingFloor == CurrentFloor && p.Direction == Direction))
                {
                    needStop = true;
                }
            }

            if (needStop && stoppedFloors.Last() != CurrentFloor) stoppedFloors.Add(CurrentFloor);
            GotoNextFloor();
        }
        if (stoppedFloors.Last() != 0) stoppedFloors.Add(0);
    }
}

public class People
{
    public People(int standingFloor, int wannaFloor)
    {
        StandingFloor = standingFloor;
        WannaFloor = wannaFloor;
        Direction = standingFloor > wannaFloor ? -1 : 1;
    }

    public int StandingFloor { get; private set; }

    public int WannaFloor { get; private set; }

    public int Direction { get; private set; }
}

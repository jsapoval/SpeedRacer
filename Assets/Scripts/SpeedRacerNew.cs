using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRacerNew : MonoBehaviour
{
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2006;

    public float maxAcceleration = 0.98f;
    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    public class Fuel
    {
        public int fuelLevel;
        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

public Fuel carFuel = new Fuel(100);

    // Start is called before the first frame update
    void Start()
    {
        print("The racer moldes is " + carModel + "by" + carMaker + ". It has a " + engineType + "engine.");
        
        CheckWeight();

        if (yearMade >= 2009)
        {
            print(carModel + "was first introduced in " + yearMade);
            int carAge = CalculateAge(yearMade);
            print("This car is " + carAge + " years old.");

        } else
        {
            print(carModel + "was introduced in the 2010's");
            print("Its maximum acceleration is " + maxAcceleration + "m/s2");
        }

        print(CheckCharacteristics());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    void ConsumeFuel()
    {
        carFuel.fuelLevel = carFuel.fuelLevel - 10;
    }

    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel) 
        {
            case 70:
                print("Fuel level is nearing two-thirds.");
                break;
            case 50:
                print("Fuel level is at half amoun.");
                break;
            case 10:
                print("Warning! Fuel level is critically low.");
                break;
            default:
                print("Nothing to report.");
                break;
        }
    }

    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            print("The " + carModel + " weight less than 1500 kg.");
        }     
        else 
        {
            print("The " + carWeight + " weights over 1500 kg.");
        }
    }

    int CalculateAge(int yearMade)
    {
        return 2021 - yearMade;
    }

    // Update is called once per frame
    string CheckCharacteristics()
    {
       if (isCarTypeSedan)
       {
            return "Car type is sedan.";

       } else if (hasFrontEngine)
       {
              return "The car is not a sedan, but has a front engine.";
       } else
       {
              return "The car is neither a sedan nor its engine is a front.";
       }
    }
}
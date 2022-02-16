using System;
using System.Diagnostics;

class Checker
{
    private static float MAX_TEMPERATURE = 45f;
    private static float MIN_TEMPERATURE = 45f;

    private static float MAX_STATEOFCHARGE = 80f;
    private static float MIN_STATEOFCHARGE = 20;

    private static float LIMIT_CHARGERATE = 0.8f;


    static bool batteryIsOk(float temperature, float soc, float chargeRate) {

        return isInRange(0f,45f,temperature) && isInRange(20f,80f,soc) && isUnderLimit(0.8f,chargeRate);

    }

    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");

        
        Debug.Assert(isInRange(MIN_TEMPERATURE, MAX_TEMPERATURE, -1.3f) == false,"Temperature under range");
        Debug.Assert(isInRange(MIN_TEMPERATURE, MAX_TEMPERATURE, 45.5f) == false,"Temperature over range");

        Debug.Assert(isInRange(MIN_STATEOFCHARGE, MAX_STATEOFCHARGE, 19.5f) == false,"State of charge under range");
        Debug.Assert(isInRange(MIN_STATEOFCHARGE, MAX_STATEOFCHARGE, 80.2f) == false,"State of charge over range");

        Debug.Assert(isUnderLimit(LIMIT_CHARGERATE, 0.75f) == true,"Charge rate under limit");
        Debug.Assert(isUnderLimit(LIMIT_CHARGERATE, 0.82f) == false,"Charge rate over limit");


        return 0;
    }

    static bool isInRange(float minValue, float maxValue, float value){

        if(value < minValue || value > maxValue){

            isAtRisk(minValue, maxValue, value);

            return false;
        }

        return true;

    }

    static bool isUnderLimit(float limit, float value){

        if(value > limit){

            return false;
        }

        return true;

    }

    static bool isAtRisk(float minValue, float maxValue, float value)
    {
        float warningTolerance = maxValue * 0.05f;

        float upperLimit = maxValue - warningTolerance;

        float lowerLimit = minValue + warningTolerance;

        if (value < lowerLimit || value > upperLimit)
        {
            Console.WriteLine("WARNING: Please check the levels of the battery");

            return false;
        }
        else
        {
            return true;
        }

    }

    //This functions "ExpectTrue" and "ExpectFalse" were cloned from the initial commit
    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    
}
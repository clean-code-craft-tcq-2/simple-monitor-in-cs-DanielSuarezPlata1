using System;
using System.Diagnostics;

class Checker
{

    static bool isInRange(float minValue, float maxValue, float value){

        if(value < minValue || value > maxValue){

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

    static bool batteryIsOk(float temperature, float soc, float chargeRate) {

        return isInRange(0f,45f,temperature) && isInRange(20f,80f,soc) && isUnderLimit(0.8f,chargeRate);

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
    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");

        
        Debug.Assert(isInRange(0f,45f,-1.3f) == false,"Temperature under range");
        Debug.Assert(isInRange(0f,45f,45.5f) == false,"Temperature over range");

        Debug.Assert(isInRange(20f,80f,19.5f) == false,"State of charge under range");
        Debug.Assert(isInRange(20f,80f,80.2f) == false,"State of charge over range");

        Debug.Assert(isUnderLimit(0.8f,0.75f) == true,"Charge rate under limit");
        Debug.Assert(isUnderLimit(0.8f,0.82f) == false,"Charge rate over limit");

        return 0;
    }
}
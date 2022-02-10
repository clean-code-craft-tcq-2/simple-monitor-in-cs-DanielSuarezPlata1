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
        return 0;
    }
}
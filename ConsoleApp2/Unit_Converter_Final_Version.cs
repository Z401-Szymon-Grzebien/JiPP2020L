using System;
class cException : System.FormatException
{
    public int TryCatchDecision()
    {
        int decision = 0;
        try{decision = Convert.ToInt16(Console.ReadLine());}
        catch(FormatException)
        {
            Console.WriteLine("ERROR: a string/sign value entered! Changed by default to option No. (1)");
            decision = 1;
        }
        return decision;
    }
    public int TryCatchDecision2()
    {
    int decision2 = 0;
    try{decision2 = Convert.ToInt16(Console.ReadLine());}
    catch(FormatException)
    {
        Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
        decision2 = 1;
        }
        return decision2;
    }
    public int TryCatchAnswer()
    {   
        int answer = 0;
        try{answer = Convert.ToInt16(Console.ReadLine());}
        catch(FormatException)
            {
                Console.WriteLine("ERROR: a string/sign value entered! Changed by default to option No. (1)");
                answer = 1;
            }
        return answer;
    }
    public double TryCatchSetValue()
    {
        double setValue = 0.0;
        try{setValue = Convert.ToDouble(Console.ReadLine());}
        catch(FormatException)
        {
            Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
            setValue = 0.0;
        }
        return setValue;
    }
}

class cUnits : cException
{
    double _variable = 0.0;
    public double ConvertFarenheitToCelsius(double variable)
    {
        this._variable = (variable - 32) / 1.8 ;
        return _variable;
    }
    public double ConvertCelsiusToFarenheit(double variable)
    {
        this._variable = (variable * 1.8) + 32 ;
        return _variable;
    }
    public double ConvertKMToMiles(double variable)
    {
        this._variable = variable * 0.62137;
        return _variable;
    }
    public double ConvertMilestoKM(double variable)
    {
        this._variable = (variable / 0.62137);
        return _variable;
    }
    public double ConvertPoundstoKG(double variable)
    {
        this._variable = variable / 2.2046;
        return _variable;
    }
    public double ConvertKGtoPounds(double variable)
    {
        this._variable = variable * 2.2046;
        return _variable;
    }
}

class cCountIt : cUnits
{ 
        bool test = true;
        public void ConvertUnits()
        {
            while(test==true)
            {       Console.WriteLine("What would you like to convert? \n1 - temperature \n2 - weight \n3 - length");
                        switch(TryCatchDecision())
                        {
                            case 1:
                                Console.WriteLine("1 - Celsius --> Farenheit \n2 - Farenheit --> Celsius");
                                    switch(TryCatchAnswer())
                                    {
                                        case 1:
                                        Console.WriteLine("Enter value: ");
                                        Console.WriteLine("Temperature: " + ConvertCelsiusToFarenheit(TryCatchSetValue()) + " [F].\n");
                                            break;
                                        case 2:
                                        Console.WriteLine("Enter value: ");  
                                        Console.WriteLine("Temperature: " + ConvertFarenheitToCelsius(TryCatchSetValue()) + " [C].\n");
                                            break;
                                        default:
                                        Console.WriteLine("ERROR");
                                            break;
                                    }
                                break;
                            case 2:
                                Console.WriteLine("1 - kg --> pounds \n2 - pounds --> kg");
                                    switch(TryCatchAnswer())
                                    {
                                        case 1:
                                        Console.WriteLine("Weight: " + ConvertKGtoPounds(TryCatchSetValue()) + " [Ib].\n");
                                            break;
                                        case 2:
                                        Console.WriteLine("Enter value: ");
                                        Console.WriteLine("Weight: " + ConvertPoundstoKG(TryCatchSetValue()) + " [kg].\n");
                                            break;
                                        default:
                                        Console.WriteLine("ERROR");
                                        break;
                                    }
                                break;
                            case 3:
                                Console.WriteLine("1 - km --> miles \n2 - miles --> km");
                                    switch(TryCatchAnswer())
                                    {
                                        case 1:
                                        Console.WriteLine("Enter value: ");
                                        Console.WriteLine("Length: " + ConvertKMToMiles(TryCatchSetValue()) + " [mile(s)].\n");
                                            break;
                                        case 2:
                                        Console.WriteLine("Enter value: ");
                                        Console.WriteLine("Length: " + ConvertMilestoKM(TryCatchSetValue()) + " [km].\n");
                                            break;
                                        default:
                                        Console.WriteLine("ERROR");
                                            break;
                                    }
                                break;
                        }
                                    Console.WriteLine("Would you like to convert again? \n1 - YES \n2 - NO");
                                    if(TryCatchDecision2() == 2)
                                    {
                                        Console.WriteLine("Unit Converter has stopped working.");
                                        break;
                                    }
                                    else 
                                    continue;
            }
        }
    }  

class cDevice : cCountIt
{
    protected string _deviceName = "default";
    protected int _deviceIndexNumber = 0;
    public cDevice(string deviceName, int deviceIndexNumber)
    {
        this._deviceName = deviceName;
        this._deviceIndexNumber = deviceIndexNumber;
    }
    public string getDeviceName
    {
        get{return this._deviceName;}
        set{this._deviceName = value;}
    }
    public void displayDeviceName()
    {
        Console.WriteLine("Name: " + _deviceName);
    }
    public void displayDeviceIndexNumber()
    {
        Console.WriteLine("Index number: " + _deviceIndexNumber);
    }
}
//---------------------------------------------------------------------
class JiPP 
{
    public static void Main(string[] args) 
    {  
        cDevice simpleCalc = new cDevice("Unit converter",1);
        Console.WriteLine("Device ON: ");
        simpleCalc.displayDeviceName();
        simpleCalc.displayDeviceIndexNumber();
        Console.WriteLine("Preferred input type for converting unit values: x.x");
        Console.WriteLine("\n--------------------------------------------------------------");
        simpleCalc.ConvertUnits();
    }
}
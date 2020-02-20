using System;
class cException : System.FormatException{}
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
        int decision = 0, decision2 = 0 , answer = 0;
        double setValue = 0.0;
  
        public void ConvertUnits()
        {
            while(test==true)
            {       Console.WriteLine("What would you like to convert? \n1 - temperature \n2 - weight unit \n3 - length");
                    try{decision = Convert.ToInt16(Console.ReadLine());}
                    catch(FormatException)
                    {
                        Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                        decision = 1;
                    }
                        switch(decision)
                        {
                            case 1:
                                Console.WriteLine("1 - Celsius --> Farenheit \n2 - Farenheit --> Celsius");
                                try{answer = Convert.ToInt16(Console.ReadLine());}
                                catch(FormatException)
                                {
                                     Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                     answer = 1;
                                }
                                    switch(answer)
                                    {
                                        case 1:
                                        Console.WriteLine("Enter value: ");
                                        try{setValue = Convert.ToDouble(Console.ReadLine());}
                                        catch(FormatException)
                                        {
                                            Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                            setValue = 0.0;
                                        }

                                        Console.WriteLine("Temperature in Farenheit: " + ConvertCelsiusToFarenheit(setValue) + " [F].\n");
                                            break;
                                        case 2:
                                        Console.WriteLine("Enter value: ");  
                                        try{setValue = Convert.ToDouble(Console.ReadLine());}
                                        catch(FormatException)
                                        {
                                            Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                            setValue = 0.0;
                                        }
                                        Console.WriteLine("Temperature in Celsius: " + ConvertFarenheitToCelsius(setValue) + " [C].\n");
                                            break;
                                        default:
                                        Console.WriteLine("ERROR");
                                            break;
                                    }
                                break;
                            case 2:
                                Console.WriteLine("1 - kg --> pounds \n2 - pounds --> kg");
                                try{answer = Convert.ToInt16(Console.ReadLine());}
                                catch(FormatException)
                                {
                                    Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                    answer = 1;
                                }
                                    switch(answer)
                                    {
                                        case 1:
                                        Console.WriteLine("Enter value: ");
                                        try{setValue = Convert.ToDouble(Console.ReadLine());}
                                        catch(FormatException)
                                        {
                                            Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                            setValue = 0.0;
                                        }

                                        Console.WriteLine("Weight in Ib: " + ConvertKGtoPounds(setValue) + " [Ib].\n");
                                            break;
                                        case 2:
                                        Console.WriteLine("Enter value: ");
                                        try{setValue = Convert.ToDouble(Console.ReadLine());}
                                        catch(FormatException)
                                        {
                                            Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                            setValue = 0.0;
                                        }
                                        Console.WriteLine("Weight in kg: " + ConvertPoundstoKG(setValue) + " [kg].\n");
                                            break;
                                        default:
                                        Console.WriteLine("ERROR");
                                            break;
                                    }
                                break;
                            case 3:
                                Console.WriteLine("1 - km --> miles \n2 - miles --> km");
                                try{answer = Convert.ToInt16(Console.ReadLine());}
                                catch(FormatException)
                                {
                                    Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                    answer = 1;
                                }
                                    switch(answer)
                                    {
                                        case 1:
                                        Console.WriteLine("Enter value: ");
                                        try{setValue = Convert.ToDouble(Console.ReadLine());}
                                        catch(FormatException)
                                        {
                                            Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                            setValue = 0.0;
                                        }
                                        Console.WriteLine("Length in miles: " + ConvertKMToMiles(setValue) + " [mile(s)].\n");
                                            break;
                                        case 2:
                                        Console.WriteLine("Enter value: ");
                                        try{setValue = Convert.ToDouble(Console.ReadLine());}
                                        catch(FormatException)
                                        {
                                            Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                            setValue = 0.0;
                                        }
                                        Console.WriteLine("Length in miles: " + ConvertMilestoKM(setValue) + " [km].\n");
                                            break;
                                        default:
                                        Console.WriteLine("ERROR");
                                            break;
                                    }
                                break;
                        }
                                    Console.WriteLine("Would you like to convert again? \n1 - YES \n2 - NO");
                                    try{decision2 = Convert.ToInt16(Console.ReadLine());}
                                    catch(FormatException)
                                    {
                                        Console.WriteLine("ERROR: a string value entered! Changed by default to option No. (1)");
                                        decision2 = 1;
                                    }
                                    if(decision2 == 2)
                                    {
                                        Console.WriteLine("Converter Unit has stopped working.");
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

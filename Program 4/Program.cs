//Grading ID: R7828
//CIS 199-01
//Program 4
//Due 12/1/2020
//This program creates six service order objects, outputs the data and calculated cost, modifies a property for each order, then displays the data again.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUM_OF_ORDERS = 6; //6 orders have been completed
            
            //instantiated the objects and hardcoded values to them
            ServiceOrder[] serviceOrders = new ServiceOrder[NUM_OF_ORDERS];
            
            serviceOrders[0] = new ServiceOrder(11111, "11111", "1111111111", 111, "John Doe", true);
            serviceOrders[1] = new ServiceOrder(22222, "22222", "2222222222", 22, "James Smith", true);
            serviceOrders[2] = new ServiceOrder(33333, "33333", "3333333333", 33, "Sarah Jones", true);
            serviceOrders[3] = new ServiceOrder(44444, "44444", "4444444444", 44, "Oscar Mitchell", false);
            serviceOrders[4] = new ServiceOrder(55555, "55555", "5555555555", 55, "Mary Hughes", false);
            serviceOrders[5] = new ServiceOrder(66666, "66666", "6666666666", 66, "Dylan Lewis", false);

            //displayed the output
            DisplayServiceOrder(serviceOrders);

            //changed the zipcode on each order
            serviceOrders[0].ZipCode = 12121;
            serviceOrders[1].ZipCode = 23232;
            serviceOrders[2].ZipCode = 34343;
            serviceOrders[3].ZipCode = 45454;
            serviceOrders[4].ZipCode = 56565;
            serviceOrders[5].ZipCode = 67676;
           
            serviceOrders[1].Technician = " "; //the default value is used for the technician name instead
            
            //displayed the output again
            DisplayServiceOrder(serviceOrders);
        }

        //Display Service Order Method
        //Preconditions: an valid object is passed to the parameter 
        //Postconditions: the ToString() and CalcCost() methods are output for each object in the array
        public static void DisplayServiceOrder(params ServiceOrder[] orders)
        {
            foreach(ServiceOrder order in orders)
            {
                WriteLine(order.ToString());
                Write("Cost: ");
                double doubleCost = order.CalcCost(); //local variable for storing the cost 
                string stringCost = doubleCost.ToString("C"); 
                WriteLine(stringCost);
                WriteLine();
            }
        }
    }
    class ServiceOrder
    {
        private int zipCode; //backing field for the ZipCode property
        private string modelNum; //backing field for the ModelNum property
        private string serialNum; //backing field for the SerialNum property
        private int length; //backing field for the Length property
        private string technician; //backing field for the Technician property
        private bool warranty; //backing field for the Warranty property

        private const int MIN_ZIP = 00000; //lowest possible value for the zip code
        private const int MAX_ZIP = 99999; //highest possible value for the zip code
        private const int DEFAULT_ZIP = 40204; //the default value of the zip code
        private const int MODELNUM_LENGTH = 5; //all model nums must be 5 characters
        private const int SERIALNUM_LENGTH = 10; //all serial nums must be 10 characters
        private const string DEFAULT_MODELNUM = "A1234"; //the default value for the model num
        private const string DEFAULT_SERIALNUM = "C123456789"; //the default value for the serial num
        private const string DEFAULT_TECHNICIAN = "John Smith"; //the default value for the technician
        private const int MIN_LENGTH = 15; //lowest possible value for the length
        private const int MAX_LENGTH = 180; //highest possible value for the length
        private const int DEFAULT_LENGTH = 30; //the default value for the length
        private const int WARRANTY_COST = 20; //cost under warranty is always $20
        private const int FLAT_FEE = 25; //initial cost when not under warranty
        private const double FEE_PER_MIN = 1.50; //additional cost per minute when not under warranty
        private const int MINS_TO_HOURS = 60; //60 mins = 1 hour

        //Constructor
        //Precondition: values for each argument are valid in the corresponding property
        //Postcondition: a new ServiceOrder object is created
        public ServiceOrder(int zipInput, string modelInput, string serialInput, int lengthInput, string technicianInput, bool warrantyInput)
        {
            ZipCode = zipInput;
            ModelNum = modelInput;
            SerialNum = serialInput;
            Length = lengthInput;
            Technician = technicianInput;
            Warranty = warrantyInput;
        }

        //Zip Property
        //Preconditions: Zip Code between 00000 and 99999
        //Postconditions: Zip Code is returned
        public int ZipCode
        {
            get
            {
                return zipCode;
            }
            set //Postcondition: if the zip code doesn't fall between 00000 and 99999 the default value of "40204" is used instead
            {
                if (value >= MIN_ZIP && value <= MAX_ZIP)
                    zipCode = value;
                else
                    zipCode = DEFAULT_ZIP;
            }
        }

        //Model Number Property
        //Preconditions: Model Number is 5 characters
        //Postconditions: Model Number is returned
        public string ModelNum
        {
            get
            {
                return modelNum;
            }
            set //Postcondition: if the model number is not 5 characters it is assigned the default value of "A1234"
            {
                if (value.Length == MODELNUM_LENGTH)
                    modelNum = value;
                else
                    modelNum = DEFAULT_MODELNUM;
            }
        }

        //Serial Number Property
        //Preconditions: Serial Num is 10 characters
        //Postconditions: Serial number is returned
        public string SerialNum
        {
            get
            {
                return serialNum;
            }
            set //Postcondition: if the serial number is not 10 characters it is assigned the default value of "C123456789" 
            {
                if (value.Length == SERIALNUM_LENGTH)
                    serialNum = value;
                else
                    serialNum = DEFAULT_SERIALNUM;
            }
        }

        //Length Property
        //Preconditions: Length is between 15 and 180 mins
        //Postcondtions: Length is returned
        public int Length
        {
            get
            {
                return length;
            }
            set //Postcondition: if the length is not between 15 mins and 180 mins it is assigned the default value of "30" mins 
            {
                if (value >= MIN_LENGTH && value <= MAX_LENGTH)
                    length = value;
                else
                    length = DEFAULT_LENGTH;
            }
        }

        //Technician Property
        //Preconditions: Technician name cannot be blank
        //Postconditions: Technician is returned
        public string Technician
        {
            get
            {
                return technician;
            }
            set //Postcondition: if the technician value is not entered it is assigned the default value of "John Smith"
            {
                if (string.IsNullOrWhiteSpace(value) == false)
                    technician = value;
                else
                    technician = DEFAULT_TECHNICIAN;

            }
        }

        //Warranty Property
        //Preconditions: None
        //Postconditions: Warranty is returned
        public bool Warranty
        {
            get
            {
                return warranty;
            }
            set //Postcondition: the value is assigned to the backing field
            {
                warranty = value;
            }
        }

        //Convert to Hours Property
        //Preconditions: none
        //Postconditions: Length in converted from minutes to hours and returned
        public double LengthInHours
        {
            get
            {
                return (Convert.ToDouble(Length) / MINS_TO_HOURS);
            }
        }

        //ToString Method
        //Preconditions:  An object has been instantiated
        //Postconditions: Returns string listing the properties of the object
        public override string ToString()
        {
            return ("Sevice Location Zip Code: " + ZipCode + "\nModel Number: " + ModelNum + "\nSerial Number: " +
                         SerialNum + "\nAppointment Length: " + Length + "\nAppointment Hours: " + LengthInHours +
                         "\nTechnician Name: " + Technician + "\nWarranty Coverage?: " + Warranty);
        }

        //CalcCost Method
        //Preconditions: None
        //Postconditions: calculates and returns cost value
        public double CalcCost()
        {
            if (Warranty == true)
                return WARRANTY_COST;
            else
                return (FLAT_FEE + (FEE_PER_MIN * Length));
        }
    }
}

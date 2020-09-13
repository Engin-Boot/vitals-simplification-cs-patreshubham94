using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVital_Exercise
{
    public class AlertVitals {
        
        public  Dictionary<string, double> lower_limit = new Dictionary<string, double>() {
            { "BPM", 70.00}, { "RespRate", 30.00}, {"SPO2", 90.00 }
        };

        public  Dictionary<string, double> upper_limit = new Dictionary<string, double>() {
            { "BPM", 150.00}, { "RespRate", 95.00}, {"SPO2", 101.00 }
        };
    }

    public class Alert {
        public string Message;
        public bool status;
    }

    class VitalsCheck {
        public  Alert VitalIsOk(AlertVitals av, string vital_name ,int value) {
            Alert alrt = new Alert();

            if (av.lower_limit.ContainsKey(vital_name) == false) {
                //Console.WriteLine("Please check entered Vitals / WRONG vital is entered");
                alrt.status = false;
                alrt.Message = "Please check entered Vitals / WRONG vital is entered";
                return alrt;
            }

            else if (av.lower_limit[vital_name] > value)
            {
                alrt.status = false;
                alrt.Message = vital_name + " is Low..!!";
                return alrt;
            }

            else if (av.upper_limit[vital_name] < value) {
                alrt.status = false;
                alrt.Message =  vital_name+" is High..!!";
                return alrt;
            }
           
                alrt.status = true;
                alrt.Message = vital_name+" status is good..";
                return alrt;
           
             
        }
    }

    public class alertPrint {
        public  void printAlert(Alert alrt) {
            Console.WriteLine(alrt.Message);
        }
    }


    class Program
    {
        static void ExpectTrue(Alert result)
        {
            if (!(result.status))
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }
        static void ExpectFalse(Alert result)
        {
            if (result.status)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }

        static void Main(string[] args)
        {
            alertPrint p = new alertPrint();
            VitalsCheck vc = new VitalsCheck();
            AlertVitals av = new AlertVitals();

           
            p.printAlert(vc.VitalIsOk(av, "SPO2",95 ));
            p.printAlert(vc.VitalIsOk(av, "SPO2", 88));
            p.printAlert(vc.VitalIsOk(av, "BPM", 160));
            p.printAlert(vc.VitalIsOk(av, "RespRate", 40));
            p.printAlert(vc.VitalIsOk(av, "BPM", 111));

            p.printAlert(vc.VitalIsOk(av, "Sugar", 111)); //handelling Unknown vital
            
            ExpectTrue(vc.VitalIsOk(av, "RespRate", 50));
            ExpectFalse(vc.VitalIsOk(av, "RespRate", 100));
            Console.WriteLine("All ok");

        }
    }   
}

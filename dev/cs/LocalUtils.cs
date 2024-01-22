namespace LocalUtils {
    class StringLocalUtils{
        static public string EncodeToAscii(string input){
            return EncodeToAscii(input.ToCharArray());
        }

        static public string EncodeToAscii(char[] input){
            return string.Join("", input.Where(x=> ((int)x) < 127));
        }

        static public bool IsAlphabetic(char variable){
            return IsAlphabetic(variable.ToString());
        }

        static public bool IsAlphabetic(string variable){
            return System.Text.RegularExpressions.Regex.IsMatch(variable, @"^[a-zA-Z]+$");
        }

        static public bool IsNumeric(char variable){
            return IsNumeric(variable.ToString());
        }

        static public bool IsNumeric(string variable){
            return System.Text.RegularExpressions.Regex.IsMatch(variable, @"^[0-9]+$");
        }

    }

    class InputUtils{
        static public string GetPrecode(){
            string inputPrecode = "";
            while (
                inputPrecode.Length < 4 || inputPrecode.Length > 4
                || !StringLocalUtils.IsAlphabetic(inputPrecode[0])
                || !StringLocalUtils.IsNumeric(inputPrecode.Substring(1))
            )
            {
                Console.WriteLine("Please Enter your Precode :");
                inputPrecode = Console.ReadLine();
            }
            return inputPrecode.ToUpper();
        }

    }
}

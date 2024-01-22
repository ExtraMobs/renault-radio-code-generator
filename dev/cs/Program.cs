using System;


class Program{
    static string EncodeToAscii(string input){
        return EncodeToAscii(input.ToCharArray());
    }

    static string EncodeToAscii(char[] input){
        return string.Join("", input.Where(x=> ((int)x) < 127));
    }

    static bool IsAlpha(string variable){
        return System.Text.RegularExpressions.Regex.IsMatch(variable, @"^[a-zA-Z]+$");
    }

    static bool IsNumeric(string variable){
        return System.Text.RegularExpressions.Regex.IsMatch(variable, @"^[0-9]+$");
    }

    static string GetPrecode(){
        string inputPrecode = "";
        while (
            (inputPrecode.Length < 4 || inputPrecode.Length > 4)
            || !(IsAlpha(inputPrecode[0].ToString()))
            || !(IsNumeric(inputPrecode.Substring(1)))
        )
        {
            Console.WriteLine("Please Enter your Precode :");
            inputPrecode = Console.ReadLine();
        }
        return inputPrecode.ToUpper();
    }

    static string GenerateRadioCode(string precode){
        char[] precode_array = EncodeToAscii(precode).ToCharArray();

        int x = precode_array[1] + precode_array[0] * 10 - 698;
        int y = precode_array[3] + precode_array[2] * 10 + x - 528;
        int z = (y * 7) % 100;

        string generat_code = (Math.Floor((double)(z / 10)) + (z % 10) * 10 + ((259 % x) % 100) * 5 * 5 * 4).ToString();

        return new string('0', 4-generat_code.Length) + generat_code;
    }

    static void Main(string[] args){
        string precode = GetPrecode();
        Console.WriteLine(GenerateRadioCode(precode));
    }
}

using LocalUtils;

namespace RadioCodeGenerator{
    class Generator{
        static public string GenerateRadioCode(string precode){
            char[] precode_array = StringLocalUtils.EncodeToAscii(precode).ToCharArray();

            int x = precode_array[1] + precode_array[0] * 10 - 698;
            int y = precode_array[3] + precode_array[2] * 10 + x - 528;
            int z = (y * 7) % 100;

            string generat_code = (Math.Floor((double)(z / 10)) + (z % 10) * 10 + ((259 % x) % 100) * 100).ToString();

            return new string('0', 4-generat_code.Length) + generat_code;
        }
    }
}

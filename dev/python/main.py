import math


def get_precode():
    input_precode = ""
    while (
        (len(input_precode) < 4 or len(input_precode) > 4)
        or not input_precode[0].isalpha()
        or not input_precode[1:].isnumeric()
    ):
        input_precode = input("Please Enter your Precode :\n")
    return input_precode.upper()


def generate_radio_code(precode):
    precode = precode.encode("ascii", "ignore")

    x = precode[1] + precode[0] * 10 - 698
    y = precode[3] + precode[2] * 10 + x - 528
    z = (y * 7) % 100
    
    generat_code = str(
        (math.floor(z / 10) + (z % 10) * 10 + ((259 % x) % 100) * 5 * 5 * 4)
    )
    output = "0000"[: -len(generat_code)] + generat_code
    return output


print(generate_radio_code(get_precode()))

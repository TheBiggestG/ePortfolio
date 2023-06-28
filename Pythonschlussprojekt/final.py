import random
import os
import string


class Encoder:
    def __init__(self, key, message, option):
        self.cipher = key
        if option == "random":
            self.cipher = random.randint(0, 255)  # generates a random key
        elif option == "binary":
            self.cipher = int(key, 2)  # converts the binary key to an integer key

        encodedList = []
        for i in range(len(message)):
            encodedList.append(ord(message[i]) ^ self.cipher)

        self.encodedList = encodedList

    def get_Code_as_String(self):
        convertedList = []
        for a in self.encodedList:
            convertedList.append(chr(a))

        encoded_message = ' '.join(convertedList)  # converts string list to string
        return encoded_message


class Decoder:
    def __init__(self, key, message, option):
        self.cipher = key
        if option == "binary":
            self.cipher = int(key, 2)

        decodedList = []
        messageList = message.split()
        for i in range(len(messageList)):
            decodedList.append(ord(messageList[i]) ^ self.cipher)

        self.decodedList = decodedList

    def get_unCode_as_String(self):
        convertedList = []
        for a in self.decodedList:
            convertedList.append(chr(a))

        decoded_message = ' '.join(convertedList)  # converts string list to string
        return decoded_message


isRunning = True

while isRunning:
    os.system('cls')
    print("Encoder / Coder program")
    print("-----------------------")
    print()

    mode = ""
    while mode != "encoding" and mode != "decoding":
        mode = input("Please choose between encoding and decoding mode: ")

    if mode == "encoding":
        os.system('cls')
        print("Encoding mode selected")

        encoding_type = ""
        while encoding_type != "binary" and encoding_type != "ascii" and encoding_type != "random":
            encoding_type = input("Please input which type of key you would like (binary/ascii/random): ")

        key = None
        if encoding_type == "binary":
            os.system('cls')
            print("Binary key selected")
            isNotBin = True
            while isNotBin:  # This block checks if the input is a binary
                cipher = input("Please input an 8-character long binary: ")
                b = '10'
                isNotBin = False
                for char in cipher:
                    if char not in b:  # checks if any characters in 'b' are present in the string
                        isNotBin = True
                        break

                if len(cipher) != 8:  # Checks if the cipher is exactly 8 characters long
                    isNotBin = True

        if encoding_type == "ascii":
            os.system('cls')
            print("Ascii key selected")
            cipher = 256
            while cipher < 0 or cipher > 255:
                cipher = int(input("Please input an ASCII number between 0 and 255: "))

        if encoding_type == "random":
            os.system('cls')
            print("Random key selected")
            print("Your key will be provided at the end of encoding")
            cipher = None

        message = input("Please input your message: ")
        encoding = Encoder(cipher, message, encoding_type)
        encoded_message = encoding.get_Code_as_String()
        print("Encoded message:", encoded_message)
        print("Cipher:", encoding.cipher)

    elif mode == "decoding":
        os.system('cls')
        print("Decoding mode")

        decoding_type = ""
        while decoding_type != "binary" and decoding_type != "ascii":
            decoding_type = input("Please input which type of key you would like (binary/ascii): ")

        if decoding_type == "binary":
            os.system('cls')
            print("Binary key selected")
            isNotBin = True
            while isNotBin:  # This block checks if the input is a binary
                cipher = input("Please input an 8-character long binary: ")
                b = '10'
                isNotBin = False
                for char in cipher:
                    if char not in b:  # checks if any characters in 'b' are present in the string
                        isNotBin = True
                        break

                if len(cipher) != 8:  # Checks if the cipher is exactly 8 characters long
                    isNotBin = True

        if decoding_type == "ascii":
            os.system('cls')
            print("Ascii key selected")
            cipher = -1
            while cipher < 0 or cipher > 255 or cipher is None:
                cipher = int(input("Please input an ASCII number between 0 and 255: "))

        message = input("Please input your coded message: ")
        decoding = Decoder(cipher, message, decoding_type)
        decoded_message = decoding.get_unCode_as_String()
        print("Decoded message:", decoded_message)
        print("Cipher:", decoding.cipher)

    repeat = input("Do you want to encode/decode another text? (y/n): ")
    if repeat.lower() != 'y':
        isRunning = False

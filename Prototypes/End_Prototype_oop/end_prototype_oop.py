import random
import os
import string


class Encoder:
    def __init__(self, key, message, option): #when encoder is called, the message will be encoded with the key and will be given out as a Ascii list
            if option == "random":
                key = random.randint(0, 255) #generates a random key
                print("random key is " + key)
            if option == "binary":
                key = int(key, 2) #converts the binary key to a integer key
            converted =[]
            encodedList = []

            for i in message:
                converted [i] = ord(chr(message[i])) #converts the string into a ascii list
            for i in converted:
                encodedList [i] = converted[i] ^ key #encrypts the ascii list with XOR
            self.encodedList = encodedList #end result

    def get_Code_as_String(self): #converts the coded message to a normal string
        converted = []
        convertedList = None
        for a in self.encodedList: # converts ascii list to string:
            convertedList [a][b] = chr(self.encodedList[a][b])
        converted = ' '.join([str(elem) for elem in convertedList]) #converts string list to string
    
class Decoder:
    def __init__(self, key, message, option):
        if option == "binary":
            key = int(key, 2) # converts to the key to an Ascii key<
        converted =[]
        decodedList = []
        for i in message:
            converted [i] = ord(chr(message[i])) #converts the string to a string list
        for i in converted:
            decodedList [i] = converted[i] ^ key 
        self.decodedList = decodedList
            
        
    def get_unCode_as_String(self):
        converted = []
        convertedList = None
        for a in self.encodedList: # converts ascii list to string list
            for b in self.encodedList[a]:
                convertedList [a][b] = chr(self.encodedList[a][b])
        converted = ' '.join([str(elem) for elem in convertedList]) #converts string list to string
        return

isRunning = True

while isRunning:
    os.system('cls')
    print("Encoder / Coder program")
    print("-----------------------")
    print()
    mode = "a"

    while mode != "encoding" and mode != "decoding":
        mode = input ("Please choose between encoding and decoding mode: ")
    if mode == "encoding":
        os.system('cls')
        print("Encoding mode selected")
        encoding_type = None
        while encoding_type != "binary" and encoding_type != "ascii" and encoding_type != "random":
            encoding_type = input ("Please input which of key you would like (binary/ascii/random)")
        key = None
        isKeyQuery = True
        if encoding_type == "binary":
            os.system('cls')
            print("Binary key selected")
            isNotBin = True
            while isNotBin: #This block checks if the input is a binary
                cipher = string(input("Please input a 8 character long binary"))
                b = '10'
                isNotBin = True
                for char in cipher:
                    if char not in b: #checks if any characters in 'b' are present in the string
                        isNotBin = False
                        break
                    else:
                        pass
                if len(cipher) > 8: #Checks if the cipher is more than 8 characters long
                    isNotBin = True
                
                
        if encoding_type == "ascii":
            os.system('cls')
            print("Ascii key selected")
            cipher = 256
            while cipher < 0 or cipher > 255:
                cipher = int(input("Please input an ascii number between 0 and 255"))

        if encoding_type == "random":
            os.system('cls')
            print("Random key selected")
            print("Your key will be provided at the end of encoding")
        message = input ("Please input your message: ")
        encoding = Encoder(cipher, message, encoding_type)
        encoding.get_Code_as_String()


    #Decoding Mode
    if mode == "decoding":
        os.system('cls')
        print("Decoding mode")
        print()
        decoding_type = None
        while decoding_type != "binary" and decoding_type != "ascii":
            decoding_type = input ("Please input which of key you would like (binary/ascii)")
        if decoding_type == "binary":
            os.system('cls')
            print("Binary key selected")
            isNotBin = True
            while isNotBin: #This block checks if the input is a binary
                cipher = string(input("Please input a 8 character long binary"))
                b = '10'
                isNotBin = True
                for char in cipher:
                    if char not in b: #checks if any characters in 'b' are present in the string
                        isNotBin = False
                        break
                    else:
                        pass
                if len(cipher) > 8: #Checks if the cipher is more than 8 characters long
                    isNotBin = True
        if decoding_type == "ascii":
            os.system('cls')
            print("Ascii key selected")
            while cipher < 0 and cipher > 255 or None:
                cipher = int(input("Please input an ascii number between 0 and 255"))
        
        message = string(input ("Please input your coded message: "))
        decoding = Decoder(cipher, message, decoding_type)
        decoding.get_unCode_as_String


    repeat = input("Do you want to encode/decode another text? y/n")
    if repeat == 'n':
        isRunning = False

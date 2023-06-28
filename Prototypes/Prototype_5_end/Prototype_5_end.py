import random
import os

def cipherQuestion():
    notNumAllowed = True
    choiceType = 0
    while notNumAllowed:
        
        while choiceType!= "b" and choiceType!="n":
            choiceType = input("Please choose betweeen a binary(b) or a number(n) cipher... ") #checking if the choice is either 1 or 2
        if choiceType == "b":#binary selected
            print("Binary selected")
            while (notBinary):
                notBinary = binaryChecker(input ("Please input a binary Number")) #uses binary checker to check if the input is a binary (possible issues here)

        if choiceType=="n":#cipher selected
            print("Number cipher selected")
            notNumAllowed = True
            while(notNumAllowed):
                answerNum = input("Please input a number between 1 and 255")
                if int(answerNum) >= 1 and int(answerNum) <= 255:
                    notNumAllowed = False
                else:
                    print("Error, please enter a valid number...")
            return int(answerNum)

def stringToAsciilist(stringA): #string to ascii converter (output is in a list)
    converted= []
    for i in stringA:
        converted.append(ord(i))
    return converted

def asciiListToString(asciiA): #ascii to string converter (input is a list and output is normal)
    converted = []
    for a in asciiA:
        for b in asciiA[a]:
            converted [a][b] = chr(asciiA[a][b])
    return converted

def binaryChecker(stringA): #checks if given number is a binary 
    b = '10'
    count = 0
    for char in stringA:
       if char not in b: #checks if any characters in 'b' are present in the string
          count = 1
          break
       else:
          pass
    if count:
       print("Error number is not a Binary")
       return(False)
    else:
       print("Number is a Binary")
       return(True)

def convertAndEncode (): #changes the given text and converts it to asccii in a list, encodes it and gives it out as a string
    #intro
    choice = 0
    pathFinder = True
    path = ()
    os.system('cls')
    print("Encoding mode selected")
    while choice != 'f' and choice != 't':
        choice = input("Would you like to encode a file(f) or encoded a text(t)?")
    if choice == "t":
        message =input("Please input your text: ")
    else:
        path = input("Please input the text document's path: ")
        f = open(path, "r")
        message = f.open(path, "r")
    cipher = cipherQuestion()
    #Encoding Process
    asciiList= stringToAsciilist(message)
    codedList = []
    indexI = 0
    indexX = 0
    for i in asciiList: #first one is 97
        for x in asciiList[indexI]: #list index is out of range
            codedList[indexI][indexX]=asciiList[indexI][indexX]^cipher #encodes the ASCII list using XOR


    convertedCodedList = [] #declaring the list used to save the characters
    #encoded character output
    for a in codedList:
        for b in codedList[a]:
            convertedCodedList = [a][b] = chr([a][b]) #turns the encoded ascii values to characters
    convertedCodedString = ' '.join([str(a for b,a in enumerate(convertedCodedList))]) #turns it to a string
    return convertedCodedString


def decodeAndConvert():
    #intro
    choice = 0
    os.system('cls')
    print("Encoding mode selected")
    while choice != 'e' and choice != 't':
        choice = input("Would you like to decode a file(e) or decoded a text(t)?")
    if choice == "t":
        message =input("Please input your text: ")
    else:
        path = input("Please input the text document's path: ")
        f = open(path, "r")
        message = f.open(path, "r")
    cipher = cipherQuestion()
    decoded = []
    convertedList = []
    x=0
    
    for i in message:
        for x in message[i]:
            decoded[i][x] = message[i][x] ^ cipher #decodes
    convertedEncodedString = ' '.join([str(a for b,a in enumerate(asciiListToString(decoded)))]) #Converts the Ascii List to a normal string
    endchoice = ()
    while endchoice != "f" and endChoice != "c":
        endChoice = input("Would you like the decoded text to be outputted in a file(f) or in the CMD(c)?")
    if endChoice == "f":
        name = input("Please input a name for the file(Must include the file ending): ")
        d = open(name, "w")
        d.write(convertedEncodedString)

        

isRunning = True
asking = ()
repeat = ()
while(isRunning):

    print("Encoding and decoding program")
    print()
    asking = input("Please select between encoding mode (e) and decoding mode (d)")
    #os.system('cls')

    if asking == "e":
        convertAndEncode()
    if asking== "d":
        decodeAndConvert()

    repeat = input("Do you want to encode/decode another text? y/n")
    if repeat == 'n':
        isRunning = False
    

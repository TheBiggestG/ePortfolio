import random


def stringToBinary(txt): #all of this is done in a list
  l,m=[],[]
  for i in txt:
    l.append(ord(i)) #turns it into its ASCII form
    #append meaning: Append in Python is a method used to add a single item to a list
  for i in l:
    m.append(int(bin(i)[2:])) #changes to Binary
  return m
def numToString(num): #changes a number to binary
    return (int(bin(num)[2:]))
def codeMaker(): #makes a random binary
    a = random.randint(1,256)
    b = numToString(a)
    return b 
def codeMakerStreamlined():
    return numToString(random.randint(1,256))
def encode (message, code):
    encoded = []
    x=0
    while (x!= len(message)):
        a = 0
        while (a!= len(str(message[x]))):
            if (str(message[x][a])!= str(code[a])):
                encoded[x][a] = 1
            else: encoded = 0

        x=+1

    return encoded
    
    

print(stringToBinary("hallo")) #hallo is printed in a list
toConvert = input("Please input something: ")
converted = (stringToBinary(toConvert))#turns input into Binary
print(converted)
print(codeMaker()) #Makes a random binary for use in encoding
#print(codeMakerStreamlined) #Somehow has a weird Error

#encoding part (Here I will make changes to the Binaries)
# 0101
# 1100
# 1001
bin1 = [1011011]
coder1 = 1010101#key
encoded1 =[]
encoded1 = encode(bin1, coder1)
print (encoded1)

#0000
#1001 1010

#FOR XOR SORT:
#use ^ as an operator. Just search on how to do XOR sort in Python
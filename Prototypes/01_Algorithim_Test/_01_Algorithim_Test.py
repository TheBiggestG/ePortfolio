import random
import math
import string

def toBinary(a):
    l,m=[],[]  #l and m are being declared as a List (Array)
    for i in a:
        l.append(ord(i))  
    for i in l:
        m.append(int(bin(i)[2:]))
    return m


ToEncode = "Hello"
print(ToEncode)
Encoded = toBinary(ToEncode)
print (Encoded)
    

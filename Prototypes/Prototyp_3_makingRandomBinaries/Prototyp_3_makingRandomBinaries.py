#For UTF-8
import random
import math
import string

def toBinary(a):
  l,m=[],[]
  for i in a:
    l.append(ord(i)) #turns it into its ASCII form
    #append meaning: Append in Python is a method used to add a single item to a list
  for i in l:
    m.append(int(bin(i)[2:])) #changes to Binary
  return m

print('Prototype 3, this program will give a random UTF-8 in binary form')
coder = 0
coder = random.randrange(0, 128)
print(coder)
coderbin = toBinary(coder)
print (coderbin)
word = input("Please input a word")



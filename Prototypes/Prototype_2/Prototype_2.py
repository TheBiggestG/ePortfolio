import string
import random


#future fuction for encoding
print ("Prototype 2")
alphabet = [random.choice(string.ascii_letters)]
i= 0

while i != 26:
    alphabet.append(random.choice(string.ascii_letters))
    b = 0
    while b != 26:
        if b != i: #if it isn't the same list place, then continue
            if alphabet[i] == alphabet[b]: #checking if the contents are the same

                print (i, "Is not unique, proceeding to change...")
                alphabet[i] = random.choice(string.ascii_letters)
        b+=1
    i+=1


print (alphabet)

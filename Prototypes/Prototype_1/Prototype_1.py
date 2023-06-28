#Encoder Program Prototype_1
import random
import string
import array


message = input("Please input your message, it will be randomly encoded. The Key will be given out at the end...")
alphabet = [] #Declaring alphabet array
message = message.lower()
i = 0
while i < 27:
    alphabet[i] = random.choice(string.ascii_letters)

    b = 0
    while b <27:
        if b != i: #if it isn't the same list place, then continue
            if alphabet[i] == alphabet[b]: #checking if the contents are the same

                print (i, "Is not unique, proceeding to change...")
                alphabet[i] = random.choice(string.ascii_letters)
        b+=1
    i+=1
print (alphabet)
print(message)


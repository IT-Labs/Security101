import pickle

class MyUser(object): 
    def __init__(self, name): 
        self.name = name
        
user = MyUser('Peter')
serialized = pickle.dumps(user)
filename = 'serialized.untrusted'


with open(filename, 'w') as file_object:
    file_object.write(serialized)
    
filename= 'serialized.native'

with open(filename) as file_object:
    raw_data = file_object.read()

try:    
    deserialized = pickle.loads(raw_data)
    print(deserialized.name)
except:
    print('Error during deseriazlization')
    

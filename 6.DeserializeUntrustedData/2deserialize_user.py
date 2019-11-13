import pickle

class MyUser(object): 
    def __init__(self, name): 
        self.name = name
        
user = MyUser('Peter')
serialized = pickle.dumps(user)
filename = 'serialized.native'


with open(filename, 'wb') as file_object:
    file_object.write(serialized)

with open(filename) as file_object:
    raw_data = file_object.read()
    
deserialized = pickle.loads(raw_data)

print(deserialized.name)
    

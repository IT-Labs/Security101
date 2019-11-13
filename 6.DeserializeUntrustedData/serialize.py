import yaml
import hashlib
import hmac

class MyUser(object):
    def __init__(self, name):
        self.name = name

# Secret key that is only given to trusted app
KEY= 'secret' # in real scenario, it should not be in the file
user = MyUser('Peter')
serialized = yaml.dump(user)
# Calculate signature over serialized data
signature = hmac.new(KEY, serialized, hashlib.sha256).hexdigest()
# Calculate length of signature (constant)
SIGNATURE_LENGTH = len(signature)
filename = 'serialized.yaml'

with open(filename, 'w') as file_object:
    # Write signature plus serialzed data
    file_object.write(signature + serialized)

with open(filename) as file_object:
    raw_data = file_object.read()

try:
    # Check if raw data contains at least a signature
    if len(raw_data) > SIGNATURE_LENGTH:
        # Read signature part of raw data
        read_signature = raw_data[:SIGNATURE_LENGTH]
        # Read the rest, serialized part of raw data
        data = raw_data[SIGNATURE_LENGTH:]
        # Calculate and compare signatures
        computed_signature = hmac.new(KEY, data, hashlib.sha256).hexdigest()
        if hmac.compare_digest(read_signature, computed_signature): 
            deserialized = yaml.load(data)
            print(deserialized.name)
except:
    print('Error during deserialization')

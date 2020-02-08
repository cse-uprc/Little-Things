from pymongo import MongoClient
from random import randint
#Step 1: Connect to MongoDB - Note: Change connection string as needed
client = MongoClient("mongodb+srv://admin:littlethings@conversationstarter-dcvon.gcp.mongodb.net/test?retryWrites=true&w=majority")
db=client.LittleThings
#Step 2: Create sample data
user = {
    'username' : 'Naomi',
    'catchphrase' : 'I tried',
}
habit = {
    'habitname' : 'Eat food',
    'timelength' : 5,
    'frequency' : 3,
    'user' : 'Naomi'
}

result = db.Users.insert_one(user)
result = db.Habits.insert_one(habit)

print('finished adding new user')


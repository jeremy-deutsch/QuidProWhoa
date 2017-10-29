import subprocess
from glob import glob
from pprint import pprint
import os
import random
import json

ingredients = glob('Assets/Resources/IngredientSprites/*.png')

ingredients = [os.path.basename(x).replace('.png', '') for x in ingredients]

buffs = [
    "STR",
    "STA",
    "INT",
    "COUR",
    "CHA",
    "SPE",
]

jsonData = [
]
for ingredient in ingredients:
    jsonData.append({
        "name": ingredient,
        "buff": random.choice(buffs)
    })

with open('Assets/JSON/ingredients.json', 'w') as outfile:
    json.dump({
        "ingredients": jsonData,
    }, outfile, indent=4)


import requests

BASE_URL = "http://localhost:5000/api/equipment"

def test_create_equipment():
    data = {
        "Name": "Scale of the Bronze Tyrant",
        "Description": "It shimmers and glows in certain light",
        "Tags": {
            "Rarity": "VERY_RARE",
            "EquipmentType": "ARMOR",
            "RequiresAttunement": True
        },
        "OnReaction": [
            {
            "Name": "Electric Discharge",
            "Description": "When hit, the wielder can choose to release a shockwave of lightning energy around them in a 10 ft. radius. Creatures in the radius must make a DC 14 Dex Save or take **1d6 Lightning Damage** per charge used or half as much on a save. When this feature is used, it cannot be used until the next short rest."
            }
        ],
        "Effects": [
            "AC is 16 + Dex Modifier (maximum of 2)",
            "Disadvantage on Stealth Checks",
            "When struck with an attack that would deal damage, gain 1 charge.",
            "While the armor has charges, gain resistance to Lightning Damage."
        ],
        "ResetsOn": "ALWAYS"
    }
    response = requests.post(BASE_URL + "/create", json=data)
    assert response.status_code == 200 or response.status_code == 201
    json = response.json()
    assert json["name"] == "Scale of the Bronze Tyrant"

# TODO: figure out if this test is run one after the other or is run indep. of each other
# If it's run indep of each other, then we should create multiple objects to get all 
def test_get_all_equipment():
    response = requests.get(BASE_URL + "/all")
    assert response.status_code == 200 or response.status_code == 201

def test_get_equipment():
    pass

def test_update_equipment():
    pass


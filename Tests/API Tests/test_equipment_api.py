import requests

BASE_URL = "https://localhost:62438/api/equipment"

def test_create_equipment():
    data = {
        "Name": "Scale of the Bronze Tyrant",
        "Description": "It shimmers and glows in certain light",
        "Tags": ["HEAVY_ARMOR"],
        "EquipmentSlot": ["CHEST"],
        "Charges": 0,
        "MaxCharges": 4,
    }
    headers = {
        "Content-Type": "application/json"
    }
    response = requests.post(BASE_URL + "/create", headers=headers, json=data, verify=False)
    print(response.content)
    assert response.status_code == 200 or response.status_code == 201
    json = response.json()
    assert json["name"] == "Scale of the Bronze Tyrant"

# TODO: figure out if this test is run one after the other or is run indep. of each other
# If it's run indep of each other, then we should create multiple objects to get all 
# def test_get_all_equipment():
#     response = requests.get(BASE_URL + "/all")
#     assert response.status_code == 200 or response.status_code == 201

# def test_get_equipment():
#     pass

# def test_update_equipment():
#     pass


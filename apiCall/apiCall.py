import requests

def getAll(endpointName:str):
    return requests.get(f"https://localhost:7119/api/ble/{endpointName}", verify=False)

def searchByName(endpointName:str, searchName:str):
    return requests.get(f"https://localhost:7119/api/ble/{endpointName}/{searchName}", verify=False)
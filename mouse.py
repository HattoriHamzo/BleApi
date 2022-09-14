import pyautogui
import time

while True:
    time.sleep(2)
    pyautogui.moveRel(0,10)
    time.sleep(2)
    pyautogui.moveRel(0,-10)
import os
import threading
from telegramBot import telegramBot


def main():
    telegramBot.bot.infinity_polling()
    

if __name__ == '__main__':
    oneThreadBot = threading.Thread(name="BotThread", target=main())
    oneThreadBot.start()
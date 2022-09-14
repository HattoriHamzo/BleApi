import telebot
import json
from apiCall import apiCall as BleApi

API_KEY:str = '5322245864:AAHP1DC_bOy1CSJUFzxYp7N8fsi5ugQ92NY'
bot:telebot = telebot.TeleBot(API_KEY)

@bot.message_handler(commands=['start'])
def startMessage(message:str):
    bot.reply_to(message, "Hi! Welcome to BleAPI Bot, nice to meet you. \nUse /help to see all the commands you can use to interact with me")

@bot.message_handler(commands=['help'])
def helpMessage(message:str):
    bot.reply_to(message, "Here you can see the commands you can use to comunicate with me \nUse /products to see all the products on the database")

@bot.message_handler(commands=['products'])
def allProductsMessage(message:str):
    jsonPrettify:json = json.dumps(BleApi.getAll("products").json(), indent= 1)
    bot.send_message(message.chat.id, jsonPrettify)
import json 
import pika
import sys
from sklearn import svm
from joblib import dump, load



class Consumer:
    def __init__(self,name):
        self.connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
        self.channel = self.connection.channel()
        self.queue_name =name 



    def _init_queue(self):
        self.channel.queue_declare(queue=self.queue_name)

    def callback_fn(self,ch, method, properties, body):
        print('callback function called')
        fruitModel = load('apples.joblib')
        

        x = body.decode('utf-8')
        x = json.loads(x)

        
        print("output")
        x = [list(x.values())]

        y = fruitModel.predict(x)
        print(y)

    def consume(self):
        self._init_queue()
        self.channel.basic_consume(queue=self.queue_name, auto_ack=True, on_message_callback=self.callback_fn)
        self.channel.start_consuming()


consumer = Consumer('hello')
consumer.consume()


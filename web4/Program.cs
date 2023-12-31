﻿namespace web4
{
    internal class Program
    {


        /*Мы собираемся сделать наш класс полностью клиент-серверным 
         * с возможностью отправки данных сразу нескольким клиентам. 
         * Доработаем наш код следующим образом. Представьте что наш сервер умеет работать как медиатор 
         * (умеет отправлять сообщения по имени клиента), а также умеет возвращать список всех подключенных к нему клиентов. 
         * Для этого доработаем наш класс сообщений добавив поле ToName.
         
         
         Доработаем систему команд. Имя пользователя сервера всегда будет Server. Если сервер получает команду (как текст сообщения):
            register : то он добавляет клиента в свой список. 
            delete: он удаляет клиента из списка
            если сервер не получает имени получателя то он отправляет сообщение всем клиентам
            если сервер получает имя получателя то он отправляет сообщение одному конкретному клиенту. Код сервера должен выглядеть примерно следующим образом:
         
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
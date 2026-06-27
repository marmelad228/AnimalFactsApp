using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFactsApp
{
    internal class Program
    {
        // Создаем один общий HttpClient для запросов
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            // Настройка консоли на корректное чтение кириллицы
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("      ПРИЛОЖЕНИЕ: ИНТЕРЕСНЫЕ ФАКТЫ     ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Получить случайный факт о СОБАКАХ");
                Console.WriteLine("2. Получить случайный факт о КОШКАХ");
                Console.WriteLine("3. Выход из программы");
                Console.WriteLine("========================================");
                Console.Write("Выберите действие (1-3): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await FetchDogFactAsync();
                        break;
                    case "2":
                        await FetchCatFactAsync();
                        break;
                    case "3":
                        keepRunning = false;
                        Console.WriteLine("\nПрограмма успешно завершена. До встречи!");
                        break;
                    default:
                        Console.WriteLine("\nОшибка ввода! Нажмите любую кнопку для повтора...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // МЕТОД ДЛЯ ОБРАБОТКИ СОБАК
        private static async Task FetchDogFactAsync()
        {
            string endpoint = "https://dog-api.kinduff.com/api/facts";

            Console.WriteLine("\nОтправка GET-запроса к Dog API...");
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);

                // Выводим статус ответа (Критерий лабораторной!)
                Console.WriteLine($"Статус HTTP-ответа сервера: {(int)response.StatusCode} {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // Парсим в наш класс DogFact
                    DogFact dogData = JsonConvert.DeserializeObject<DogFact>(jsonString);

                    // ПРОВЕРКА: Если массив фактов не пустой, выводим нулевой элемент
                    if (dogData != null && dogData.Facts != null && dogData.Facts.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nФАКТ О СОБАКАХ: {dogData.Facts[0]}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        // Если сервер прислал пустой массив, выведем сырой текст ответа для отладки
                        Console.WriteLine("\nСервер вернул успешный статус, но массив фактов пуст.");
                        Console.WriteLine($"Ответ сервера: {jsonString}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }

        // МЕТОД ДЛЯ ОБРАБОТКИ КОШЕК
        private static async Task FetchCatFactAsync()
        {
            string endpoint = "https://catfact.ninja/fact";

            Console.WriteLine("\nОтправка GET-запроса к Cat API...");
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);

                // Выводим статус ответа
                Console.WriteLine($"Статус HTTP-ответа сервера: {(int)response.StatusCode} {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // Парсим в наш класс CatFact (название обновлено)
                    CatFact catData = JsonConvert.DeserializeObject<CatFact>(jsonString);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nФАКТ О КОШКАХ: {catData.Fact}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }
}
